using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ServiceDesk_Reperation.ViewModel.Commands
{
    class PageCommand : ICommand
    {
        public PageChanger ViewModel { get; set; }


        public PageCommand(PageChanger viewModel)
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
            string para = (string)parameter;
            this.ViewModel.GetType().GetMethod(para).Invoke(ViewModel, null);
        }
    }
}
