using ServiceDesk_Reperation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk_Reperation.ViewModel.Pages
{
    class OpretReparationMethods : ObservableObject
    {
        private PageChanger PageChanger { get; set; }
        private List<CaseStatus> _StatusList;

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

        public void SaveCase()
        {
            PageChanger.StartPageMethods.CurrentCase.updateCase();
            PageChanger.StartPageMethods.CurrentCase.Refresh();
            PageChanger.ChangePageTo("StartPage");
        }
        public void DeleteCase()
        {
            PageChanger.StartPageMethods.CurrentCase.deleteCase();
            PageChanger.StartPageMethods.Cases.Remove(PageChanger.StartPageMethods.CurrentCase);
        }

        public void ShowAccepts()
        {
            PageChanger.StartPageMethods.CurrentCase.GetParts();
            PageChanger.ChangePageTo("ChangeOfBuy");
        }
        public void GoBack()
        {
            PageChanger.ChangePageTo("StartPage");
        }
    }
}
