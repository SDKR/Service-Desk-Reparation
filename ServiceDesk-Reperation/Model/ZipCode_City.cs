using ServiceDesk_Reperation.DBConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk_Reperation.Model
{
    class ZipCode_City
    {
        private int _zip;
        private string _city;
        private DBObject _db;

        public DBObject DB
        {
            get { return _db; }
            set { _db = value; }
        }


        public int Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public ZipCode_City()
        {

        }

        public ZipCode_City(int Zip)
        {
            this.Zip = Zip;
            DB = new DBObject();
            GetCity();
        }

        public void GetCity()
        {
            DataSet ds = new DataSet();
            ds = DB.Query($"SELECT * FROM postnrby WHERE postnr = {Zip}");
            City = (string)ds.Tables[0].Rows[0][1];
        }
    }
}
