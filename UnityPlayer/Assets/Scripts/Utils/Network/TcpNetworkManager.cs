using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityPlayer.Utils.Network
{

    using WPFUnityPlayer.Objects.Network.Packet;

    public class TcpNetworkManager : MonoBehaviour
    {
        public delegate PacketBase ReceivingCallback(object result);
        public ReceivingCallback Callback { get; set; }

        //// Start is called before the first frame update
        //void Start()
        //{

        //}

        //// Update is called once per frame
        //void Update()
        //{

        //}
    }

}
