﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk_Reperation.ViewModel.Pages
{
    class SendUpdateMethods : Navigator
    {
        private PageChanger PageChanger { get; set; }

        public SendUpdateMethods(PageChanger pageChanger)
        {
            PageChanger = pageChanger;
        }
    }
}