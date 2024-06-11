using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;

namespace EtchIt.Models
{
    class InkSize
    {
        private InkCanvas _inkCanvas;

        public InkSize(InkCanvas inkCanvas)
        {
            _inkCanvas = inkCanvas;
        }

        //Creates a brush size function
        public void SetSize(double size)
        {
            if (_inkCanvas != null)
            {
                DrawingAttributes drawingAttributes = _inkCanvas.DefaultDrawingAttributes;

                drawingAttributes.StylusTip = StylusTip.Ellipse;
                drawingAttributes.Width = size;
                drawingAttributes.Height = size;
            }
        }
    }
}
