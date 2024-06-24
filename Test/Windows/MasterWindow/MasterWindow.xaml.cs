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
using Test.DB.Models;
using Test.UserService;

namespace Test.Windows.MasterWindow
{
    /// <summary>
    /// Логика взаимодействия для MasterWindow.xaml
    /// </summary>
    public partial class MasterWindow : Window
    {
        public MasterWindow()
        {
            InitializeComponent();
        }

        private void lb_orders_master_Loaded(object sender, RoutedEventArgs e)
        {
            MasterService masterService = new MasterService();
            lb_orders_master.ItemsSource = masterService.GetOrderClientToMaster(UserService.UserService.GetIdMaster()).Where(x => x.Status.NameStatus == "Обратывается");
        }

        private void btn_desp_order_Click(object sender, RoutedEventArgs e)
        {
            var orderId = (OrderClient)lb_orders_master.SelectedItem;

            var orderId2 = (OrderClient)lb_orders_in_process.SelectedItem;

            if(orderId != null)
            {
                MessageBox.Show($"Номер заказа: {orderId.Id}\n\n ФИО Клиента: {orderId.FullNameClient}\n\n Телефон: {orderId.Phone}\n\n Время заказа:{orderId.DateTime}\n\n Проблема: {orderId.Problem}\n\n Оборудование: {orderId.Device}");
                lb_orders_master.SelectedItem = null;
                return;
            }
            if(orderId2 !=null)
            {
                MessageBox.Show($"Номер заказа: {orderId2.Id}\n\n ФИО Клиента: {orderId2.FullNameClient}\n\n Телефон: {orderId2.Phone}\n\n Время заказа:{orderId2.DateTime}\n\n Проблема: {orderId2.Problem}\n\n Оборудование: {orderId2.Device}");
                lb_orders_in_process.SelectedItem = null;
                return;
            }
        }

        private void lb_orders_in_process_Loaded(object sender, RoutedEventArgs e)
        {
            MasterService masterService = new MasterService();
            lb_orders_in_process.ItemsSource = masterService.GetOrderClientToMaster(UserService.UserService.GetIdMaster()).Where(x => x.Status.NameStatus == "В процессе");
        }

        private void btn_in_process_Click(object sender, RoutedEventArgs e)
        {
            var orderSelectId = (OrderClient)lb_orders_master.SelectedItem;

            if( orderSelectId != null )
            {
                MasterService masterService = new MasterService();
                masterService.SetStatus(orderSelectId.Id, "В процессе");
                lb_orders_in_process.ItemsSource = masterService.GetOrderClientToMaster(UserService.UserService.GetIdMaster()).Where(x => x.Status.NameStatus == "В процессе");
                lb_orders_master.ItemsSource = masterService.GetOrderClientToMaster(UserService.UserService.GetIdMaster()).Where(x => x.Status.NameStatus == "Обратывается");
            }
            else
            {
                MessageBox.Show("Вы не выбрали заказ");
            }

        }

        private void btn_complete_Click(object sender, RoutedEventArgs e)
        {
            var orderSelectId2 = (OrderClient)lb_orders_in_process.SelectedItem;



            if (orderSelectId2 != null)
            {
                MasterService masterService = new MasterService();
                masterService.SetStatus(orderSelectId2.Id, "Выполнен");
                lb_orders_in_process.ItemsSource = masterService.GetOrderClientToMaster(UserService.UserService.GetIdMaster()).Where(x => x.Status.NameStatus == "В процессе");
            }
            else
            {
                MessageBox.Show("Вы не выбрали заказ");
            }
        }
    }
}
