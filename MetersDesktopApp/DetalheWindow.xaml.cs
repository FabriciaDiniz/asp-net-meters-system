using MetersDesktopApp.Models;
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
using System.Windows.Shapes;

namespace MetersDesktopApp
{
    /// <summary>
    /// Lógica interna para MainWindow.xaml
    /// </summary>
    public partial class DetalheWindow : Window
    {
        public Meter Meter { get; set; }
        public DetalheWindow(Meter meter)
        {
            this.Meter = meter;
            this.DataContext = Meter;

            InitializeComponent();
        }
    }
}
