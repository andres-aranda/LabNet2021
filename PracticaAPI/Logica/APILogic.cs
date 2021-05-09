using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Logica
{
    public class Juego
    {
        public int id { get; set; }
        public string title { get; set; }
        public string thumbnail { get; set; }
        public string short_description { get; set; }
        public string publisher { get; set; }
        public string genre { get; set; }
        public string freetogame_profile_url { get; set; }
        public string release_date { get; set; }

    }
    public class APILogic
    {
        public async Task<List<Juego>> GetJuegos()
        {
            var httpCLient = new HttpClient();
            var json = await httpCLient.GetStringAsync("https://www.freetogame.com/api/games?platform=pc");
            List<Juego> listaJuegos = JsonConvert.DeserializeObject<List<Juego>>(json);
            return listaJuegos;
        }
    }
}
