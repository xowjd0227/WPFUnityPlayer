using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityPlayer.Main;

namespace UnityPlayer.Scripts.Main.Factory
{
    public class MainFactory
    {
        public MainController MainController { get; private set; }
        public MainView MainView { get; private set; }
        public MainModel MainModel { get; private set; }

        public void Load(GameObject parentObject)
        {
            GameObject prefab = Resources.Load<GameObject>("Views/Main/MainView");
            GameObject instance = GameObject.Instantiate<GameObject>(prefab);

            this.MainModel = new MainModel();
            this.MainView = instance.GetComponent<MainView>();
            this.MainController = new MainController(this.MainView, this.MainModel);

            if (parentObject != null)
                instance.transform.SetParent(parentObject.transform);
        }

    }
}
