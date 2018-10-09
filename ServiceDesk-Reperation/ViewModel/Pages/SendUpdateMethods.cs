using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk_Reperation.ViewModel.Pages
{
    class SendUpdateMethods : ObservableObject
    {
        private PageChanger PageChanger { get; set; }

        public SendUpdateMethods(PageChanger pageChanger)
        {
            PageChanger = pageChanger;
        }

        public void GoBack()
        {
            PageChanger.StartPageMethods.CurrentCase.GetParts();
            PageChanger.ChangePageTo("ChangeOfBuy");
        }

    }
}
