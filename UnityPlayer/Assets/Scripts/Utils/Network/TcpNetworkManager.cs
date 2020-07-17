using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;


namespace UnityPlayer.Utils.Network
{
    using WPFUnityPlayer.Objects.Delegate;
    using WPFUnityPlayer.Objects.Network;

    public class TcpNetworkManager : MonoBehaviour
    {
        public ReceivingCallback Callback { get; set; }


        private GUIStyle logStyle;
        public string Log { get; set; } = "";

        private GUIStyle errorLogStyle;
        public string ErrorLog { get; set; } = "";

        private IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(TcpNetworkConstants.IP), TcpNetworkConstants.Port);
        private TcpListener listener;

        void Start()
        {
            Debug.Log("Run Tcp Networking ....");

            logStyle = new GUIStyle();
            logStyle.fontSize = 20;

            errorLogStyle = new GUIStyle();
            errorLogStyle.fontSize = 30;

            listener = new TcpListener(ipEndPoint);
            listener.Start();

            CheckingListenerAsync();
        }

        private async void CheckingListenerAsync()
        {
            await Task.Run(() => 
            {
                while (true)
                {
                    Log = "Waiting....";
                    TcpClient client = listener.AcceptTcpClient();

                    Log = "Connected..";

                    NetworkStream nStream = client.GetStream();
                    if (nStream.CanRead)
                    {
                        BinaryFormatter bFormatter = new BinaryFormatter();

                        Dispatcher.Invoke(() =>
                        {
                            object receiveData = Callback.Invoke(bFormatter.Deserialize(nStream));
                            if (receiveData != null)
                            {
                                bFormatter.Serialize(nStream, receiveData);
                            }
                        });

                        nStream.Close();
                        client.Close();

                        Thread.Sleep(16);
                    }
                }
            });
        }
        private void OnGUI()
        {
            GUI.Label(new Rect(50, 200, 150, 50), ErrorLog, errorLogStyle);
            GUI.Label(new Rect(50, 50, 150, 50), Log, logStyle);
        }
    }

}
