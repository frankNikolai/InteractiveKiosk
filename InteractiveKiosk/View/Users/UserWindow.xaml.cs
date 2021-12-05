using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowParameters.Tools
{

    [ValueConversion(typeof(string), typeof(string))]
    public class RatioConverter : MarkupExtension, IValueConverter
    {
        private static RatioConverter _instance;

        public RatioConverter() { }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { // do not let the culture default to local to prevent variable outcome re decimal syntax
            double size = System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter, CultureInfo.InvariantCulture);
            return size.ToString("G0", CultureInfo.InvariantCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        { // read only converter...
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ?? (_instance = new RatioConverter());
        }

    }
}

namespace InteractiveKiosk.View.Users
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        gr691_fnvEntities entities = new gr691_fnvEntities();
        Model.SelectOfData data = new Model.SelectOfData();
        Model.AdjustmentAttId adjustmentAttId = new Model.AdjustmentAttId();
        View.User.Developer developer;
        public static int id { get; set; }
        public static string name { get; set; }
        public static string cost { get; set; }
        public static string Numbertickets { get; set; }
        public UserWindow()
        {
            InitializeComponent();
            id = adjustmentAttId.Min();
            ImageChange(id);
            AdjustmentData(id);
        }

        private void AdjustmentData(int id)
        {
            TxtBlockName.Text = data.SelectName(id);
            TxtBlockHoldingCapacity.Text = data.SelectHoldingCapacity(id);
            TxtBlockPermissibleLoad.Text = data.SelectPermissibleLoad(id);
            TxtBlockAgeGroup.Text = data.SelectAgeGroup(id);
            TxtBlockWorkOfTime.Text = data.SelectWorkOfTime(id);
            TxtBlockLocation.Text = data.SelectLocation(id);
            TxtBlockDeveloper.Text = data.SelectDeveloper(id);
            TxtBlockDateOfCreate.Text = data.SelectDateOfCreate(id);
            TxtBlockNumberSupport.Text = data.SelectNumbersupport(id);
            txtBlockCost.Text = data.SelectCost(id) + " руб.";
        }
        private void Open_Data_Developer_Click(object sender, RoutedEventArgs e)
        {
            developer = new View.User.Developer(id);
            developer.Show();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (id > adjustmentAttId.Min())
            {
                id = adjustmentAttId.Decrement(id);
                ImageChange(id);
                AdjustmentData(id);
            }
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (id < adjustmentAttId.Max())
            {
                id = adjustmentAttId.Increment(id);
                ImageChange(id);
                AdjustmentData(id);
            }
        }

        private void Add_Basket_Click(object sender, RoutedEventArgs e)
        {
            string[] sum = null, names = null;
            if (name == null || name == "")
            {
                name += data.SelectName(id) + "\n";
                cost += data.SelectCost(id) + "\n";
                Numbertickets += id + " ";
                MessageBox.Show("Билет добавлен в корзину");
            }
            else
            {
                sum = cost.Split('\n');
                names = name.Split('\n');
                if (sum.Length <= 8 && names.Length <= 8)
                {
                    name += data.SelectName(id) + "\n";
                    cost += data.SelectCost(id) + "\n";
                    Numbertickets += id + " ";
                    MessageBox.Show("Билет добавлен в корзину");
                }
                else
                {
                    MessageBox.Show("За один раз можно приобрести максимум 8 билетов");
                }
            }
        }

        private void Basket_Click(object sender, RoutedEventArgs e)
        {
            View.User.Basket basket = new View.User.Basket();
            basket.Add(name, cost);
            basket.Show();
        }

        private void Ticket_Buy_Click(object sender, RoutedEventArgs e)
        {
            View.User.TicketBuy ticketBuy = new View.User.TicketBuy();
            string[] sum = null, names = null;
            if (name != null && name != "")
            {
                sum = cost.Split('\n');
                names = name.Split('\n');
                if (sum.Length != 1 && names.Length != 1)
                {
                    ticketBuy.Add(name, cost);
                    ticketBuy.Show();
                }
            }
            else
            {
                name = data.SelectName(id);
                cost = data.SelectCost(id);
                Numbertickets += id + " ";
                ticketBuy.Add(name, cost);
                ticketBuy.Show();
            }
        }
        public void deleteNameAndCost()
        {
            name = null;
            cost = null;
        }

        private void ImageChange(int id)
        {
            string image = "";
            if (id == 1) { image = "kamikadze.jpg"; }
            else if (id == 2) { image = "hip-hop.jpg"; }
            else if (id == 3) { image = "nlo.jpg"; }
            else if (id == 4) { image = "kolokolchik.jpg"; }
            else if (id == 5) { image = "ImageAttraction.jpg"; }
            else if (id == 6) { image = "faraon.jpg"; }
            else if (id == 7) { image = "elektromobili.jpg"; }
            else if (id == 8) { image = "torpopyzhka.png"; }
            else if (id == 9) { image = "konvoy.jpg"; }
            else if (id == 10) { image = "mini_dzhipy.jpg"; }
            else if (id == 11) { image = "batut_mario.jpg"; }
            else if (id == 12) { image = "alye_parusa.jpg"; }
            else if (id == 13) { image = "assorti.jpg"; }
            else if (id == 14) { image = "kanoe.jpg"; }
            else if (id == 15) { image = "igrovaya_komnata.jpg"; }
            else if (id == 16) { image = "gusenica.jpg"; }
            else if (id == 17) { image = "karusel.jpg"; }
            else if (id == 18) { image = "koleso_obozrenia.jpg"; }
            else if (id == 19) { image = "tir.jpg"; }
            else if (id == 20) { image = "safari.jpg"; }
            ImageAttraction.Source = BitmapFrame.Create(new Uri($"Z:\\2 курс\\2 семестр\\ТРПО\\КП\\Проект\\InteractiveKiosk\\InteractiveKiosk\\Images\\{image}"));
        }
    }
}
