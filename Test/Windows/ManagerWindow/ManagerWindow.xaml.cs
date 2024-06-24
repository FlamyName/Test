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
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddOrderClient addOrderClient = new AddOrderClient();
            addOrderClient.ShowDialog();
        }

        private void dg_list_orders_Loaded(object sender, RoutedEventArgs e)
        {
            ManagerService managerService = new ManagerService();
            dg_list_orders.ItemsSource = managerService.GetListOrders();
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            ManagerService managerService = new ManagerService();
            dg_list_orders.ItemsSource = managerService.GetListOrders();
        }

        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = sender as TextBox;
            ManagerService managerService = new ManagerService();
            
            if (text!.Text != "")
            {
                if(int.TryParse(text!.Text, out int value))
                {
                    dg_list_orders.ItemsSource = managerService.GetListOrders().Where(x => x.Id == value);

                }
            }
            else
            {
                dg_list_orders.ItemsSource = managerService.GetListOrders();
            }

        }
    }
}
