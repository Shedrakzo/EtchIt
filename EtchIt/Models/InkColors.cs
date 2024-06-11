using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using Color = System.Windows.Media.Color;

namespace EtchIt.Models
{
    class InkColors
    {
        private InkCanvas _inkCanvas;

        public InkColors(InkCanvas inkCanvas)
        {
            _inkCanvas = inkCanvas;
        }

        public void SetInkColor(Color color)
        {
            _inkCanvas.DefaultDrawingAttributes.Color = color;
        }

        public Color GetCurrentInkColor()
        {
            return _inkCanvas.DefaultDrawingAttributes.Color;
        }
    }
}
