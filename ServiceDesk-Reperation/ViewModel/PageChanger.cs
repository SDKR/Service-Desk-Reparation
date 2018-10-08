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
using System.Windows.Data;

namespace ServiceDesk_Reperation.ViewModel
{
    class PageChanger:ObservableObject
    {
        private DBObject _DB;

        private Case _currentcase;

        private List<CaseStatus> _StatusList;

        public List<CaseStatus> StatusList
        {
            get { return _StatusList; }
            set { _StatusList = value; }
        }

        public List<ZipCode_City> CityList { get; set; }

        public void ShowPart(Part para)
        {
            CurrentPart = para;
            RaisePropertyChangedEvent("CurrentPart");
        }

        public Case CurrentCase
        {
            get { return _currentcase; }
            set { _currentcase = value;
                OnPropertyChanged("CurrentCase");
            }
        }

        private List<PartStatus> _partstatuslist;

        public List<PartStatus> PartStatusList
        {
            get { return _partstatuslist; }
            set { _partstatuslist = value; }
        }


        private Part _currentpart;

        public Part CurrentPart
        {
            get { return _currentpart; }
            set { _currentpart = value;
                RaiseCollectionChangedEvent("CurrentPart");
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
        public PartsDataGridCommand PartsDataGridCommand { get; set; }

        public Command PageCommand { get; set; }

        public PageCommand StandardCommand { get; set; }

        public PageCommand PageAccept { get; set; }

        public DataGridCommand DataGridCommand { get; set; }

        public PageChanger()
        {
            this.DB = new DBObject();
            this.currentViewModel = new StartPage();
            this.PageCommand = new Command(this);
            this.StandardCommand = new PageCommand(this);
            this.DataGridCommand = new DataGridCommand(this);
            this.PartsDataGridCommand = new PartsDataGridCommand(this);
            DataSet ds = new DataSet();
            Cases = new ObservableCollection<Case>();
            ds = DB.Query("SELECT ID FROM sager");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            { 
                Cases.Add(new Case(Convert.ToInt32(ds.Tables[0].Rows[i][0])));
            }
            this.PageAccept = new PageCommand(this);
            StatusList = new List<CaseStatus>();
            for (int i = 1; i < 7; i++)
            {
                StatusList.Add(new CaseStatus(i));
            }
            PartStatusList = new List<PartStatus>();
            for (int i = 1; i < 5; i++)
            {
                PartStatusList.Add(new PartStatus(i));
            }
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
            CurrentCase.Refresh();
            currentViewModel = previouspage;
        }

        public void ShowRepairList()
        {
            CurrentCase.GetParts();
            currentViewModel = new ChangeOfBuy();
        }
        public void OpenCase(Case current)
        {
            previouspage = currentViewModel;
            currentViewModel = new OpretReparation();
            CurrentCase = current;
        }
        public void SaveCase()
        {
            CurrentCase.updateCase();
            CurrentCase.Refresh();
            currentViewModel = previouspage;
        }
        public void SavePart()
        {
            CurrentPart.Status.UpdateStatus();
            CurrentPart.updatePart();
        }
    }
}
