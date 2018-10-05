﻿using ServiceDesk_Reperation.DBConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk_Reperation.Model
{
    class Customer
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
            set { _ID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public ZipCode_City ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public DBObject DB
        {
            get { return _db; }
            set { _db = value; }
        }


        public Customer()
        {
            DB = new DBObject();
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
            DB.NonQuery($"UPDATE kunde SET navn = '{Name}', adresse = '{Address}', postnr = {ZipCode.Zip}, tlf = '{Telephone}', email = {Email} WHERE ID = {ID}");
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