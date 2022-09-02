//Задание
//Разработать консольное приложение, которое генерирует список случайных чисел диапазоном от -100 до 100 в случайном количестве,
//но не меньше 20 штук и не более 100 , выводит получившуюся последовательность на экран,
//затем следующей строкой выводит отсортированную по одному из алгоритмов сортировки последовательность (алгоритм выбирается каждый раз случайным образом).
//В приложении должны быть реализованы минимум 2 алгоритма сортировки (на выбор исполнителя).
//Выбор алгоритма сортировки случайный.
//Результат сортировки отобразить в консоли и реализовать отправку на rest api сервер,
//адрес которого берется из файла конфигурации (требуется реализовать только отправку данных,
//поднимать сервер и реализовывать на его стороне приём и обработку данных не требуется).
//Исходный код выложить в репозиторий Github и выслать нам его адрес ( сделать публичным ).

using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestTask
{
    internal class Program
    {
        private const string ConfigPath = "appconfig.json";

        static async Task Main(string[] args)
        {
            IEnumerable<int> dataSet = new DataGenerator().GetDataSet();

            foreach (var item in dataSet)
                Console.WriteLine(item);
            Console.WriteLine(new string('-', 8));

            dataSet = new SortUtility().RandomSort(dataSet);

            foreach (var item in dataSet)
                Console.WriteLine(item);

            var config = JsonSerializer.Deserialize<Config>(File.ReadAllText(ConfigPath));
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri(config.Host)
            };

            WebClient client = new WebClient(httpClient);
            Console.WriteLine($"Response status code: {(int)await client.SendData(dataSet, CancellationToken.None)}");
        }
    }
}
