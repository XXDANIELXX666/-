﻿using System;
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
        HOTELSEntities4 context;
        public MainWindow()
        {
            InitializeComponent();
            context = new HOTELSEntities4();
            ShowTable();
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
    }
}
