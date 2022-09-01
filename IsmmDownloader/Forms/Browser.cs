using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using IsmmDownloader.Controller;

namespace IsmmDownloader.Forms
{
    public partial class Browser : Form, Interface.IFaultsBrowserView
    {
        public ChromiumWebBrowser mainBrowser = null;
        private Faults _faults = null;
        private Dictionary<string, string> _cookies = null;
        private SaveFileDialog fileDialog = new SaveFileDialog();

        public Browser()
        {
            InitializeComponent();
            Cef.Initialize(new CefSettings());
            Cef.EnableHighDPISupport();

            mainBrowser = new ChromiumWebBrowser("https://ismm.sg/ce/faults");
            mainBrowser.FrameLoadEnd += MainBrowser_FrameLoadEnd;
            this.Controls.Add(mainBrowser);
            mainBrowser.Dock = DockStyle.Fill;
        }

        private void MainBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            CookieVisitor visitor = new CookieVisitor();
            visitor.SendCookie += _faults.SendCookie;
            ICookieManager cookieManager = mainBrowser.GetCookieManager();
            cookieManager.VisitAllCookies(visitor);
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            SetController(Program.Faults);
            _faults.OnFetchProgress += Faults_OnFetchProgress;
            _faults.OnFetchDone += Faults_OnFetchDone;
            _faults.OnFetchRetry += Faults_OnFetchRetry;
            _faults.SetBrowserView(this);
            _cookies = new Dictionary<string, string>();

            panelProgress.Left = (this.Width - panelProgress.Width) / 2;
            panelProgress.Top = (this.Height - panelProgress.Height) / 2;
            fileDialog.Filter = "Excel CSV File(*.csv)|*.csv|All Files(*.*)|*.*";
        }

        private void Faults_OnFetchRetry(object sender, Faults.FetchRetryEventArgs e)
        {
            if (labelProgress.InvokeRequired)
            {
                labelProgress.BeginInvoke(
                    (Action)(() =>
                    {
                        labelProgress.Text = $"Retrying: {e.FaultsID} ({e.Retry})";
                    })
                );

            }
            else
            {
                labelProgress.Text = $"Retrying: {e.FaultsID} ({e.Retry})";
            }
        }

        private void menuHome_Click(object sender, EventArgs e)
        {
            mainBrowser.LoadUrl("https://ismm.sg/ce/faults");
        }

        private void menuReload_Click(object sender, EventArgs e)
        {
            mainBrowser.Reload();
        }

        public void SetController(Faults faults)
        {
            _faults = faults;
        }


        public class CookieVisitor : CefSharp.ICookieVisitor
        {
            public event Action<KeyValuePair<string, string>> SendCookie;
            public void Dispose()
            {

            }

            public bool Visit(Cookie cookie, int count, int total, ref bool deleteCookie)
            {
                deleteCookie = false;
                SendCookie?.Invoke(new KeyValuePair<string, string>(cookie.Name, cookie.Value));
                return true;
            }
        }

        private void menuDebug_Click(object sender, EventArgs e)
        {
            mainBrowser.ShowDevTools();
        }

        public Dictionary<string, string> GetCookie()
        {
            return this._cookies;
        }

        public void RefreshPage()
        {
            mainBrowser.Reload();
        }

        private void Faults_OnFetchDone(object sender, Faults.FetchDoneEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Fetch done.");

            if (progressBar1.InvokeRequired)
            {
                progressBar1.BeginInvoke(
                    (Action)(() =>
                    {
                        panelProgress.Visible = false;
                    })
                );
            }
            else
            {
                panelProgress.Visible = false;
            }

            try
            {
                ExportToCSV();
                MessageBox.Show("Export done.","ISMM Report");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ISMM Report");
            }
            
        }

        private void Faults_OnFetchProgress(object sender, Faults.FetchProgressEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Fetch progress: {e.Order.fault_number}({e.Done}/{e.Total})");
            if (progressBar1.InvokeRequired)
            {
                progressBar1.BeginInvoke(
                    (Action)(() =>
                    {
                        progressBar1.Maximum = e.Total;
                        progressBar1.Value = e.Done;
                    })
                );
            }
            else
            {
                progressBar1.Maximum = e.Total;
                progressBar1.Value = e.Done;
            }

            if (labelProgress.InvokeRequired)
            {
                labelProgress.BeginInvoke(
                    (Action)(() =>
                    {
                        labelProgress.Text = $"Downloading: {e.Order.fault_number} ({e.Done}/{e.Total})";
                    })
                );

            }
            else
            {
                labelProgress.Text = $"{e.Done}/{e.Total}({e.Order.id})";
            }


        }

        private string HTMLDecode(string codestring)
        {
            return HttpUtility.HtmlDecode(codestring).Replace("\"", "\"\"");
        }

        private void ExportToCSV()
        {
            StreamWriter writer = new StreamWriter(fileDialog.FileName);
            writer.WriteLine("\"Fault Number\",\"Site Fault Number\",\"Trade\",\"Trade Category\",\"Type of Fault\",\"Impact\",\"Site\",\"Building\",\"Floor\",\"Room\",\"Cancel Status\",\"Reported Date\",\"Fault Acknowledged Date\",\"Responded on Site Date\",\"RA Conducted Date\",\"Work Started Date\",\"Work Completed Date\",\"Attended By\",\"Action(s) Taken\",\"Other Trades Required Date\",\"Cost Cap Exceed Date\",\"Assistance Requested Date\",\"Fault Reference\",\"End User Name\",\"End User Priority\",\"End User Contact\",\"Incident Report\",\"Reported By\",\"Remarks\",\"Fault Pictures\"");
            foreach (var order in _faults.FaultsOrderList)
            {
                writer.WriteLine($"\"{order.fault_number}\",\"{order.site_fault_number}\",\"{HTMLDecode(order.trd)}\",\"{HTMLDecode(order.type)}\",\"{(order.cat)}\",\"{HTMLDecode(order.sev)}\",\"{order.st}\",\"{HTMLDecode(order.bl)}\",\"{HTMLDecode(order.fl)}\",\"{HTMLDecode(order.rm)}\",\"\",\"{order.created_at}\",\"{order.responded_date}\",\"{order.site_visited_date}\",\"{order.ra_acknowledged_date}\",\"{order.work_started_date}\",\"{order.work_completed_date}\",\"{HTMLDecode(order.wcun)}\",\"{HTMLDecode(order.act_taken)}\",\"{order.other_trades_required_date}\",\"{order.cost_cap_exceed_date}\",\"{order.assistance_requested_date}\",\"{order.f_num_ref}\",\"{HTMLDecode(order.end_user_name)}\",\"{HTMLDecode(order.end_user_rank_id)}\",\"{HTMLDecode(order.end_user_contact)}\",\"\",\"{HTMLDecode(order.cu)}\",\"{HTMLDecode(order.rmk)}\",{string.Join(",", order.fault_pictures)}");
            }
            writer.Close();
        }



        private void saveAsExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                DateTime dateFrom = this.dateFrom.Value;
                DateTime dateTo = this.dateTo.Value;

                progressBar1.Value = 0;
                labelProgress.Text = "Fetching....";
                panelProgress.Visible = true;

                Thread t = new Thread(() => _faults.Fetch(dateFrom, dateTo));
                t.Start();
            }
        }

        private void fetchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filterBox.Visible = true;
        }

        private void btnFilterOK_Click(object sender, EventArgs e)
        {
            filterBox.Visible = false;
        }

        private void Browser_Resize(object sender, EventArgs e)
        {
            panelProgress.Left = (this.Width - panelProgress.Width) / 2;
            panelProgress.Top = (this.Height - panelProgress.Height) / 2;

        }
    }
}
