using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.IntegracaoCep
{
    public class Endereco
    {
        public string? Cep { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Localidade { get; set; }
        public string? Uf { get; set; }
    }
    public class viaCepApi
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<Endereco> BuscarCepUsuario(string cep)
        {
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            // Adicionar a validação do erro 400 Bad Request

            string responseBody = await response.Content.ReadAsStringAsync();
            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(responseBody);

            return endereco;
        }
    }
}
