using ServiceDesk_Reperation.Model;
using System;
using System.Windows.Input;

namespace ServiceDesk_Reperation.ViewModel.Commands
{
    class DataGridCommand: ICommand
    {
        public PageChanger ViewModel { get; set; }


        public DataGridCommand(PageChanger viewModel)
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
            Case para = (Case)parameter;
            this.ViewModel.StartPageMethods.OpenCase(para);
        }
    }
}
