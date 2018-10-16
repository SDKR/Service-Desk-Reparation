using ServiceDesk_Reperation.DBConnect;
using ServiceDesk_Reperation.View;
using System.Windows.Controls;

namespace ServiceDesk_Reperation.ViewModel
{
    class Navigator : ObservableObject
    {
        public DBObject DB { get; set; }
        public ChangeOfBuy ChangeOfBuy { get; set; }
        public OpretReparation OpretReparation { get; set; }
        public SendUpdate SendUpdate { get; set; }
        public StartPage StartPage { get; set; }
        private Page _CurrentPage;
        public Page CurrentPage {
            get { return _CurrentPage; }
            set {
                _CurrentPage = value;
                OnPropertyChanged("CurrentPage");
            } }
        public Navigator()
        {
            DB = new DBObject();
            ChangeOfBuy = new ChangeOfBuy();
            OpretReparation = new OpretReparation();
            SendUpdate = new SendUpdate();
            StartPage = new StartPage();
            CurrentPage = StartPage;
        }

        public void ChangePageTo(string page)
        {
            var property = GetType().GetProperty(page);
            CurrentPage = property.GetValue(this, null) as Page;
        }
    }
}
