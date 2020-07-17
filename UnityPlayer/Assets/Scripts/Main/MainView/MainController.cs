using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityPlayer.Main
{
    public class MainController
    {
        public MainModel Model { get; private set; }
        public MainView View { get; private set; }

        public MainController(MainView view, MainModel model)
        {
            this.View = view;
            this.Model = model;

            model.PropertyChanged += OnPropertyChanged;
        }

        protected virtual void OnPropertyChanged(string key, object value)
        {
        }
    }
}

