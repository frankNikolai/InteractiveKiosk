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

namespace InteractiveKiosk
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            int user = 1;

            if (user == 1)
            {
                View.Users.UserWindow userWindow = new View.Users.UserWindow();
                userWindow.Show();
            }
            else if (user == 2)
            {
                View.Admin.Authorization authorization = new View.Admin.Authorization();
                authorization.Show();
            }
            this.Close();
        }
    }
}
