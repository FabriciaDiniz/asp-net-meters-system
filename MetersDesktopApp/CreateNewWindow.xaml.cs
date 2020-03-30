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
    public partial class CreateNewWindow : Window
    {
        public Meter meter = new Meter();
        public CreateNewWindow()
        {
            InitializeComponent();
        }

        public void Submit_Click(object sender, RoutedEventArgs e)
        {
            PostgreSQL pg = new PostgreSQL();

            this.meter.IdCp = cpTextBox.Text;
            this.meter.IdCs = csTextBox.Text;
            this.meter.IdTrafo = trafoTextBox.Text;

            try
            {
                pg.AddMeter(meter);
                DisplayMainWindow();
                this.Close();
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
                MessageBox.Show("Error when saving meter to database");
                DisplayMainWindow();
                this.Close();
            }
        }

        public void DisplayMainWindow()
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
