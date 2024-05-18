using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json.Nodes;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string apiKey = "92aeca13bb0fd3fc19b3b9d6c42bc4cd";
        private readonly string weatherApiEndpoint = "https://api.openweathermap.org/data/2.5/weather";

        public MainWindow()
        {
            InitializeComponent();

            HttpClient httpClient = new HttpClient();
            var requestUrl = $"{weatherApiEndpoint}?q={HttpUtility.UrlEncode("Affoltern am Albis")}&appid={apiKey}";
            HttpResponseMessage httpResponse = httpClient.GetAsync(requestUrl).Result;
            string response = httpResponse.Content.ReadAsStringAsync().Result;

            WeatherMapResponse weatherMapResponse = JsonConvert.DeserializeObject<WeatherMapResponse>(response); 

            Console.WriteLine(weatherMapResponse);

        }
    }
}