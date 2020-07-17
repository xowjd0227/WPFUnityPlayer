using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using UnityPlayer.Scripts.Main.Factory;
public class RootManager : MonoBehaviour
{
    //public GameObject uiParent;
    public List<RootManagerObject> uiRootObjects;
    void Start()
    {
        if (uiRootObjects != null)
        {
            new MainFactory().Load(uiRootObjects.Where(o => o.Name == "Main").FirstOrDefault().TargetRootObject);
        }
    }

}
