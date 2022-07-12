using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bank
{
    class ParseSite
    {
        public Dictionary<string, Coin> Valute { get; private set; }
        KeyValuePair<string, Coin> RUB;
        public string Site { get; private set; }
        public ParseSite()
        {
            Valute = new Dictionary<string, Coin>();
            RUB = new KeyValuePair<string, Coin>("RUB",
                new Coin()
                {
                    ID = "R001",
                    CharCode = "RUB",
                    Name = "Российский рубль",
                    Nominal = 1,
                    Value = 1,
                    NumCode = "0001",
                    Previous = 1
                });
            Refresh();
        }

        public  void Refresh()
        {
            HttpClient client = new HttpClient();
          HttpResponseMessage httpResponseMessage= 
          client.GetAsync("https://www.cbr-xml-daily.ru/daily_json.js").Result;
          Site = httpResponseMessage.Content.ReadAsStringAsync().Result;
          JsonToValute();
        }
        void JsonToValute()
        {
            JsonBank jsonBank = JsonConvert.DeserializeObject<JsonBank>(Site);
            Valute = jsonBank.Valute;
            Valute.Add(RUB.Key, RUB.Value);
        }

    }
}
