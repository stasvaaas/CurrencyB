using Microsoft.Data.Sqlite;
using Newtonsoft.Json;

namespace CurrencyB
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://api.privatbank.ua/p24api/pubinfo?exchange&coursid=5").Result;

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Currency> currencies = JsonConvert.DeserializeObject<List<Currency>>(responseBody);

                using CurrencyDbContext dbContext = new CurrencyDbContext();
                foreach (Currency currency in currencies)
                {
                    dbContext.Currencies.Add(currency);
                }
                dbContext.SaveChanges();
                foreach (Currency currency in dbContext.Currencies.ToList())
                {
                    Console.WriteLine($" Назва: {currency.Ccy}, Курс покупки : {currency.Buy}, Курс продажу : {currency.Sale}\"");
                }
            }
        }
    }
}