using EtchIt.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;
using UserControl = System.Windows.Controls.UserControl;
using Button = System.Windows.Controls.Button;

namespace EtchIt.Views
{
    /// <summary>
    /// Interaction logic for PaintView.xaml
    /// </summary>
    public partial class PaintView : UserControl
    {
        private InkColors _InkColors;
        private InkSize _InkSize;

        public PaintView()
        {
            InitializeComponent();
            _InkColors = new InkColors(InkSurface);
            _InkSize = new InkSize(InkSurface);
        }

        private void ChangeColor_onClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            string colorName = (string)clickedButton.Tag;

            Color color;

            //For any color tags that use hex colors
            if (colorName.StartsWith("#"))
            {
                color = (Color)ColorConverter.ConvertFromString(colorName);
            }

            //Otherwise it'll just go straight to standard colors
            else
            {
                switch (colorName)
                {
                    case "Red":
                        color = Colors.Red;
                        break;

                    case "Orange":
                        color = Colors.Orange;
                        break;

                    case "Yellow":
                        color = Colors.Yellow;
                        break;

                    case "ForestGreen":
                        color = Colors.ForestGreen;
                        break;

                    case "Blue":
                        color = Colors.Blue;
                        break;

                    case "DarkViolet":
                        color = Colors.DarkViolet;
                        break;

                    case "Magenta":
                        color = Colors.Magenta;
                        break;

                    case "DeepPink":
                        color = Colors.DeepPink;
                        break;

                    case "Cyan":
                        color = Colors.Cyan;
                        break;

                    case "Black":
                        color = Colors.Black;
                        break;

                    case "White":
                        color = Colors.White;
                        break;

                    default:
                        color = Colors.Black;
                        break;
                }
            }

           _InkColors.SetInkColor(color);
        }

        private void ColorDialogBox_onClick(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();


            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.Color selectedWinFormsColor = colorDialog.Color;
                System.Windows.Media.Color selectedWpfColor = System.Windows.Media.Color.FromArgb(
                    selectedWinFormsColor.A,
                    selectedWinFormsColor.R,
                    selectedWinFormsColor.G,
                    selectedWinFormsColor.B);

                SolidColorBrush brush = new SolidColorBrush(selectedWpfColor);

                //Sets the button background to the custom color
                (sender as Button).Background = brush;

                //Sets _InkColors to the custom color
                _InkColors.SetInkColor(selectedWpfColor);
            }
        }

        //Sets the brush size to 2 pixels
        private void BrushSizeSmall_onClick(object sender, RoutedEventArgs e)
        {
            _InkSize.SetSize(2.0);
        }

        //Sets the brush size to 10 pixels
        private void BrushSizeMid_onClick(object sender, RoutedEventArgs e)
        {
            _InkSize.SetSize(10.0);
        }

        //Sets the brush size to 20 pixels
        private void BrushSizeLarge_onClick(object sender, RoutedEventArgs e)
        {
            _InkSize.SetSize(20.0);
        }
    }
}
