﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FundManager.Model
{
    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            if (Equals(member, val)) return;
            member = val;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
