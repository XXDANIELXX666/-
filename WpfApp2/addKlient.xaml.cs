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
    /// Логика взаимодействия для addKlient.xaml
    /// </summary>
    public partial class addKlient : Window
    {
        HOTELSEntities10 context;
        public addKlient(HOTELSEntities10 context, Клиенты newклиенты)
        {
            InitializeComponent();
            this.context = context;
            Cmbb.ItemsSource = context.Gender.ToList();
            this.DataContext = newклиенты;

        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void BtnSav_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            this.Close();
        }
    }
}
