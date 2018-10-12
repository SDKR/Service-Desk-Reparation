using ServiceDesk_Reperation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceDesk_Reperation.ViewModel.Pages
{
    class ChangeOfBuyMethods : ObservableObject
    {
        private List<PartStatus> _partstatuslist;
        private PageChanger PageChanger { get; set; }
        private Visibility visibility;

        public Visibility Visibility
        {
            get { return visibility; }
            set { visibility = value;
                RaisePropertyChangedEvent("Visibility");
                RaisePropertyChangedEvent("InverseVisibility");
            }
        }

        public Visibility InverseVisibility
        {
            get {
                if(visibility.Equals(Visibility.Hidden))
                return Visibility.Visible;
                else
                return Visibility.Hidden;
            }
            set
            {
                if (value.Equals(Visibility.Hidden))
                    visibility = Visibility.Visible;
                else
                 visibility = Visibility.Hidden;
                 RaisePropertyChangedEvent("Visibility");
                 RaisePropertyChangedEvent("InverseVisibility");
            }
        }


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




        public ChangeOfBuyMethods(PageChanger pageChanger)
        {
            Visibility = Visibility.Visible;
            PageChanger = pageChanger;
            PartStatusList = new List<PartStatus>();
            for (int i = 1; i < 5; i++)
            {
                PartStatusList.Add(new PartStatus(i));
            }
        }

        public void Close()
        {
            PageChanger.ChangePageTo("OpretReparation");
        }
        public void ShowPart(Part para)
        {
            Visibility = Visibility.Hidden;
            CurrentPart = para;
            RaisePropertyChangedEvent("CurrentPart");
        }
        public void SavePart()
        {
            bool WarningBox = PageChanger.DialogBox("Vil du updater delen?", "Warning", MessageBoxButton.YesNo);
            if (WarningBox)
            {
                CurrentPart.Status.UpdateStatus();
                CurrentPart.updatePart();
            }
        }
    public void DeletePart()
        {
            bool WarningBox = PageChanger.DialogBox("Vil du slette ?", "Warning", MessageBoxButton.YesNo);
            if (WarningBox)
            {
                CurrentPart.deletePart();
                PageChanger.StartPageMethods.CurrentCase.GetParts();
                ClearFields();
            }
        }
        public void ClearFields()
        {
            Visibility = Visibility.Visible;
            CurrentPart = new Part();
        }
        public void Create()
        {
            bool WarningBox = PageChanger.DialogBox("Vil du Oprette en ny del?", "Warning", MessageBoxButton.YesNo);
            if (WarningBox)
            {
                if (CurrentPart.Status.ID == 0)
                {
                    CurrentPart.Status.ID = 1;
                    CurrentPart.CaseID = PageChanger.StartPageMethods.CurrentCase.ID;
                    CurrentPart.createPart();
                    PageChanger.StartPageMethods.CurrentCase.GetParts();
                }
            }
        }
        public void GoBack()
        {
            PageChanger.ChangePageTo("OpretReparation");
        }
        public void GoToSend()
        {
            PageChanger.ChangePageTo("SendUpdate");
        }
    }
}
