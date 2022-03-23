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
    /// Логика взаимодействия для AddDataTable.xaml
    /// </summary>
    public partial class AddDataTable : Window
    {
        HOTELSEntities10 context;
        public AddDataTable(HOTELSEntities10 context, Сводная_таблица newСводная_таблица)
        {
            InitializeComponent();
            this.context = context;
            Cmb.ItemsSource = context.Номера.ToList();
            Cmbb.ItemsSource= context.Клиенты.ToList();
            Cmbbbbb.ItemsSource = context.Дополнительное_обслуживание.ToList();
            this.DataContext = newСводная_таблица;
        }

        private void BtnSav_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            this.Close();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
