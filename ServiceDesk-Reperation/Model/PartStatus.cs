using ServiceDesk_Reperation.DBConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk_Reperation.Model
{
    class PartStatus
    {
        private int _ID;
        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }


        public PartStatus()
        {
            Status = "ny";
        }

        public PartStatus(int ID)
        {
            DBObject DB = new DBObject();
            DataSet ds = new DataSet();
            ds = DB.Query($"SELECT * FROM delestatus WHERE ID = {ID}");
            ID = (int)ds.Tables[0].Rows[0][0];
            Status = (string)ds.Tables[0].Rows[0][1];
        }
    }
}
