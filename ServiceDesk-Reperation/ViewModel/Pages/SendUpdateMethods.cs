using ServiceDesk_Reperation.DBConnect;

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

        public void GemUpdate()
        {
            Mail mail = new Mail();
            string emne = PageChanger.StartPageMethods.CurrentCase.ID.ToString();
            string email = PageChanger.StartPageMethods.CurrentCase.Customer.Email;
            string person = PageChanger.StartPageMethods.CurrentCase.Customer.Name;
            mail.SendMail($"Opdatering på sag: {emne}", PageChanger.StartPageMethods.CurrentCase, Update, email, person);

            PageChanger.ChangePageTo("ChangeOfBuy");

        }

        private string _update;

        public string Update
        {
            get { return _update; }
            set { _update = value;
                RaisePropertyChangedEvent("Update");
            }
        }


    }
}
