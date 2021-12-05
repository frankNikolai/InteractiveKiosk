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

namespace InteractiveKiosk.View.Admin
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                gr691_fnvEntities entities = new gr691_fnvEntities();
                if (txtLogin.Text == "" || txtPassword.Password == "")
                {
                    MessageBox.Show("Заполните пустые поля");
                }
                if (txtLogin.Text == (from i in entities.Administration select i.Login).FirstOrDefault() &&
                    txtPassword.Password == (from i in entities.Administration select i.Password).FirstOrDefault())
                {
                    MessageBox.Show("Авторизация прошла успешно");
                    Administration administration = new Administration();
                    administration.Show();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }    
            }
            catch
            {
                MessageBox.Show("Соединение с БД не установлено");
            }
        }
    }
}
