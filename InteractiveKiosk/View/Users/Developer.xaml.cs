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
    /// Логика взаимодействия для Developer.xaml
    /// </summary>
    public partial class Developer : Window
    {
        gr691_fnvEntities entities = new gr691_fnvEntities();
        
        public Developer(int idDev)
        {
            
            InitializeComponent();
            FirstName.Text = (from i in entities.Developer
                         where i.ID == idDev
                         select i.FirstName).FirstOrDefault();
            LastName.Text = (from i in entities.Developer
                              where i.ID == idDev
                              select i.LastName).FirstOrDefault();
            MiddleName.Text = (from i in entities.Developer
                              where i.ID == idDev
                              select i.MiddleName).FirstOrDefault();
            Birthday.Text = (from i in entities.Developer
                              where i.ID == idDev
                              select i.Birthday.ToString().Substring(0,13)).FirstOrDefault();
            ShortDescription.Text = (from i in entities.Developer
                                where i.ID == idDev
                                select i.ShortDescription).FirstOrDefault();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
