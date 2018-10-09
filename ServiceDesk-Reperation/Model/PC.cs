using ServiceDesk_Reperation.DBConnect;
using ServiceDesk_Reperation.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServiceDesk_Reperation.Model
{
    class PC : ObservableObject
    {
        private int _ID;
        private string _manufacturer;
        private string _model;
        private string _serialnumber;
        private string _os;
        private string _cpu;
        private string _ram;
        private string _storage;
        private DBObject _db;

        public int ID
        {
            get { return _ID; }
            set { _ID = value;
                RaisePropertyChangedEvent("ID");
                RaisePropertyChangedEvent("ValidationCommand");
            }
        }

        public string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value;
                RaisePropertyChangedEvent("Manufacturer");
                RaisePropertyChangedEvent("ValidationCommand");
            }
        }
        
        public string Model
        {
            get { return _model; }
            set { _model = value;
                RaisePropertyChangedEvent("Model");
                RaisePropertyChangedEvent("ValidationCommand");
            }
        }

        public string SerialNumber
        {
            get { return _serialnumber; }
            set { _serialnumber = value;
                RaisePropertyChangedEvent("SerialNumber");
                RaisePropertyChangedEvent("ValidationCommand");
            }
        }

        public string OS
        {
            get { return _os; }
            set { _os = value;
                RaisePropertyChangedEvent("OS");
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public string CPU
        {
            get { return _cpu; }
            set { _cpu = value;
                RaisePropertyChangedEvent("CPU");
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public string RAM
        {
            get { return _ram; }
            set { _ram = value;
                RaisePropertyChangedEvent("RAM");
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public string Storage
        {
            get { return _storage; }
            set { _storage = value;
                RaisePropertyChangedEvent("Storage");
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public DBObject DB
        {
            get { return _db; }
            set { _db = value; }
        }




        public PC()
        {
            DB = new DBObject();
        }

        public PC(int ID)
        {
            DB = new DBObject();
            DataSet ds = new DataSet();
            ds = DB.Query($"SELECT * FROM pc WHERE ID = {ID}");
            this.ID = (int) ds.Tables[0].Rows[0][0];
            Manufacturer = (string) ds.Tables[0].Rows[0][1];
            Model = (string)ds.Tables[0].Rows[0][2];
            SerialNumber = (string)ds.Tables[0].Rows[0][3];
            OS = (string)ds.Tables[0].Rows[0][4];
            CPU = (string)ds.Tables[0].Rows[0][5];
            RAM = (string)ds.Tables[0].Rows[0][6];
            Storage = (string)ds.Tables[0].Rows[0][7];
        }

        public void updatePC()
        {
            DB.NonQuery($"UPDATE pc SET producent = '{Manufacturer}', model = '{Model}', serienr = '{SerialNumber}', os = '{OS}', cpu = '{CPU}', ram = '{RAM}', lagring = '{Storage}'");
        }

        public void deletePC()
        {
            DB.NonQuery($"DELETE FROM pc WHERE ID = {ID}");
        }

        public void createPC()
        {
            string sql = $"CALL InsertPC('{Manufacturer}', '{Model}', '{SerialNumber}', '{OS}', '{CPU}', '{RAM}', '{Storage}');";
            ID = Convert.ToInt32(DB.ScalarQuery(sql));
        }
    }
}
