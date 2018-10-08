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
    class PartStatus:ObservableObject
    {
        private int _ID;
        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value;
                RaisePropertyChangedEvent("Status");
            }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value;
                RaisePropertyChangedEvent("ID");
            }
        }


        public PartStatus()
        {
            Status = "ny";
        }

        public PartStatus(int ID)
        {
            this.ID = ID;
            UpdateStatus();
        }

        public void UpdateStatus()
        {
            DBObject DB = new DBObject();
            DataSet ds = new DataSet();
            ds = DB.Query($"SELECT * FROM delestatus WHERE ID = {ID}");
            Status = (string)ds.Tables[0].Rows[0][1];
        }
    }
}
