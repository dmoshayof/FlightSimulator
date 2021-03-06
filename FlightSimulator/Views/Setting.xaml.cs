﻿using FlightSimulator.Model;
using FlightSimulator.ViewModels.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        public SettingsWindowViewModel vm { get; }
        
        public Setting()
        {
            InitializeComponent();
            vm = new SettingsWindowViewModel(new ApplicationSettingsModel());
            DataContext = vm;
            //function for closing the view from the view model class.
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());
        }
    }
}
