using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUnityPlayer.Objects.Utils;

namespace WPFUnityPlayer.Objects.Object.Interface
{
    public interface ITransform
    {
        Vector3 Position { get; set; }
        float Width { get; set; }
        float Height { get; set; }
        Dictionary<string, Vector2> Anchors { get; set; }
        Vector2 Pivot { get; set; }
        Vector3 Rotation { get; set; }
        Vector3 Scale { get; set; }
    }
}
