﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace UP_Luzin
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public int CurrentUserID { get; set; }

        public void SetCurrentUserID(int ID)
        {
            CurrentUserID = ID;
        }
    }
}