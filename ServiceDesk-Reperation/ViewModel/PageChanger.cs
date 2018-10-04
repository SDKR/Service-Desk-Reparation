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

        public PageChanger()
        {
            this.currentViewModel = new StartPage();
            this.PageCommand = new Command(this);
            this.BackCommand = new PageCommand(this);
        }

        public void ChangePageMethod()
        {
            currentViewModel = new ChangeOfBuy();
        }
        public void ChangebackMethod()
        {
            currentViewModel = new StartPage();
        }
    }
}
