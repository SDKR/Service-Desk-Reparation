using ServiceDesk_Reperation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk_Reperation.ViewModel.Pages
{
    class StartPageMethods : ObservableObject
    {
        private PageChanger PageChanger { get; set; }
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


        public StartPageMethods(PageChanger pageChanger) 
        {
            PageChanger = pageChanger;
            DataSet ds = new DataSet();
            Cases = new ObservableCollection<Case>();
            ds = PageChanger.DB.Query("SELECT ID FROM sager");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Cases.Add(new Case(Convert.ToInt32(ds.Tables[0].Rows[i][0])));
            }
        }

        public void OpenCase(Case current)
        {
            PageChanger.OpretReparationMethods.Visibility = System.Windows.Visibility.Visible;
            PageChanger.OpretReparationMethods.SaveBtnTxt = "Gem";
            PageChanger.ValidationCommand.ErrorMessage = "";
            CurrentCase = current;
            PageChanger.ChangePageTo("OpretReparation");
        }

        public void CreateCase()
        {
            CurrentCase = new Case();
            PageChanger.OpretReparationMethods.Visibility = System.Windows.Visibility.Hidden;
            PageChanger.OpretReparationMethods.SaveBtnTxt = "Opret";
            PageChanger.ChangePageTo("OpretReparation");
        }
    }
}
