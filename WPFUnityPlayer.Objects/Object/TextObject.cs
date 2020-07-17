using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUnityPlayer.Objects.Network.Packet;
using WPFUnityPlayer.Objects.Object.Interface;
using WPFUnityPlayer.Objects.Utils;

namespace WPFUnityPlayer.Objects.Object
{
    [Serializable]
    public class TextObject : PacketBase, ITransform
    {
        public Vector3 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Dictionary<string, Vector2> Anchors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 Pivot { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector3 Rotation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector3 Scale { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
