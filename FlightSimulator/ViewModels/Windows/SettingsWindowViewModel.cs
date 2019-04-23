﻿using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlightSimulator.ViewModels.Windows
{
    public class SettingsWindowViewModel : BaseNotify
    {
        private ISettingsModel model;
        public Action CloseAction { get; set; }

        public SettingsWindowViewModel(ISettingsModel model)
        {
            this.model = model;
        }

        public string FlightServerIP
        {
            get { return model.FlightServerIP; }
            set
            {
                model.FlightServerIP = value;
                NotifyPropertyChanged("FlightServerIP");
            }
        }

        public int FlightCommandPort
        {
            get { return model.FlightCommandPort; }
            set
            {
                model.FlightCommandPort = value;
                NotifyPropertyChanged("FlightCommandPort");
            }
        }

        public int FlightInfoPort
        {
            get { return model.FlightInfoPort; }
            set
            {
                model.FlightInfoPort = value;
                NotifyPropertyChanged("FlightInfoPort");
            }
        }

     

        public void SaveSettings()
       {
         model.SaveSettings();
      }

        public void ReloadSettings()
        {
            model.ReloadSettings();
        }

        #region Commands
        #region OkCommand
        private ICommand _okCommand;
        public ICommand OkCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler(() => OkClick()));
            }
        }
        private void OkClick()
        {
            //the OK button - save the new data in the file and close the view window
            model.SaveSettings();
            CloseAction();
        }
        #endregion

        #region CancelCommand
        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                
               return _cancelCommand ?? (_cancelCommand = new CommandHandler(() => OnCancel()));
                
            }
        }
        private void OnCancel()
        {
            //the cancle button - reload the data from the file and close the view window
            model.ReloadSettings();
            CloseAction();
        }
        #endregion
        #endregion
    }
}

