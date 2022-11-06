using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;


namespace WPF_API_NBP_GOLD
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            using var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://api.nbp.pl/api/cenyzlota/")
               
            };
            using var response = await httpClient.GetAsync("http://api.nbp.pl/api/cenyzlota/");
            var content = await response.Content.ReadAsStringAsync();

           // var rate = JsonConvert.DeserializeObject<TableRow>(content);
            //var rate = JsonConvert.DeserializeObject<TableRow>(content);
            label.Content = content;
            //label.Content = rate.Rates[0].Mid;
            textBlock.Text = content;
            //textBlock.Text = rate.Rates[0].Mid.ToString();
        }

        //private class TableRow
        //{
        //    public List<Rate> Rates { get; set; }
        //}

        private class Rate
        {
            public decimal Mid { get; set; }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
// This is special version from gold
    

