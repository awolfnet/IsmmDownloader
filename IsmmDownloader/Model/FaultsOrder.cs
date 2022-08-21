using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsmmDownloader.Model
{
    public class FaultsOrder
    {
        //Fault Number,Site Fault Number,Trade,Trade Category,Type of Fault,Impact,Site,Building,Floor,Room,Cancel Status,Reported Date,Fault Acknowledged Date,
        //Responded on Site Date,RA Conducted Date,Work Started Date,Work Completed Date,Attended By,Action(s) Taken,Other Trades Required Date,Cost Cap Exceed Date,
        //Assistance Requested Date,Fault Reference,End User Name,End User Priority,End User Contact,Incident Report,Reported By,Remarks,

        /// <summary>
        /// Order id
        /// </summary>
        public string id { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string site_fault_id { set; get; }

        /// <summary>
        /// FID
        /// </summary>
        public string fault_number { set; get; }

        /// <summary>
        /// Site Fault Number
        /// </summary>
        public string site_fault_number { set; get; }

        /// <summary>
        /// Trade
        /// </summary>
        public string trd { set; get; }

        /// <summary>
        /// Trade Category
        /// </summary>
        public string type { set; get; }

        /// <summary>
        /// Type of Fault
        /// </summary>
        public string cat { set; get; }

        /// <summary>
        /// Impact
        /// </summary>
        public string sev { set; get; }

        /// <summary>
        /// Site
        /// </summary>
        public string st { set; get; }

        /// <summary>
        /// Building
        /// </summary>
        public string bl { set; get; }

        /// <summary>
        /// Floor
        /// </summary>
        public string fl { set; get; }

        /// <summary>
        /// Room
        /// </summary>
        public string rm { set; get; }

        /// <summary>
        /// Reported Date
        /// </summary>
        public string created_at { set; get; }

        /// <summary>
        /// Fault Acknowledged Date
        /// </summary>
        public string responded_date { set; get; }

        /// <summary>
        /// Responded on Site Date
        /// </summary>
        public string site_visited_date { set; get; }

        /// <summary>
        /// RA Conducted Date
        /// </summary>
        public string ra_acknowledged_date { set; get; }

        /// <summary>
        /// Work Started Date
        /// </summary>
        public string work_started_date { set; get; }

        /// <summary>
        /// Work Completed Date
        /// </summary>
        public string work_completed_date { set; get; }

        /// <summary>
        /// Attended By
        /// </summary>
        public string wcun { set; get; }

        /// <summary>
        /// Actions Taken
        /// </summary>
        public string act_taken { set; get; }

        /// <summary>
        /// Other Trades Required Date
        /// </summary>
        public string other_trades_required_date { set; get; }

        /// <summary>
        /// Cost Cap Exceed Date
        /// </summary>
        public string cost_cap_exceed_date { set; get; }

        /// <summary>
        /// Assistance Requested Date
        /// </summary>
        public string assistance_requested_date { set; get; }

        /// <summary>
        /// Fault Reference
        /// fault_reference_id/f_num_ref
        /// </summary>
        public string f_num_ref { set; get; }

        /// <summary>
        /// End User Name
        /// </summary>
        public string end_user_name { set; get; }

        /// <summary>
        /// End User Priority
        /// </summary>
        public string end_user_rank_id { set; get; }

        /// <summary>
        /// End User Contact
        /// </summary>
        public string end_user_contact { set; get; }

        //Incident Report

        /// <summary>
        /// Reported By
        /// </summary>
        public string cu { set; get; }

        /// <summary>
        /// Remarks
        /// </summary>
        public string rmk { set; get; }
    }
}
