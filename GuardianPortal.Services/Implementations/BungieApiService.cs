using GuardianPortal.Domain;
using GuardianPortal.Domain.Character;
using GuardianPortal.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GuardianPortal.Services.Implementations
{
    public class BungieApiService : IBungieApiService
    {
        private static readonly HttpClient bungieApiClient = new HttpClient() {
            BaseAddress = new Uri("https://www.bungie.net/")
        };

        private readonly string API_KEY_HEADER = "X-API-Key";
        private readonly string API_KEY_HEADER_VALUE = "fb76ca9b571b490da22c21dd53b4c8f6";

        public async Task<object> GetProfileByMembership(long membershipId, string[] components) {
            string url = string.Format("Platform/Destiny2/3/Profile/{0}/?components={1}", membershipId, string.Join(',', components));
            return await GetAsync<Character>(url);
        }

        private async Task<T> GetAsync<T>(string url) {
            if (!bungieApiClient.DefaultRequestHeaders.Contains(API_KEY_HEADER)) {
                bungieApiClient.DefaultRequestHeaders.Add(API_KEY_HEADER, API_KEY_HEADER_VALUE);
            }

            var response = await bungieApiClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            try {
                var deserialized = JsonConvert.DeserializeObject<T>(responseBody);
                return deserialized;
                //return JsonConvert.DeserializeObject<T>(responseBody);
            } catch (Exception ex) {
                throw;
            }
        }

        public async Task<BungieApiResponse<CharacterResponse>> GetCharactersByMembership(long membershipId) {
             //really need to pass in the membership type here
            string url = string.Format("Platform/Destiny2/3/Profile/{0}/?components={1}", membershipId, "Characters");
            return await GetAsync<BungieApiResponse<CharacterResponse>>(url);
        }
    }
}
