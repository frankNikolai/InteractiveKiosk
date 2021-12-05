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

namespace InteractiveKiosk.View.User
{
    /// <summary>
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Window
    {
        gr691_fnvEntities entities = new gr691_fnvEntities();

        public Basket()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Clear_Basket_Click(object sender, RoutedEventArgs e)
        {
            View.Users.UserWindow main = new View.Users.UserWindow();
            txtBlockAttractions.Text = "";
            txtBlockCost.Text = "";
            txtBlockSummary.Text = "";
            main.deleteNameAndCost();
        }

        public void Add(string name, string cost)
        {
            if (name != null && cost != null)
            {
                string[] sum = cost.Split('\n');
                decimal buffSummary = 0;
                for (int i = 0; i < sum.Length - 1; ++i)
                {
                    buffSummary += Convert.ToDecimal(sum[i]);
                    txtBlockCost.Text += sum[i] + " руб.\n";
                }

                txtBlockAttractions.Text = name;
                txtBlockSummary.Text = buffSummary.ToString() + " руб.";
            }
        }
    }
}
