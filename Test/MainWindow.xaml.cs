using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test.UserService;
using Test.Windows.ManagerWindow;
using Test.Windows.MasterWindow;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_aut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserService.UserService userService = new UserService.UserService();

                if(string.IsNullOrEmpty(tb_login.Text))
                {
                    MessageBox.Show("Вы не ввели логин");
                    return;
                }
                if(string.IsNullOrEmpty(pb_password.Password))
                {
                    MessageBox.Show("Вы не ввели пароль");
                    return;
                }
                if(userService.IsUser(tb_login.Text,pb_password.Password))
                {
                    if(userService.GetRole() == 1)
                    {
                        ManagerWindow managerWindow = new ManagerWindow();
                        MessageBox.Show($"Добро пожаловать в систему, {tb_login.Text}");
                        managerWindow.Show();
                        this.Close();
                        return;
                    
                    }
                    if (userService.GetRole() == 2)
                    {
                        MasterWindow masterWindow = new MasterWindow();
                        MessageBox.Show($"Добро пожаловать в систему, {tb_login.Text}");
                        masterWindow.Show();
                        this.Close();
                        return;

                    }
                }
                else
                {
                    MessageBox.Show("Вы ввели неправильный логин или пароль");
                    return;
                }

            }
            catch 
            {

                MessageBox.Show("Ошибка при подключении к БД");
            }
        }
    }
}