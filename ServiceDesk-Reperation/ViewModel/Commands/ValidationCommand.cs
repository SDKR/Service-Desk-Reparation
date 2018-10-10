using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ServiceDesk_Reperation.ViewModel.Commands
{
    class ValidationCommand : ObservableObject, ICommand
    {
        public PageChanger ViewModel { get; set; }
        private string errormessage;

        public string ErrorMessage
        {
            get { return errormessage; }
            set { errormessage = value;
                RaisePropertyChangedEvent("ErrorMessage");
            }
            
        }


        public ValidationCommand(PageChanger viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            bool noget = true; 
            foreach (var item in CheckIfNull())
            {
                if (item)
                    noget = false;
            }
            if (!noget)
            {
                ErrorMessage = "Et eller flere felter mangler at blive udfyldt!";
                return noget;
            }           
            else if (!CheckZip())
            {
                ErrorMessage = "Du mangler at udfylde Postnr rigtigt!";
                return false;
            }
            else if (!CheckEmail())
            {
                ErrorMessage = "Du mangler at udfylde Email rigtigt!";
                return false;
            }
            else
            {
                ErrorMessage = "";
                return true;
            }
        }

        public bool[] CheckIfNull()
        {
            bool[] results = new bool[12];
            results[0] = string.IsNullOrWhiteSpace(ViewModel.StartPageMethods.CurrentCase.Customer.Name);
            results[1] = string.IsNullOrWhiteSpace(ViewModel.StartPageMethods.CurrentCase.Customer.Address);
            results[2] = string.IsNullOrWhiteSpace(ViewModel.StartPageMethods.CurrentCase.Customer.Telephone);
            results[3] = string.IsNullOrWhiteSpace(ViewModel.StartPageMethods.CurrentCase.Customer.Email);
            results[4] = string.IsNullOrWhiteSpace(ViewModel.StartPageMethods.CurrentCase.Description);
            results[5] = string.IsNullOrWhiteSpace(ViewModel.StartPageMethods.CurrentCase.PC.Manufacturer);
            results[6] = string.IsNullOrWhiteSpace(ViewModel.StartPageMethods.CurrentCase.PC.Model);
            results[7] = string.IsNullOrWhiteSpace(ViewModel.StartPageMethods.CurrentCase.PC.SerialNumber);
            results[8] = string.IsNullOrWhiteSpace(ViewModel.StartPageMethods.CurrentCase.PC.OS);
            results[9] = string.IsNullOrWhiteSpace(ViewModel.StartPageMethods.CurrentCase.PC.CPU);
            results[10] = string.IsNullOrWhiteSpace(ViewModel.StartPageMethods.CurrentCase.PC.RAM);
            results[11] = string.IsNullOrWhiteSpace(ViewModel.StartPageMethods.CurrentCase.PC.Storage);
            return results;
        }
        public bool CheckZip()
        {
            ViewModel.StartPageMethods.CurrentCase.Customer.ZipCode.GetCity();
            if (ViewModel.StartPageMethods.CurrentCase.Customer.ZipCode.City != "Byen findes ikke")
                return true;
            else
                return false;
        }
        public bool CheckEmail()
        {
            return ViewModel.StartPageMethods.CurrentCase.Customer.Email.Contains("@");
        }

        public void Execute(object parameter) {
            if (CanExecute(parameter))
                RunCommand(parameter);
        }
        public void RunCommand(object parameter)
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
