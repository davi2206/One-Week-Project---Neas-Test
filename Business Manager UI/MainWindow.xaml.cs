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
                LogEvent(exc.Message, 4);
            }
        }

        private void Opdater_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                districts = ctrl.GetAllDistricts();
                dataGrid_Districts.ItemsSource = districts;
            }
            catch (Exception exc)
            {
                LogEvent(exc.Message, 3);
            }
        }

        private void AddSalesman_Click(object sender, RoutedEventArgs e)
        {
            //View al salesmen available
            AddOrRemoveSalesman a = new AddOrRemoveSalesman();
            a.Show();

            List<Salesman> salesmen = new List<Salesman>();
            string one = "Get all the available salesmen: SELECT Salesmen.Id, Salesmen.Name FROM Salesmen INNER JOIN DistrictSalesman ON Salesmen.Id=Salesman_Id AND District_Id!='5' AND Manager='0';";
            string two = "Set new DistrictSalesman: INSERT INTO DistrictSalesman VALUES (<salesmanId>, <districtId>, <manager>);";
            string three = "If manager: UPDATE Districts SET Manager=<new manager id> WHERE Nr=<districtNr>" + 
                "UPDATE DistrictSalesman SET Manager=0 WHERE District_Id=<curent district> AND Salesman_Id!=<New manager id>";

            //Do all above in one method. Implement atomicity. All has to work or rollback al!!

            string addSalesman = "Tilføj sælger: Dropdownliste med alle tilgængelige sælgere" +
                                    "\n - Ikke ansvarlige (Manager) fra andre distrikter" +
                                    "\n - Ikke sælgere allerede tilknyttet distrikt" +
                                    "\n\n Gør sælger til ansvarlig (Manager) -> Erstatter nuværende ansvarlige";
            MessageBox.Show(addSalesman, "Tilgøj sælger", MessageBoxButton.YesNo);
        }

        private void RemoveSalesman_Click(object sender, RoutedEventArgs e)
        {
            string removeSalesman = "Fjern sælger: Dropdownliste med alle tilgængelige sælgere" +
                                    "\n - Ikke ansvarlige (Manager) fra distrikt" +
                                    "\n - Kun sælgere tilknyttet distrikt";
            MessageBox.Show(removeSalesman, "Fjern sælger", MessageBoxButton.OK);
        }

        private void dataGrid_Districts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                District selectedDistrict = (District)dataGrid_Districts.SelectedItem;
                string districtNr = selectedDistrict.Nr;

                District d = districts.First(x => x.Nr == districtNr);

                dataGrid_DistrictStores.ItemsSource = d.Stores;
                dataGrid_DistrictSalesmen.ItemsSource = d.Salesmen;
            }
            catch (Exception exc)
            {
                LogEvent(exc.Message, 3);
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
        }
    }
}
