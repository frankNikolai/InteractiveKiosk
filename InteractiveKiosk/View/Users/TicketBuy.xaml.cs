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
    /// Логика взаимодействия для TicketBuy.xaml
    /// </summary>
    public partial class TicketBuy : Window
    {
        public TicketBuy()
        {
            InitializeComponent();
        }

        private void Success_Buy_Click(object sender, RoutedEventArgs e)
        {
            
            gr691_fnvEntities entities = new gr691_fnvEntities();
            InteractiveKiosk.User user = new InteractiveKiosk.User();
            InteractiveKiosk.Basket basket = new InteractiveKiosk.Basket();
            Basket_Attraction basketAttraction = new Basket_Attraction();
            Attraction attraction = new Attraction();
            Model.AdjustmentAttId attId = new Model.AdjustmentAttId();
            string[] nums = new string[8];
            nums = View.Users.UserWindow.Numbertickets.Split(' ');
            decimal summary = 0;

            int idBask = (from i in entities.Basket
                          select i.ID).Max() + 1;

            basket.DateOfbuy = DateTime.Now;
            user.Basket_ID = idBask;

            for (int i = 0; i < nums.Length - 1; ++i)
            {
                int buffNum = Convert.ToInt32(nums[i]);
                basketAttraction.Basket_ID = idBask;
                basketAttraction.Attraction_ID = Convert.ToInt32(nums[i]);
                entities.Basket_Attraction.Add(basketAttraction);
                summary += (from j in entities.Attraction
                            where j.ID == buffNum
                            select j.Cost).FirstOrDefault();
            }
            basket.Cost = summary;
            entities.Basket.Add(basket);
            entities.User.Add(user);

            entities.SaveChanges();

            MessageBox.Show($"Поздравляю с успешной покупкой билета(ов) на сумму {summary} рублей.");

            View.Users.UserWindow.id = attId.Min();
            View.Users.UserWindow.name = null;
            View.Users.UserWindow.cost = null;
            View.Users.UserWindow.Numbertickets = null;

            this.Close();

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Add(string name, string cost)
        {
            string[] sum = cost.Split('\n');
            string[] names = name.Split('\n');
            if (sum.Length != 1 && names.Length != 1)
            {
                decimal buffSummary = 0;

                for (int i = 0; i < sum.Length - 1; ++i)
                {
                    buffSummary += Convert.ToDecimal(sum[i]);
                    txtBlockInTotal.Text += names[i] + " - " + sum[i] + " руб.\n";
                }

                txtBlockBuy.Text = buffSummary.ToString() + " руб.";
            }
            else
            {
                txtBlockInTotal.Text = name + " - " + cost + " руб.";
                txtBlockBuy.Text = cost + " руб.";
            }
        }
        public void delete()
        {
            txtBlockInTotal.Text = "";
            txtBlockBuy.Text = "";
        }
    }
}
