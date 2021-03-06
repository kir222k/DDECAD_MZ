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
public delegate void MzAddStickDoneEventHandler();

namespace DDECAD.MZ.Classes.GUI.Windows
{
    /// <summary>
    /// Interaction logic for MzAddStickControl.xaml
    /// </summary>
    public partial class MzAddStickControl : UserControl
    {
        // объявление события:
        public event MzAddStickDoneEventHandler MzAddStickDoneEvent;

        public MzAddStickControl()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            MzAddStickDoneEvent?.Invoke();
        }
    }
}
