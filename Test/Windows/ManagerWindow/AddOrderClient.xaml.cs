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
using Test.UserService;

namespace Test.Windows.ManagerWindow
{
    /// <summary>
    /// Логика взаимодействия для AddOrderClient.xaml
    /// </summary>
    public partial class AddOrderClient : Window
    {
        public AddOrderClient()
        {
            InitializeComponent();
        }

        private void cb_masters_Loaded(object sender, RoutedEventArgs e)
        {
            ManagerService managerService = new ManagerService();
            cb_masters.ItemsSource = managerService.LoadMaster();

        }

        private void btn_add_order_client_Click(object sender, RoutedEventArgs e)
        {

            if(string.IsNullOrEmpty(tb_fullname_client.Text) || string.IsNullOrEmpty(tb_device_client.Text) || string.IsNullOrEmpty(tb_phone_client.Text) || string.IsNullOrEmpty(tb_problem_client.Text))
            {
                MessageBox.Show("Вы не заполнили поле");
                return;
            }
            if (cb_masters.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали мастера");
                return;
            }
            else
            {
                
                ManagerService managerService = new ManagerService();
                var master = cb_masters.SelectedValue as string;
                managerService.AddOrderClient(tb_fullname_client.Text, tb_phone_client.Text, tb_device_client.Text, tb_problem_client.Text, master!);
                MessageBox.Show("Заказ добавлен");
                this.Close();
            }

        }
    }
}
