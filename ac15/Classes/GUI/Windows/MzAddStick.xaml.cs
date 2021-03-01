using System;
using System.Collections.Generic;
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

// объявим делегат:
public delegate void MzAddStickDelegate();

namespace DDECAD.MZ.Classes.GUI.Windows
{
    /// <summary>
    /// Interaction logic for MzAddStick.xaml
    /// </summary>
    public partial class MzAddStick : UserControl
    {
        // объявление события:
        public event MzAddStickDelegate EventAddStick;

        public MzAddStick()
        {
            InitializeComponent();
        }

        // Метод для вызова самого события (имя прописать в XAML кнопки Click="<метод>"
        private  void ButtonAddStick_Click(object sender, RoutedEventArgs e)
        {
            if (EventAddStick != null)
            {
                EventAddStick();
            }
        }
    }
}
