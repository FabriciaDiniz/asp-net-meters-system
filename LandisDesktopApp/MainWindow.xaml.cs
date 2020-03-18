using LandisDesktopApp.Models;
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

namespace LandisDesktopApp
{
    /// <summary>
    /// Lógica interna para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PostgreSQL pgSql = new PostgreSQL();
        public List<Meter> Meters { get; set; }

        public MainWindow()
        {  
            Meters = pgSql.GetAllMeters();
            this.DataContext = this;

            InitializeComponent();
        }

        public void Meter_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Meter clicked");
        }
    }
}
