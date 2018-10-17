using ServiceDesk_Reperation.DBConnect;
using ServiceDesk_Reperation.ViewModel;
using System;
using System.Data;

namespace ServiceDesk_Reperation.Model
{
    class Customer : ObservableObject
    {
        private int _ID;
        private string _name;
        private string _address;
        private ZipCode_City _zipCode;
        private string _telephone;
        private string _email;
        private DBObject _db;   


        public int ID
        {
            get { return _ID; }
            set { _ID = value;
                RaisePropertyChangedEvent("ID");
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value;
                RaisePropertyChangedEvent("Name");
                RaisePropertyChangedEvent("ValidationCommand");
            }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value;
                RaisePropertyChangedEvent("Address");
                RaisePropertyChangedEvent("ValidationCommand");
            }
        }

        public ZipCode_City ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value;
                RaisePropertyChangedEvent("ZipCode");
                RaisePropertyChangedEvent("ValidationCommand");
            }
        }

        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value;
                RaisePropertyChangedEvent("Telephone");
                RaisePropertyChangedEvent("ValidationCommand");
            }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value;
                RaisePropertyChangedEvent("Email");
                RaisePropertyChangedEvent("ValidationCommand");
            }
        }

        public DBObject DB
        {
            get { return _db; }
            set { _db = value; }
        }


        public Customer()
        {
            DB = new DBObject();
            ZipCode = new ZipCode_City();
        }

        public Customer(int ID)
        {
            DB = new DBObject();
            DataSet ds = new DataSet();
            ds = DB.Query($"SELECT * FROM kunde WHERE ID = {ID}");
            this.ID = (int) ds.Tables[0].Rows[0][0];
            Name = (string) ds.Tables[0].Rows[0][1];
            Address = (string)ds.Tables[0].Rows[0][2];
            ZipCode = new ZipCode_City((int)ds.Tables[0].Rows[0][3]);
            Telephone = (string)ds.Tables[0].Rows[0][4];
            Email = (string) ds.Tables[0].Rows[0][5];
        }

        public void updateCustomer()
        {
            DB.NonQuery($"UPDATE kunde SET navn = '{Name}', adresse = '{Address}', postnr = {ZipCode.Zip}, tlf = '{Telephone}', email = '{Email}' WHERE ID = {ID}");
        }
        public void deleteCustomer()
        {
            DB.NonQuery($"DELETE FROM kunde WHERE ID = {ID}");
        }
        public void createCustomer()
        {
            string sql = $"CALL InsertCustomer('{Name}', '{Address}', '{ZipCode.Zip}', '{Telephone}', '{Email}');";
            ID = Convert.ToInt32(DB.ScalarQuery(sql));
        }
    }
}
