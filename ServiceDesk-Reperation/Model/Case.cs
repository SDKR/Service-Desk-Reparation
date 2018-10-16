using ServiceDesk_Reperation.DBConnect;
using ServiceDesk_Reperation.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace ServiceDesk_Reperation.Model
{
    class Case : ObservableObject
    {
        private int _ID;
        private Customer _customer;
        private PC _pc;
        private string _description;
        private CaseStatus _status;
        private DateTime _creationDate;
        private ObservableCollection<Part> _parts;
        private DBObject _db;

        public int ID
        {
            get { return _ID; }
            set { _ID = value;
                RaisePropertyChangedEvent("ID");
            }
        }
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value;
                RaisePropertyChangedEvent("Customer");
            }

        }
        public PC PC
        {
            get { return _pc; }
            set { _pc = value;
                RaisePropertyChangedEvent("PC");
            }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value;
                RaisePropertyChangedEvent("Description");
                RaisePropertyChangedEvent("ValidationCommand");
            }
        }
        public CaseStatus Status
        {
            get { return _status; }
            set { _status = value;
                RaisePropertyChangedEvent("Status");
                RaisePropertyChangedEvent("ValidationCommand");
            }
        }
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value;
                RaisePropertyChangedEvent("CreationDate");
            }
        }
        public ObservableCollection<Part> Parts
        {
            get { return _parts; }
            set { _parts = value;
                RaiseCollectionChangedEvent("Parts");
            }
        }

        public DBObject DB
        {
            get { return _db; }
            set { _db = value; }
        }


        public Case()
        {
            DB = new DBObject();
            Customer = new Customer();
            PC = new PC();
            Status = new CaseStatus();
            CreationDate = DateTime.Now;
            Parts = new ObservableCollection<Part>();
        }
        public Case(int ID)
        {
            DB = new DBObject();
            DataSet ds = new DataSet();
            ds = DB.Query($"SELECT * FROM sager WHERE ID = {ID}");
            this.ID = (int) ds.Tables[0].Rows[0][0];
            Customer = new Customer((int)ds.Tables[0].Rows[0][1]);
            PC = new PC((int)ds.Tables[0].Rows[0][2]);
            Description = (string)ds.Tables[0].Rows[0][3];
            Status = new CaseStatus((int)ds.Tables[0].Rows[0][4]);
            CreationDate = Convert.ToDateTime(ds.Tables[0].Rows[0][5]);
            Parts = new ObservableCollection<Part>();
        }

        public void updateCase()
        {
            DB.NonQuery($"UPDATE sager SET beskrivelse = '{Description}',status = {Status.ID} WHERE ID = {ID}");
            Customer.updateCustomer();
            PC.updatePC();
        }
        public void deleteCase()
        {
            GetParts();
            foreach (Part item in Parts)
            {
                item.deletePart();
            }
            DB.NonQuery($"DELETE FROM `sager` WHERE `sager`.`ID` = {ID}");
            DB.NonQuery($"DELETE FROM kunde WHERE ID = {Customer.ID}");
            DB.NonQuery($"DELETE FROM pc WHERE ID = {PC.ID}");
        }
        public void createCase()
        {
            Customer.createCustomer();
            PC.createPC();
            ID = Convert.ToInt32(DB.ScalarQuery($"CALL InsertCase({Customer.ID}, {PC.ID}, '{Description}', '{Status.ID}')"));
            CreationDate = DateTime.Now;
        }
        public void GetParts()
        {
            DataSet ds = new DataSet();
            ds = DB.Query($"SELECT ID FROM dele WHERE sagid = {ID}");
            Parts = new ObservableCollection<Part>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Parts.Add(new Part((int)ds.Tables[0].Rows[i][0]));
            }
        }
        public void Refresh()
        {
            DB = new DBObject();
            DataSet ds = new DataSet();
            ds = DB.Query($"SELECT * FROM sager WHERE ID = {ID}");
            this.ID = (int)ds.Tables[0].Rows[0][0];
            Customer = new Customer((int)ds.Tables[0].Rows[0][1]);
            PC = new PC((int)ds.Tables[0].Rows[0][2]);
            Description = (string)ds.Tables[0].Rows[0][3];
            Status = new CaseStatus((int)ds.Tables[0].Rows[0][4]);
            CreationDate = Convert.ToDateTime(ds.Tables[0].Rows[0][5]);
            Parts = new ObservableCollection<Part>();
        }

    }
}
