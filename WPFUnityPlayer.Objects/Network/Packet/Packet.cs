using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUnityPlayer.Objects.Network.Packet
{
    [Obsolete("Starting Test .. / Not Used")]
    [Serializable]
    public class Packet : PacketBase
    {
        public string Content { get; set; }
        public CommunicationType CommunicationType { get; set; }
    }
}
