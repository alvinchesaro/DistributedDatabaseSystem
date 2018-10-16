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

namespace ddbapplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSalesReport_Click(object sender, RoutedEventArgs e)
        {
            SalesReport salesReport = new SalesReport();
            salesReport.ShowDialog();
        }

        private void btnEmplocation_Click(object sender, RoutedEventArgs e)
        {
            Employees empReport = new Employees();
            empReport.ShowDialog();
        }

        private void btnCompinventory_Click(object sender, RoutedEventArgs e)
        {
            InventoryItems empReport = new InventoryItems();
            empReport.ShowDialog();
        }

        private void btnRevenue_Click(object sender, RoutedEventArgs e)
        {
            TotalRevenue empReport = new TotalRevenue();
            empReport.ShowDialog();
        }

        private void btnEmployeeSales_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSales empReport = new EmployeeSales();
            empReport.ShowDialog();
        }
    }
}
