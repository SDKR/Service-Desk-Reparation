using ServiceDesk_Reperation.DBConnect;
using ServiceDesk_Reperation.ViewModel;
using System;
using System.Data;

namespace ServiceDesk_Reperation.Model
{
    class Part : ObservableObject
    {
        private int _ID;
        private int _caseID;
        private string _partname;
        private double _price;
        private PartStatus _status;
        private DateTime _lastchangeddate;
        private DBObject _db;

        public int ID
        {
            get { return _ID; }
            set { _ID = value;
                RaisePropertyChangedEvent("ID");
            }
        }
        public int CaseID
        {
            get { return _caseID; }
            set { _caseID = value;
                RaisePropertyChangedEvent("CaseID");
            }
        }
        public string PartName
        {
            get { return _partname; }
            set { _partname = value;
                RaisePropertyChangedEvent("PartName");
            }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value;
                RaisePropertyChangedEvent("Price");
            }
        }
        public PartStatus Status
        {
            get { return _status; }
            set { _status = value;
                RaisePropertyChangedEvent("Status");
            }
        }

        public DateTime LastChangedDate
        {
            get { return _lastchangeddate; }
            set { _lastchangeddate = value;
                RaisePropertyChangedEvent("LastChangedDate");
            }
        }

        public DBObject DB
        {
            get { return _db; }
            set { _db = value; }
        }

        public Part()
        {
            DB = new DBObject();
            Status = new PartStatus();
        }
        public Part(int ID)
        {
            DB = new DBObject();
            DataSet ds = new DataSet();
            ds = DB.Query($"SELECT * FROM dele WHERE ID = {ID}");
            this.ID = (int) ds.Tables[0].Rows[0][0];
            CaseID = (int) ds.Tables[0].Rows[0][1];
            PartName = (string) ds.Tables[0].Rows[0][2];
            Price = (double) ds.Tables[0].Rows[0][3];
            Status = new PartStatus((int)ds.Tables[0].Rows[0][4]);
            LastChangedDate = Convert.ToDateTime(ds.Tables[0].Rows[0][5]);
        }

        public void updatePart()
        {
            DB.NonQuery($"UPDATE dele SET del = '{PartName}', pris = {Price}, status = {Status.ID}, ændringsdato = CURRENT_TIMESTAMP WHERE ID = {ID}");
            LastChangedDate = DateTime.Now;
        }
        public void deletePart()
        {
            DB.NonQuery($"DELETE FROM dele WHERE ID = {ID}");
        }
        public void createPart()
        {
            ID = Convert.ToInt32(DB.ScalarQuery($"CALL InsertPart({CaseID}, '{PartName}', {Price}, {Status.ID})"));
            LastChangedDate = DateTime.Now;
        }
    }
}
