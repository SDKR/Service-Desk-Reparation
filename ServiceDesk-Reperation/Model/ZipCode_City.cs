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
    class ZipCode_City : ObservableObject
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
            set { _zip = value;
                RaisePropertyChangedEvent("Zip");
                GetCity();
            }
        }

        public string City
        {
            get { return _city; }
            set { _city = value;
                RaisePropertyChangedEvent("City");
            }
        }

        public ZipCode_City(int Zip, string City)
        {
            DB = new DBObject();
            this._zip = Zip;
            this._city = City;
        }

        public ZipCode_City()
        {
            DB = new DBObject();
            DataSet ds = new DataSet();
            ds = DB.Query("Select * From postnrby");
            CityList = new List<ZipCode_City>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                CityList.Add(new ZipCode_City((int)item[0], (string)item[1]));
            }
        }

        public ZipCode_City(int Zip)
        {
            DB = new DBObject();
            DataSet ds = new DataSet();
            ds = DB.Query("Select * From postnrby");
            CityList = new List<ZipCode_City>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                CityList.Add(new ZipCode_City((int)item[0], (string)item[1]));
            }
            this.Zip = Zip;
        }

        private static List<ZipCode_City> _CityList;

        public static List<ZipCode_City> CityList
        {
            get { return _CityList; }
            set { _CityList = value; }
        }


        public void GetCity()
        {
            Predicate<ZipCode_City> CityFinder = (ZipCode_City p) => { return p.Zip == Zip; };
            try
            {
                City = CityList.Find(CityFinder).City;
            }
            catch (Exception)
            {
                City = "Byen findes ikke";
            }
        }
    }
}
