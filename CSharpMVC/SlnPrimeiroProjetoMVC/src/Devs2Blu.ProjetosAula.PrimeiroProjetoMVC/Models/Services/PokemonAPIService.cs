namespace Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Models.Services
{
    public class PokemonAPIService
    {
        private readonly HttpClient _httpClient;
        private const string URL_API_PKMN = "https://pokeapi.co/api/v2/pokemon/";

        public PokemonAPIService()
        {
            _httpClient = new HttpClient();

        }

        public async Task<Pokemons> GetPokemons()
        {
            //comunicação API
            return await Get<Pokemons>(URL_API_PKMN);
        }

        public async Task<T> Get<T>(string url)
        {
            var listHttp = await GetAsync(url);

            if (!listHttp.IsSuccessStatusCode)
            {
                //retorna lista em branco
                //T: tipo generico
                //o T faz parte da linguagem
                return (T)(object)url;
            }

            //oq retornar vai tranformar em json
            return await listHttp.Content.ReadFromJsonAsync<T>();


        }

        public async Task<List<T>> GetList<T>(string url)
        {
            var listHttp = await GetAsync(url);

            if (!listHttp.IsSuccessStatusCode)
            {
                //retorna lista em branco
                return new List<T>();
            }

            //oq retornar vai tranformar em json
            return await listHttp.Content.ReadFromJsonAsync<List<T>>();


        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            //objeto de tipo requisao
            var getRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };
            //retorno em json
            return await _httpClient.SendAsync(getRequest);
        }
    }
}
