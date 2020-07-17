using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using WPFUnityPlayer.Objects.Delegate;
using WPFUnityPlayer.Objects.Network;
using WPFUnityPlayer.Objects.Network.Packet;
using WPFUnityPlayer.Utils.Pattern;

namespace WPFUnityPlayer.Utils.Network
{
    public class TcpNetworkManager : Singleton<TcpNetworkManager>
    {
        public ReceivingCallback Callback { get; set; }

        public void SendMessage(PacketBase data)
        {
            TcpClient client = new TcpClient(TcpNetworkConstants.IP, TcpNetworkConstants.Port);
            if (client.Connected)
            {
                NetworkStream nStream = client.GetStream();
                if (nStream.CanRead)
                {
                    BinaryFormatter bFormatter = new BinaryFormatter();
                    bFormatter.Serialize(nStream, data);

                    object callbackReceiveData = bFormatter.Deserialize(nStream);

                    if (callbackReceiveData != null)
                    {
                        PacketBase packetBase = callbackReceiveData as PacketBase;
                        if (packetBase?.PacketDataType == PacketDataType.Receive)
                        {
                            Callback?.Invoke(packetBase);
                        }
                    }

                    nStream.Close();
                    client.Close();
                }
            }
        }
    }
}
