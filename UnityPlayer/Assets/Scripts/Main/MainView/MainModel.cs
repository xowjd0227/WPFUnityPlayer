using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace UnityPlayer.Main
{
    public class MainModel
    {
        public delegate void OnPropertyChanged(string key, object value);
        public event OnPropertyChanged PropertyChanged;
    }
}

