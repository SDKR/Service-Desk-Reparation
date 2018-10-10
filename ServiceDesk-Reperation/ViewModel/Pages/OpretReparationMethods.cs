using ServiceDesk_Reperation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceDesk_Reperation.ViewModel.Pages
{
    class OpretReparationMethods : ObservableObject
    {
        private PageChanger PageChanger { get; set; }
        private List<CaseStatus> _StatusList;
        private string _SaveBtnTxt;

        public string SaveBtnTxt
        {
            get { return _SaveBtnTxt; }
            set { _SaveBtnTxt = value;
                RaisePropertyChangedEvent("SaveBtnTxt");
            }
        }

        private Visibility visibility;

        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
                visibility = value;
                RaisePropertyChangedEvent("Visibility");
            }
        }

        public List<CaseStatus> StatusList
        {
            get { return _StatusList; }
            set { _StatusList = value; }
        }

        public OpretReparationMethods(PageChanger pageChanger)
        {
            PageChanger = pageChanger;
            StatusList = new List<CaseStatus>();
            for (int i = 1; i < 7; i++)
            {
                StatusList.Add(new CaseStatus(i));
            }
        }
        public void DeleteCase()
        {
            bool WarningBox = PageChanger.DialogBox("Vil du slette ?", "Warning", MessageBoxButton.YesNo);
            if (WarningBox)
            {
                PageChanger.StartPageMethods.CurrentCase.deleteCase();
                PageChanger.StartPageMethods.Cases.Remove(PageChanger.StartPageMethods.CurrentCase);
                PageChanger.ChangePageTo("StartPage");
            }
        }
        public void SaveCase()
        {
            if (Visibility == Visibility.Hidden)
            {
                PageChanger.StartPageMethods.CurrentCase.createCase();
                PageChanger.StartPageMethods.CurrentCase.Refresh();
                PageChanger.StartPageMethods.Cases.Add(PageChanger.StartPageMethods.CurrentCase);
            }
            else
            {
                PageChanger.StartPageMethods.CurrentCase.updateCase();
                PageChanger.StartPageMethods.CurrentCase.Refresh();
            }
            bool WarningBox = PageChanger.DialogBox("Det er nu blevet gemt!", "Information", MessageBoxButton.OK);
            PageChanger.ChangePageTo("StartPage");
        }
        public void ShowAccepts()
        {
            PageChanger.ChangeOfBuyMethods.Visibility = Visibility.Visible;
            PageChanger.StartPageMethods.CurrentCase.GetParts();
            PageChanger.ChangeOfBuyMethods.CurrentPart = new Part();
            PageChanger.ChangePageTo("ChangeOfBuy");
        }
        public void GoBack()
        {
            PageChanger.ChangePageTo("StartPage");
        }
    }
}
