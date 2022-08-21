using IsmmDownloader.Controller;
using IsmmDownloader.Interface;
using IsmmDownloader.Model;
using IsmmDownloader.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsmmDownloader.Forms
{
    public partial class ControlPanel : Form, IFaultsDataView
    {
        private Faults _faults = null;
        public ControlPanel()
        {
            InitializeComponent();
        }

        public void SetController(Faults faults)
        {
            this._faults = faults;
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            SetController(Program.Faults);
            //Fault Number	Site Fault Number	Trade	Trade Category	Type of Fault	Impact	Site	Building	Floor	Room	Cancel Status	Reported Date	Fault Acknowledged Date	Responded on Site Date	RA Conducted Date	Work Started Date	Work Completed Date	Attended By	Action(s) Taken	Other Trades Required Date	Cost Cap Exceed Date	Assistance Requested Date	Fault Reference	End User Name	End User Priority	End User Contact	Incident Report	Reported By	Remarks	
            //Fault Number,Site Fault Number,Trade,Trade Category,Type of Fault,Impact,Site,Building,Floor,Room,Cancel Status,Reported Date,Fault Acknowledged Date,
            //Responded on Site Date,RA Conducted Date,Work Started Date,Work Completed Date,Attended By,Action(s) Taken,Other Trades Required Date,Cost Cap Exceed Date,
            //Assistance Requested Date,Fault Reference,End User Name,End User Priority,End User Contact,Incident Report,Reported By,Remarks,
            dataGridView1.ColumnCount = 31;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Fault Number";
            dataGridView1.Columns[2].Name = "Site Fault Number";
            dataGridView1.Columns[3].Name = "Trade";
            dataGridView1.Columns[4].Name = "Trade Category";
            dataGridView1.Columns[5].Name = "Type of Fault";
            dataGridView1.Columns[6].Name = "Impact";
            dataGridView1.Columns[7].Name = "Site";
            dataGridView1.Columns[8].Name = "Building";
            dataGridView1.Columns[9].Name = "Floor";
            dataGridView1.Columns[10].Name = "Room";
            dataGridView1.Columns[11].Name = "Cancel Status";
            dataGridView1.Columns[12].Name = "Reported Date";
            dataGridView1.Columns[13].Name = "Fault Acknowledged Date";
            dataGridView1.Columns[14].Name = "Responded on Site Date";
            dataGridView1.Columns[15].Name = "RA Conducted Date";
            dataGridView1.Columns[16].Name = "Work Started Date";
            dataGridView1.Columns[17].Name = "Work Completed Date";
            dataGridView1.Columns[18].Name = "Attended By";
            dataGridView1.Columns[19].Name = "Action(s) Taken";
            dataGridView1.Columns[20].Name = "Other Trades Required Date";
            dataGridView1.Columns[21].Name = "Cost Cap Exceed Date";
            dataGridView1.Columns[22].Name = "Assistance Requested Date";
            dataGridView1.Columns[23].Name = "Fault Reference";
            dataGridView1.Columns[24].Name = "End User Name";
            dataGridView1.Columns[25].Name = "End User Priority";
            dataGridView1.Columns[26].Name = "End User Contact";
            dataGridView1.Columns[27].Name = "Incident Report";
            dataGridView1.Columns[28].Name = "Reported By";
            dataGridView1.Columns[29].Name = "Remarks";
            dataGridView1.Columns[30].Name = "Pictures";


            _faults.SetDataView(this);
        }

        public void UpdateDatatable(List<FaultsOrder> orders)
        {
            if (dataGridView1.InvokeRequired)
            {
                this.Invoke(new Action<List<FaultsOrder>, bool>(UpdateDatatable), orders, true);
                return;
            }
            else
            {
                UpdateDatatable(orders, false);
            }
        }

        public void UpdateDatatable(List<FaultsOrder> orders, bool IsInvoked)
        {
            foreach (var order in orders)
            {
                int rowid = FindOrderID(order.id);
                if (rowid < 0)
                {
                    dataGridView1.Rows.Add(new string[] {
                        order.id,
                        order.site_fault_number,
                        order.created_at,
                        order.responded_date,
                        order.site_visited_date,
                        order.ra_acknowledged_date,
                        order.work_started_date,
                        order.work_completed_date
                    });

                    _faults.faultsMessages.Enqueue(new FaultsMessage()
                    {
                        Message = $"[!] You have a new order: https://ismm.sg/ce/fault/{order.id}, reported at {order.created_at}."
                    });
                }
                else
                {
                    dataGridView1.Rows[rowid].Cells["Fault Acknowledged Date"].Value = order.responded_date;
                    dataGridView1.Rows[rowid].Cells["Responded on Site Date"].Value = order.site_visited_date;
                    dataGridView1.Rows[rowid].Cells["RA Conducted Date"].Value = order.ra_acknowledged_date;
                    dataGridView1.Rows[rowid].Cells["Work Started Date"].Value = order.work_started_date;
                    dataGridView1.Rows[rowid].Cells["Work Completed Date"].Value = order.work_completed_date;
                }

            }

        }

        private int FindOrderID(string OrderID)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["ID"].Value == null)
                {
                    continue;
                }

                if (dataGridView1.Rows[i].Cells["ID"].Value.Equals(OrderID))
                {
                    return i;
                }
            }

            return -1;

        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_faults.faultsMessages.Count > 0)
            {
                FaultsMessage message = _faults.faultsMessages.Dequeue();
                Program.Message.SendMesage("ISMM Reminder", message.Message);
            }
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _faults.faultsMessages.Clear();
        }

        public DataGridViewRowCollection GetDatatable()
        {
            return dataGridView1.Rows;
        }
    }
}
