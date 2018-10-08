using ServiceDesk_Reperation.DBConnect;
using ServiceDesk_Reperation.Model;
using ServiceDesk_Reperation.View;
using ServiceDesk_Reperation.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ServiceDesk_Reperation.ViewModel
{
    class PageChanger:ObservableObject
    {
        private DBObject _DB;

        private Case _currentcase;

        public Case CurrentCase
        {
            get { return _currentcase; }
            set { _currentcase = value;
                OnPropertyChanged("CurrentCase");
            }
        }


        private ObservableCollection<Case> _cases;

        public ObservableCollection<Case> Cases
        {
            get { return _cases; }
            set { _cases = value; }
        }

        private Page _currentViewModel;

        public DBObject DB {
            get { return _DB; }
            set{ _DB = value;}
        }

        private Page previouspage;

        public Page currentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged("currentViewModel");
            }
        }
        public Command PageCommand { get; set; }

        public PageCommand BackCommand { get; set; }

        public PageCommand PageAccept { get; set; }

        public DataGridCommand DataGridCommand { get; set; }

        public PageCommand PageSendUpdate { get; set; }

        public PageChanger()
        {
            this.DB = new DBObject();
            this.currentViewModel = new StartPage();
            this.PageCommand = new Command(this);
            this.BackCommand = new PageCommand(this);
            this.DataGridCommand = new DataGridCommand(this);
            this.PageSendUpdate = new PageCommand(this);
            DataSet ds = new DataSet();
            Cases = new ObservableCollection<Case>();
            ds = DB.Query("SELECT ID FROM sager");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            { 
                Cases.Add(new Case(Convert.ToInt32(ds.Tables[0].Rows[i][0])));
            }
            this.PageAccept = new PageCommand(this);
        }

        public void ShowSendUpdate()
        {
            previouspage = currentViewModel;
            currentViewModel = new SendUpdate();
        }

        public void ChangePageMethod()
        {
            previouspage = currentViewModel;
            currentViewModel = new OpretReparation();
        }
        public void ChangebackMethod()
        {
            currentViewModel = previouspage;
        }

        public void ShowRepairList()
        {
            currentViewModel = new KoibAccept();
        }
        public void OpenCase(Case current)
        {
            previouspage = currentViewModel;
            currentViewModel = new OpretReparation();
            CurrentCase = current;
        }
    }
}
