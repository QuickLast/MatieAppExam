using MatieAppExam.DB;
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

namespace MatieAppExam.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            ServiceCosplayLV.ItemsSource = App.db.Service.Where(x => x.Name.StartsWith("Создание косп")).ToList();
            ServiceCustomLV.ItemsSource = App.db.Service.Where(x => x.Name.StartsWith("Кастомиз")).ToList();
        }

        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = ServiceTabCtrl.SelectedItem as TabItem;
            List<Service> services;
            if (tabItem.Header.ToString() == "Косплей")
            {
                services = App.db.Service.Where(x => x.Name.StartsWith("Создание косп")).ToList();
                ServiceCosplayLV.ItemsSource = services.OrderByDescending(x => x.Name).ToList();
            }
            else if (tabItem.Header.ToString() == "Кастом")
            {
                services = App.db.Service.Where(x => x.Name.StartsWith("Кастомиз")).ToList();
                ServiceCustomLV.ItemsSource = services.OrderByDescending(x => x.Name).ToList();
            }

        }
    }
}
