using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace ClimaAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserte la ciudad:");
            string cuidad = Console.ReadLine();
            Console.WriteLine("Inserte el pais:");
            string pais = Console.ReadLine();
            Console.WriteLine("Inserte la unidad (metric(Celsius), imperial(Fahrenheit)):");
            string units = Console.ReadLine();
            GetRequest("https://api.openweathermap.org/data/2.5/weather?q=" + cuidad + ","+ pais + "&units=metric&APPID=f8f675f0507cdc818cd2c5ae0bb4a2d6");
            Console.ReadKey();
        }
        async static void GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        Clima clima = JsonConvert.DeserializeObject<Clima>(mycontent);
                        Console.WriteLine(mycontent);
                        Console.WriteLine(clima.main.temp);
                    }
                }
            }
        }
    }
}
