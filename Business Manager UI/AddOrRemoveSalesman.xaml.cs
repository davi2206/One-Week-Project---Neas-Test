using Business_Manager_UI.Controllers;
using Business_Manager_UI.Models;
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

namespace Business_Manager_UI
{
    /// <summary>
    /// Interaction logic for AddOrRemoveSalesman.xaml
    /// </summary>
    public partial class AddOrRemoveSalesman : Window
    {
        Controller ctrl = new Controller();

        public AddOrRemoveSalesman(string excludeDistrict)
        {
            InitializeComponent();
            ExcludeDistrict = excludeDistrict;
        }

        public string ExcludeDistrict { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Salesman> availableSalesmen = ctrl.GetAvailableSalesmen(ExcludeDistrict);
            Salesmen.ItemsSource = availableSalesmen;
        }

        private void Salesmen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SaveSalesman.IsEnabled = true;
        }

        private void SaveSalesman_Click(object sender, RoutedEventArgs e)
        {
            API_Controller api = new API_Controller();

            string districtNr = ExcludeDistrict;
            Salesman salesman = (Salesman) Salesmen.SelectedItem;
            string salesmanId = salesman.Id;
            bool? manager = Manager.IsChecked;

            ctrl.UpdateDistrict(districtNr, salesmanId, manager);
        }
    }
}
