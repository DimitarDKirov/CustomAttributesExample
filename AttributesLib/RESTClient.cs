using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AttributesLib {
    public class RESTClient {
        private const char UrlSeparator = '/';

        private readonly HttpClient _client;
        private readonly string _apiUrl;

        public RESTClient(string apiUrl) {
            _client = new HttpClient();
            _apiUrl = apiUrl;
        }

        public async Task<List<T>> GetAll<T>(string collection) {
            try {
                var stream = await _client.GetStreamAsync($"{_apiUrl}{UrlSeparator}{collection}");
                var result = await JsonSerializer.DeserializeAsync<List<T>>(stream);

                return result;
            } catch(Exception) {
                return null;
            }
        }

        public async Task<T> GetOne<T>(string collection, int id) where T : class {
            try {
                var stream = await _client.GetStreamAsync($"{_apiUrl}{UrlSeparator}{collection}{UrlSeparator}{id}");
                var result = await JsonSerializer.DeserializeAsync<T>(stream);

                return result;
            } catch(Exception) {
                return null;
            }
            
        }
    }
}