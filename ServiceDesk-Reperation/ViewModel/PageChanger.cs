using ServiceDesk_Reperation.DBConnect;
using ServiceDesk_Reperation.Model;
using ServiceDesk_Reperation.View;
using ServiceDesk_Reperation.ViewModel.Commands;
using ServiceDesk_Reperation.ViewModel.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ServiceDesk_Reperation.ViewModel
{
    class PageChanger : Navigator
    {
        public StartPageMethods StartPageMethods { get; set; }
        public ChangeOfBuyMethods ChangeOfBuyMethods { get; set; }
        public OpretReparationMethods OpretReparationMethods { get; set; }
        public SendUpdateMethods SendUpdateMethods { get; set; }
        public PartsDataGridCommand PartsDataGridCommand { get; set; }
        public PageCommand StandardCommand { get; set; }
        public DataGridCommand DataGridCommand { get; set; }
        public ValidationCommand ValidationCommand { get; set; }

        public PageChanger()
        {
            this.DB = new DBObject();
            this.StandardCommand = new PageCommand(this);
            this.DataGridCommand = new DataGridCommand(this);
            this.PartsDataGridCommand = new PartsDataGridCommand(this);
            this.ValidationCommand = new ValidationCommand(this);
            this.StartPageMethods = new StartPageMethods(this);
            this.ChangeOfBuyMethods = new ChangeOfBuyMethods(this);
            this.OpretReparationMethods = new OpretReparationMethods(this);
            this.SendUpdateMethods = new SendUpdateMethods(this);
        }
        public bool DialogBox(string msgtxt, string txt, MessageBoxButton button)
        {
            MessageBoxResult result = MessageBox.Show(msgtxt, txt, button);
            bool value;
            switch (result)
            {
                case MessageBoxResult.Yes:
                    value = true;
                    break;
                case MessageBoxResult.No:
                    value = false;
                    break;
                case MessageBoxResult.OK:
                    value = true;
                    break;
                default:
                    value = false;
                    break;
            }
            return value;
        }
    }
}
