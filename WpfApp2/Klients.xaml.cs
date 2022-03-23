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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Klients.xaml
    /// </summary>
    public partial class Klients : Window
    {
        string currentLetter = "";
        HOTELSEntities10 context;
        public Klients()
        {
            InitializeComponent();
            context = new HOTELSEntities10();
            ShowTable();
            ShowLetters();
        }

        private void ShowLetters()
        {
            for (char i = 'А'; i <= 'Я'; i++)
            {
                TextBlock letter = new TextBlock
                {
                    Text = i.ToString(),
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.Black,
                    Margin = new Thickness(10, 1, 5, 1)
                };
                letter.MouseLeftButtonDown += TextBlock_MouseLeftButtonDown;
                StackLetters.Children.Add(letter);
            }
        }

        private void ShowTable()
        {
            if (TxtEmail.Text == null && TxtPhone.Text == null)
                return;
            List<Клиенты> listClient = context.Клиенты.ToList();
            listClient = listClient.Where(x => x.Фамилия.ToLower().Contains(TxtEmail.Text.ToLower())).ToList();
            listClient = listClient.Where(x => x.Имя.ToLower().Contains(TxtPhone.Text.ToLower())).ToList();
            if (currentLetter.Count() == 1)
            {
                listClient = listClient.Where(x => x.Фамилия.Contains(currentLetter)).ToList();
            }
            DataGridКлиент.ItemsSource = listClient.OrderBy(x => x.Фамилия).ToList();
        }

        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            var NewClientService = new Клиенты();
            context.Клиенты.Add(NewClientService);
            var BtnAddData = new addKlient(context, NewClientService);
            BtnAddData.ShowDialog();
        }

        private void DataDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentClientService = DataGridКлиент.SelectedItem as Клиенты;
            if (currentClientService == null)
            {
                MessageBox.Show("");
                return;

            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Клиенты.Remove(currentClientService);
                context.SaveChanges();
                ShowTable();
            }
        }
    

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentCar = BtnEdit.DataContext as Клиенты;
            var EdiWindow = new addKlient(context, currentCar);
            EdiWindow.ShowDialog();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var label = (TextBlock)sender;
            currentLetter = label.Text;
            foreach (TextBlock letter in StackLetters.Children)
            {
                letter.Foreground = Brushes.Black;
            }
            label.Foreground = Brushes.Red;
            ShowTable();
        }

        private void TxtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();

        }

        private void TxtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();

        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteClientS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClients_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void TxtEmail_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }

        private void TxtPhone_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }

        private void BtnAddClient_Click_1(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentCar = BtnEdit.DataContext as Клиенты;
            var EdiWindow = new addKlient(context, currentCar);
            EdiWindow.ShowDialog();
        }

        private void BtnDeleteClientS_Click_1(object sender, RoutedEventArgs e)
        {
            var currentClientService = DataGridКлиент.SelectedItem as Клиенты;
            if (currentClientService == null)
            {
                MessageBox.Show("");
                return;

            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Клиенты.Remove(currentClientService);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnClients_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
