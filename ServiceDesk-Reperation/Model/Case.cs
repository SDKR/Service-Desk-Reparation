using ServiceDesk_Reperation.DBConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk_Reperation.Model
{
    class Case
    {
        private int _ID;
        private Customer _customer;
        private PC _pc;
        private string _description;
        private CaseStatus _status;
        private DateTime _creationDate;
        private List<Part> _parts;
        private DBObject _db;

        public int ID
        {
            get { return _ID -1; }
            set { _ID = value + 1; }
        }
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }
        public PC PC
        {
            get { return _pc; }
            set { _pc = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public CaseStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }
        public List<Part> Parts
        {
            get { return _parts; }
            set { _parts = value; }
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
            Parts = new List<Part>();
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
            Parts = new List<Part>();
        }

        public void updateCase()
        {
            DB.NonQuery($"UPDATE sager SET beskrivelse = '{Description}',status = {Status.ID} WHERE ID = {ID}");
            Customer.updateCustomer();
            PC.updatePC();
        }
        public void deleteCase()
        {
            DB.NonQuery($"DELETE FROM sager WHERE ID = {ID}");
            Customer.deleteCustomer();
            PC.deletePC();
        }
        public void createCase()
        {
            Customer.createCustomer();
            PC.createPC();
            ID = Convert.ToInt32(DB.ScalarQuery($"CALL InsertCase({Customer.ID}, {PC.ID}, '{Description}', '{Status.ID}'"));
            CreationDate = DateTime.Now;
        }
        public void GetParts()
        {
            DataSet ds = new DataSet();
            ds = DB.Query($"SELECT ID FROM dele WHERE sagid = {ID}");
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
            Parts = new List<Part>();
        }

    }
}
