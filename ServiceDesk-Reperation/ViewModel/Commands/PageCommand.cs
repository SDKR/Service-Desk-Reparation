using System;
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
                string[] vs = para.Split('.');
                if (vs[0] == "StartPage")
                    ViewModel.StartPageMethods.GetType().GetMethod(vs[1]).Invoke(ViewModel.StartPageMethods, null);
                else if (vs[0] == "OpretReparation")
                    ViewModel.OpretReparationMethods.GetType().GetMethod(vs[1]).Invoke(ViewModel.OpretReparationMethods, null);
                else if (vs[0] == "ChangeOfBuy")
                    ViewModel.ChangeOfBuyMethods.GetType().GetMethod(vs[1]).Invoke(ViewModel.ChangeOfBuyMethods, null);
                else if (vs[0] == "SendUpdate")
                    ViewModel.SendUpdateMethods.GetType().GetMethod(vs[1]).Invoke(ViewModel.SendUpdateMethods, null);
        }
    }
}
