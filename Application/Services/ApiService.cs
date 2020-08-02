using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ApiService
    {
        public ApiService()
        {
        }
        
        /// <summary>
        /// Récupère toutes les cartes de api 
        /// </summary>
        /// <returns>List de cartes</returns>
        public async Task<Exceptional<List<Card>>> GetAllCardAsync()
        {
            Exceptional<List<Card>> cards = new Exceptional<List<Card>>();
            var client = new HttpClient();
            var url = @"https://api.magicthegathering.io/v1/cards";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                cards = await response.Content.ReadAsAsync<Exceptional<List<Card>>>();
            }
            return cards;
        }
    }
}
