using Business_Manager_UI.Controllers;
using Business_Manager_UI.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Business_Manager_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<District> districts;
        Controller ctrl;

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                districts = new List<District>();
                ctrl = new Controller();
            }
            catch (Exception exc)
            {
                LogEvent(exc.StackTrace, 4);
            }
        }

        public string DistrictNr { get; set; }

        private void Opdater_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                districts = ctrl.GetAllDistricts();
                dataGrid_Districts.ItemsSource = districts;
            }
            catch (Exception exc)
            {
                LogEvent(exc.StackTrace, 3);
            }
        }

        private void AddSalesman_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Salesman> list = new List<Salesman>();
                AddOrRemoveSalesman newWindow = new AddOrRemoveSalesman(DistrictNr, list);
                newWindow.Show();
            }
            catch (Exception exc)
            {
                LogEvent(exc.StackTrace, 3);
            }
        }

        private void RemoveSalesman_Click(object sender, RoutedEventArgs e)
        {
            string removeSalesman = "Fjern sælger: Dropdownliste med alle sælgere i distrikt" +
                                    "\n - Ikke ansvarlige (Manager) fra distrikt" +
                                    "\n - Kun sælgere tilknyttet distrikt";
            MessageBox.Show(removeSalesman, "Fjern sælger", MessageBoxButton.OK);
        }

        private void dataGrid_Districts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<object> empty = new List<object>();
            AddSalesman.IsEnabled = true;
            RemoveSalesman.IsEnabled = true;

            try
            {
                District selectedDistrict = (District)dataGrid_Districts.SelectedItem;

                if(selectedDistrict != null)
                {
                    DistrictNr = selectedDistrict.Nr;

                    District d = districts.First(x => x.Nr == DistrictNr);

                    dataGrid_DistrictStores.ItemsSource = d.Stores;
                    dataGrid_DistrictSalesmen.ItemsSource = d.Salesmen;
                }
                else
                {
                    dataGrid_DistrictStores.ItemsSource = empty;
                    dataGrid_DistrictSalesmen.ItemsSource = empty;
                }
            }
            catch (Exception exc)
            {
                LogEvent(exc.StackTrace, 3);
            }
        }

        /// <summary>
        /// Logging errors and information to a logfile
        /// </summary>
        /// <param name="logEvent">The event to be logged</param>
        /// <param name="logLevel">
        /// The level of the log:
        /// 0: Info
        /// 1: Debug
        /// 2: Warning
        /// 3: Error
        /// 4: Fatal
        /// </param>
        private void LogEvent(string logEvent, int logLevel = 0)
        {
            string level = "";

            switch (logLevel)
            {
                case 0:
                    level = "Info";
                    break;
                case 1:
                    level = "Debug";
                    break;
                case 2:
                    level = "Warning";
                    break;
                case 3:
                    level = "Error";
                    break;
                case 4:
                    level = "FATAL";
                    break;
                default:
                    level = "Unknown";
                    break;
            }

            string timestamp = DateTime.Now.ToShortTimeString();

            string logMessage = string.Format("[{0} - {1}]: {2}", timestamp, level, logEvent);

            string path = AppDomain.CurrentDomain.BaseDirectory + "\\LogBMUI.txt";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
            {
                file.WriteLine(logMessage);
            }

            MessageBox.Show(logMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
