using ServiceDesk_Reperation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServiceDesk_Reperation.ViewModel.Commands
{
    class PartsDataGridCommand: ICommand
    {
        public PageChanger ViewModel { get; set; }


        public PartsDataGridCommand(PageChanger viewModel)
        {
            this.ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Part para = (Part)parameter;
            this.ViewModel.ChangeOfBuyMethods.ShowPart(para);
        }
    }
}
