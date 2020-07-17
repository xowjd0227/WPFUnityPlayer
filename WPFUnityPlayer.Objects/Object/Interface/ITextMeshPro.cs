using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUnityPlayer.Objects.Object.Interface
{
    public interface ITextMeshPro
    {
        string Text { get; set; }
        
        bool Bold { get; set; }
        bool Italic { get; set; }
    }
}
