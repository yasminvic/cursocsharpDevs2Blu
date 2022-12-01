namespace Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Models.Services
{
    public class PokemonAPIService
    {
        private readonly HttpClient _httpClient;
        private const string URL_API_PKMN = "https://pokeapi.co/api/v2/pokemon/";

        public PokemonAPIService()//metodo construtor
        {
            _httpClient = new HttpClient();

        }

        public async Task<Pokemons> GetPokemons()
        {
            //pokemon é o tipo da task
            //comunicação API
            //task = get

            //funçãp Get<T> passando tipo Pokemon e parametro url da API
            return await Get<Pokemons>(URL_API_PKMN);
        }

        public async Task<T> Get<T>(string url)
        {
            //oq retornou da API
            var listHttp = await GetAsync(url);

            //se nao tiver dado sucesso com a API
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
            //oq retornou da API
            var listHttp = await GetAsync(url);

            //se nao tiver dado sucesso com a API
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
            //task do tipo HttpResponseMessage
            
            //objeto de tipo requisao

            //vai fazer uma requisição usando esse objeto
            var getRequest = new HttpRequestMessage()
            {
                //metodo da requisição = GET
                Method = HttpMethod.Get,
                //URL a ser requisitada(da API)
                RequestUri = new Uri(url)
            };
            //retorno da requisição em json
            return await _httpClient.SendAsync(getRequest);
        }
    }
}
