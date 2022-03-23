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
        HOTELSEntities10 context;
        string currentLetter = "";
        public MainWindow()
        {
            InitializeComponent();
            context = new HOTELSEntities10();
            ShowTable();

            ShowLetters();
        }

        private void ShowLetters()
        {
            
            
        }

        private void ShowTable()
        {

            DataGridСводнаятаблица.ItemsSource = context.Сводная_таблица.ToList();

        }

        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            var NewClientService = new Сводная_таблица();
            context.Сводная_таблица.Add(NewClientService);
            var BtnAddData = new AddDataTable(context, NewClientService);
            BtnAddData.ShowDialog();
        }

        private void DataDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentClientService = DataGridСводнаятаблица.SelectedItem as Сводная_таблица;
            if (currentClientService == null)
            {
                MessageBox.Show("");
                return;

            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Сводная_таблица.Remove(currentClientService);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentRental = BtnEdit.DataContext as Сводная_таблица;
            var EdiWindow = new AddDataTable(context, currentRental);
            EdiWindow.ShowDialog();
        }

        private void AddKlient_Click(object sender, RoutedEventArgs e)
        {
            var RentalSelect = new Klients();
            RentalSelect.ShowDialog();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void TxtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }



        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            var NewClientService = new Сводная_таблица();
            context.Сводная_таблица.Add(NewClientService);
            var BtnAddData = new AddDataTable(context, NewClientService);
            BtnAddData.ShowDialog();
        }

        private void BtnDeleteClientS_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BtnClients_Click(object sender, RoutedEventArgs e)
        {
            var RentalSelect = new Klients();
            RentalSelect.ShowDialog();
        }
    }
}
