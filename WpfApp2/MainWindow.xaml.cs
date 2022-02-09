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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HOTELSEntities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new HOTELSEntities();
            ShowTable();
        }

        private void ShowTable()
        {
            DataGridСводнаятаблица.ItemsSource = context.Сводная_таблица.ToList();
        }

        private void AddData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
