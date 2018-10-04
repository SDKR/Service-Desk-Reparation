using ServiceDesk_Reperation.View;
using ServiceDesk_Reperation.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ServiceDesk_Reperation.ViewModel
{
    class PageChanger:ObservableObject
    {
        private Page _currentViewModel;


        private string _hallo;

        public string hallo
        {
            get { return _hallo; }
            set
            {
                _hallo = value;
                OnPropertyChanged("hallo");
            }
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

        public PageChanger()
        {
            this.currentViewModel = new StartPage();
            this.PageCommand = new Command(this);
            this.BackCommand = new PageCommand(this);
            this.PageAccept = new PageCommand(this);
            hallo = "hhhr";
        }

        public void ChangePageMethod()
        {
            previouspage = currentViewModel;
            currentViewModel = new OpretReparation();
        }
        public void ChangebackMethod()
        {
            currentViewModel = previouspage;
            hallo = "halløj";
        }

        public void ShowRepairList()
        {
            currentViewModel = new KoibAccept();
        }
    }
}
