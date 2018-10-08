using ServiceDesk_Reperation.DBConnect;
using ServiceDesk_Reperation.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk_Reperation.Model
{
    class CaseStatus:ObservableObject
    {
        private int _ID;
        private string _status;

        public int ID
        {
            get { return _ID; }
            set { _ID = value;
                RaisePropertyChangedEvent("ID");
            }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value;
                RaisePropertyChangedEvent("Status");
            }
        }



        public CaseStatus()
        {
            Status = "New";
        }

        public CaseStatus(int ID)
        {
            DBObject DB = new DBObject();
            DataSet ds = new DataSet();
            ds = DB.Query($"SELECT * FROM sagerstatus WHERE ID = {ID}");
            this.ID = (int) ds.Tables[0].Rows[0][0];
            Status = (string) ds.Tables[0].Rows[0][1];
        }

    }
}
