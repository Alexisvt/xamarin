﻿using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace XamlSamples
{
    public class ClockViewModel : INotifyPropertyChanged
    {
        DateTime _dateTime;

        public event PropertyChangedEventHandler PropertyChanged;

        public ClockViewModel()
        {
            this.DateTime = DateTime.Now;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                this.DateTime = DateTime.Now;
                return true;
            });
        }

        public DateTime DateTime {
            get
            {
                return _dateTime;
            }

            set
            {
                if (_dateTime != value)
                {
                    _dateTime = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
                    }
                }
            }
        }
    }
}