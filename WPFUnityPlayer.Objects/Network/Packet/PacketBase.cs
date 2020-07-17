using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUnityPlayer.Objects.Network.Packet
{
    [Serializable]
    public class PacketBase
    {
        public PacketDataType PacketDataType { get; set; }
    }
}
