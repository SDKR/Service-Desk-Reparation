using ServiceDesk_Reperation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk_Reperation.ViewModel.Pages
{
    class ChangeOfBuyMethods : ObservableObject
    {
        private List<PartStatus> _partstatuslist;
        private PageChanger PageChanger { get; set; }

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
            CurrentPart = para;
            RaisePropertyChangedEvent("CurrentPart");
        }
        public void SavePart()
        {
            CurrentPart.Status.UpdateStatus();
            CurrentPart.updatePart();
        }
        public void ClearFields()
        {
            CurrentPart = new Part();
        }
        public void Create()
        {
            if (CurrentPart.Status.ID == 0)
            {
                CurrentPart.Status.ID = 1;
                CurrentPart.CaseID = PageChanger.StartPageMethods.CurrentCase.ID;
                CurrentPart.createPart();
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
