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
    /// Логика взаимодействия для Administration.xaml
    /// </summary>
    public partial class Administration : Window
    {
        gr691_fnvEntities entities = new gr691_fnvEntities();
        public Administration()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridAttraction.ItemsSource = entities.Attraction.ToList();
            DataGridDescription.ItemsSource = entities.Descriptions.ToList();
            DataGridAgeGroup.ItemsSource = entities.AgeGroup.ToList();
            DataGridLocation.ItemsSource = entities.Location.ToList();
            DataGridDeveloper.ItemsSource = entities.Developer.ToList();
            DataGridBasket.ItemsSource = entities.Basket.ToList();
            DataGridUser.ItemsSource = entities.User.ToList();
        }
        //Attraction
        private void AddAttraction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Attraction attraction = new Attraction();
                attraction.Name = txtBoxAttractionName.Text;
                attraction.Cost = Convert.ToDecimal(txtBoxAttractionCost.Text);
                attraction.Clossed_Open = txtBoxAttractionActiv.Text;
                attraction.Description_ID = Convert.ToInt32(txtBoxAttractionDescriptionId.Text);
                entities.Attraction.Add(attraction);
                entities.SaveChanges();
                DataGridAttraction.ItemsSource = entities.Attraction.ToList();
                MessageBox.Show("Добавлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteAttraction_Click_(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBoxAttractionId.Text);
                var DRow = entities.Attraction.Where(w => w.ID == id).FirstOrDefault();
                entities.Attraction.Remove(DRow);
                entities.SaveChanges();
                DataGridAttraction.ItemsSource = entities.Attraction.ToList();
                MessageBox.Show("Удалено");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void UpdateAttraction_Click_(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBoxAttractionId.Text);
                var URow = entities.Attraction.Where(w => w.ID == id).FirstOrDefault();
                if (txtBoxAgeGroupName.Text != null &&
                    txtBoxAgeGroupName.Text != "") { URow.Name = txtBoxAttractionName.Text; }
                if (txtBoxAttractionCost.Text != null &&
                    txtBoxAttractionCost.Text != "") { URow.Cost = Convert.ToDecimal(txtBoxAttractionCost.Text); }
                if (txtBoxAttractionActiv.Text != null &&
                    txtBoxAttractionActiv.Text != "") { URow.Clossed_Open = txtBoxAttractionActiv.Text; }
                if (txtBoxAttractionDescriptionId.Text != null &&
                    txtBoxAttractionDescriptionId.Text != "")
                { URow.Description_ID = Convert.ToInt32(txtBoxAttractionDescriptionId); }
                entities.SaveChanges();
                DataGridAttraction.ItemsSource = entities.Attraction.ToList();
                MessageBox.Show("Обновлено");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        //Description
        private void AddDescription_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Descriptions descriptions = new Descriptions();
                descriptions.Description = txtBoxDescriprionDescrip.Text;
                descriptions.HoldingCapacity = Convert.ToByte(txtBoxDescriprionHoldingCapacity.Text);
                descriptions.PermissibleLoad = Convert.ToSByte(txtBoxDescriprionPermissibleLoad.Text);
                descriptions.AgeGroup_ID = Convert.ToInt32(txtBoxDescriprionAgeGroupId.Text);
                descriptions.WorkingHours_1 = TimeSpan.Parse(txtBoxDescriprionWorkingHours_1.Text);
                descriptions.WorkingHours_2 = TimeSpan.Parse(txtBoxDescriprionWorkingHours_2.Text);
                descriptions.Location_ID = Convert.ToInt32(txtBoxDescriprionLocation_ID.Text);
                descriptions.Developer_ID = Convert.ToInt32(txtBoxDescriprionDeveloper_ID.Text);
                descriptions.DateOfCreation = Convert.ToDateTime(txtBoxDescriprionDateOfCreation.Text);
                descriptions.Support = txtBoxDescriprionSupport.Text;
                entities.Descriptions.Add(descriptions);
                entities.SaveChanges();
                DataGridDescription.ItemsSource = entities.Descriptions.ToList();
                MessageBox.Show("Добавлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteDescription_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBoxDescriprionId.Text);
                var DRow = entities.Descriptions.Where(w => w.ID == id).FirstOrDefault();
                entities.Descriptions.Remove(DRow);
                entities.SaveChanges();
                DataGridDescription.ItemsSource = entities.Descriptions.ToList();
                MessageBox.Show("Удалено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateDescription_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int name = Convert.ToInt32(txtBoxDescriprionHoldingCapacity.Text);
                var URow = entities.Descriptions.Where(w => w.HoldingCapacity == name).FirstOrDefault();
                if (txtBoxDescriprionDescrip.Text != null &&
                    txtBoxDescriprionDescrip.Text != "") { URow.Description = txtBoxDescriprionDescrip.Text; }
                if (txtBoxDescriprionHoldingCapacity.Text != null &&
                    txtBoxDescriprionHoldingCapacity.Text != "") { URow.HoldingCapacity = Convert.ToByte(txtBoxDescriprionHoldingCapacity.Text); }
                if (txtBoxDescriprionPermissibleLoad.Text != null &&
                    txtBoxDescriprionPermissibleLoad.Text != "") { URow.PermissibleLoad = Convert.ToSByte(txtBoxDescriprionPermissibleLoad.Text); }
                if (txtBoxDescriprionAgeGroupId.Text != null &&
                    txtBoxDescriprionAgeGroupId.Text != "") { URow.AgeGroup_ID = Convert.ToInt32(txtBoxDescriprionAgeGroupId.Text); }
                if (txtBoxDescriprionWorkingHours_1.Text != null &&
                    txtBoxDescriprionWorkingHours_1.Text != "") { URow.WorkingHours_1 = TimeSpan.Parse(txtBoxDescriprionWorkingHours_1.Text); }
                if (txtBoxDescriprionWorkingHours_2.Text != null &&
                    txtBoxDescriprionWorkingHours_2.Text != "") { URow.WorkingHours_2 = TimeSpan.Parse(txtBoxDescriprionWorkingHours_2.Text); }
                if (txtBoxDescriprionLocation_ID.Text != null &&
                    txtBoxDescriprionLocation_ID.Text != "") { URow.Location_ID = Convert.ToInt32(txtBoxDescriprionLocation_ID.Text); }
                if (txtBoxDescriprionDeveloper_ID.Text != null &&
                    txtBoxDescriprionDeveloper_ID.Text != "") { URow.Developer_ID = Convert.ToInt32(txtBoxDescriprionDeveloper_ID.Text); }
                if (txtBoxDescriprionDateOfCreation.Text != null &&
                    txtBoxDescriprionDateOfCreation.Text != "") { URow.DateOfCreation = Convert.ToDateTime(txtBoxDescriprionDateOfCreation.Text); }
                if (txtBoxDescriprionSupport.Text != null &&
                    txtBoxDescriprionSupport.Text != "") { URow.Support = txtBoxDescriprionSupport.Text; }
                entities.SaveChanges();
                DataGridDescription.ItemsSource = entities.Descriptions.ToList();
                MessageBox.Show("Обновлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddAgeGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AgeGroup ageGroup = new AgeGroup();
                ageGroup.Name = txtBoxAgeGroupName.Text;
                entities.AgeGroup.Add(ageGroup);
                entities.SaveChanges();
                DataGridAgeGroup.ItemsSource = entities.AgeGroup.ToList();
                MessageBox.Show("Добавлено");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteAgeGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBoxAgeGroupId.Text);
                var DRow = entities.AgeGroup.Where(w => w.ID == id).FirstOrDefault();
                entities.AgeGroup.Remove(DRow);
                entities.SaveChanges();
                DataGridAgeGroup.ItemsSource = entities.AgeGroup.ToList();
                MessageBox.Show("Удалено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateAgeGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBoxAgeGroupId.Text);
                var URow = entities.AgeGroup.Where(w => w.ID == id).FirstOrDefault();
                if (txtBoxAgeGroupName.Text != null &&
                    txtBoxAgeGroupName.Text != "") { URow.Name = txtBoxAgeGroupName.Text; }
                entities.SaveChanges();
                DataGridAgeGroup.ItemsSource = entities.AgeGroup.ToList();
                MessageBox.Show("Обновлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddLocation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Location location = new Location();
                location.Name = txtBoxLocationName.Text;
                entities.Location.Add(location);
                entities.SaveChanges();
                DataGridLocation.ItemsSource = entities.Location.ToList();
                MessageBox.Show("Добавлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteLocation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBoxAgeGroupId.Text);
                var DRow = entities.Location.Where(w => w.ID == id).FirstOrDefault();
                entities.Location.Remove(DRow);
                entities.SaveChanges();
                DataGridLocation.ItemsSource = entities.Location.ToList();
                MessageBox.Show("Удалено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateLocation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBoxAgeGroupId.Text);
                var URow = entities.Location.Where(w => w.ID == id).FirstOrDefault();
                if (txtBoxLocationName.Text != null &&
                    txtBoxLocationName.Text != "") { URow.Name = txtBoxLocationName.Text; }
                entities.SaveChanges();
                DataGridLocation.ItemsSource = entities.Location.ToList();
                MessageBox.Show("Обновлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddDeveloper_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Developer developer = new Developer();
                developer.FirstName = txtBoxDeveloperFirstName.Text;
                developer.LastName = txtBoxDeveloperLastName.Text;
                developer.MiddleName = txtBoxDeveloperMiddleName.Text;
                developer.Birthday = Convert.ToDateTime(txtBoxDeveloperBirthday.Text);
                developer.ShortDescription = txtBoxDeveloperShortDescription.Text;
                entities.Developer.Add(developer);
                entities.SaveChanges();
                DataGridDeveloper.ItemsSource = entities.Developer.ToList();
                MessageBox.Show("Добавлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteDeveloper_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBoxDeveloperId.Text);
                var DRow = entities.Developer.Where(w => w.ID == id).FirstOrDefault();
                entities.Developer.Remove(DRow);
                entities.SaveChanges();
                DataGridDeveloper.ItemsSource = entities.Developer.ToList();
                MessageBox.Show("Удалено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateDeveloper_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBoxDeveloperId.Text);
                var URow = entities.Developer.Where(w => w.ID == id).FirstOrDefault();
                if (txtBoxDeveloperFirstName.Text != null &&
                    txtBoxDeveloperFirstName.Text != "") { URow.FirstName = txtBoxDeveloperFirstName.Text; }
                if (txtBoxDeveloperLastName.Text != null &&
                    txtBoxDeveloperLastName.Text != "") { URow.LastName = txtBoxDeveloperLastName.Text; }
                if (txtBoxDeveloperMiddleName.Text != null &&
                    txtBoxDeveloperMiddleName.Text != "") { URow.MiddleName = txtBoxDeveloperMiddleName.Text; }
                if (txtBoxDeveloperBirthday.Text != null &&
                    txtBoxDeveloperBirthday.Text != "") { URow.Birthday = Convert.ToDateTime(txtBoxDeveloperBirthday.Text); }
                if (txtBoxDeveloperShortDescription.Text != null &&
                    txtBoxDeveloperShortDescription.Text != "") { URow.ShortDescription = txtBoxDeveloperShortDescription.Text; }
                entities.SaveChanges();
                DataGridDeveloper.ItemsSource = entities.Developer.ToList();
                MessageBox.Show("Обновлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Basket_Attraction_Click(object sender, RoutedEventArgs e)
        {
            View.Admin.BasketAttraction basketAttraction = new BasketAttraction();
            basketAttraction.Show();
        }

        private void AddBasket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Basket basket = new Basket();
                basket.Cost = Convert.ToDecimal(txtBoxBasketCost.Text);
                basket.DateOfbuy = Convert.ToDateTime(txtBoxBasketDateOfBuy.Text);
                entities.Basket.Add(basket);
                entities.SaveChanges();
                DataGridBasket.ItemsSource = entities.Basket.ToList();
                MessageBox.Show("Добавлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteBasket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBoxBasketId.Text);
                var DRow = entities.Basket.Where(w => w.ID == id).FirstOrDefault();
                entities.Basket.Remove(DRow);
                entities.SaveChanges();
                DataGridBasket.ItemsSource = entities.Basket.ToList();
                MessageBox.Show("Удалено");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateBasket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBoxBasketId.Text);
                var URow = entities.Basket.Where(w => w.ID == id).FirstOrDefault();
                if (txtBoxBasketCost.Text != null &&
                    txtBoxBasketCost.Text != "") { URow.Cost = Convert.ToDecimal(txtBoxBasketCost.Text); }
                if (txtBoxBasketDateOfBuy.Text != null &&
                    txtBoxBasketDateOfBuy.Text != "") { URow.DateOfbuy = Convert.ToDateTime(txtBoxBasketDateOfBuy.Text); }
                entities.SaveChanges();
                DataGridBasket.ItemsSource = entities.Basket.ToList();
                MessageBox.Show("Обновлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InteractiveKiosk.User user = new InteractiveKiosk.User();
                user.Basket_ID = Convert.ToInt32(txtBoxUserBasketId.Text);
                entities.User.Add(user);
                entities.SaveChanges();
                DataGridUser.ItemsSource = entities.User.ToList();
                MessageBox.Show("Добавлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBoxUserId.Text);
                var DRow = entities.User.Where(w => w.Basket_ID == id).FirstOrDefault();
                entities.User.Remove(DRow);
                entities.SaveChanges();
                DataGridUser.ItemsSource = entities.User.ToList();
                MessageBox.Show("Удалено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBoxUserId.Text);
                var URow = entities.User.Where(w => w.Basket_ID == id).FirstOrDefault();
                if (txtBoxUserBasketId.Text != null &&
                    txtBoxUserBasketId.Text != "") { URow.Basket_ID = Convert.ToInt32(txtBoxUserBasketId.Text); }
                entities.SaveChanges();
                DataGridUser.ItemsSource = entities.User.ToList();
                MessageBox.Show("Обновлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
