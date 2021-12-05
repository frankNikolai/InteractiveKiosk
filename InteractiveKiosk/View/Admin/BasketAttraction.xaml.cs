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
    /// Логика взаимодействия для BasketAttraction.xaml
    /// </summary>
    public partial class BasketAttraction : Window
    {
        gr691_fnvEntities entities = new gr691_fnvEntities();
        public BasketAttraction()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridBasketAttraction.ItemsSource = entities.Basket_Attraction.ToList();
        }

        private void AddBasketAttraction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Basket_Attraction basket_Attraction = new Basket_Attraction();
                basket_Attraction.Basket_ID = Convert.ToInt32(txtBoxBasketId);
                basket_Attraction.Attraction_ID = Convert.ToInt32(txtBoxAttractionId);
                entities.Basket_Attraction.Add(basket_Attraction);
                entities.SaveChanges();
                MessageBox.Show("Добавлено");
                DataGridBasketAttraction.ItemsSource = entities.Basket_Attraction.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteBasketAttraction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBoxBasketAttractionId.Text);
                var DRow = entities.Basket_Attraction.Where(w => w.Attraction_ID == id).FirstOrDefault();
                entities.Basket_Attraction.Remove(DRow);
                entities.SaveChanges();
                DataGridBasketAttraction.ItemsSource = entities.Basket_Attraction.ToList();
                MessageBox.Show("Удалено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateBasketAttraction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBoxBasketAttractionId.Text);
                var URow = entities.Basket_Attraction.Where(w => w.Attraction_ID == id).FirstOrDefault();
                if (txtBoxBasketId.Text != null &&
                    txtBoxBasketId.Text != "") { URow.Basket_ID = Convert.ToInt32(txtBoxBasketId.Text); }
                if (txtBoxAttractionId.Text != null &&
                    txtBoxAttractionId.Text != "") { URow.Attraction_ID = Convert.ToInt32(txtBoxAttractionId.Text); }
                entities.SaveChanges();
                DataGridBasketAttraction.ItemsSource = entities.Basket_Attraction.ToList();
                MessageBox.Show("Обновлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
