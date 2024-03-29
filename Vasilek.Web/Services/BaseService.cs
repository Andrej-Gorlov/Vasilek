﻿using Vasilek.Web.Models;
using Vasilek.Web.Services.IServices;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace Vasilek.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDtoBase responseModel { get ; set ; }
        public IHttpClientFactory? httpClient{ get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ResponseDtoBase();
            this.httpClient = httpClient;   
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("VasilisaAPI");

                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data!=null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }

                if (!string.IsNullOrEmpty(apiRequest.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.AccessToken);
                }
                // настройка получаемого ответа для клиента 
                HttpResponseMessage? apiResponse = null;
                switch (apiRequest.Api_Type)
                {
                    case StaticDitels.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case StaticDitels.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case StaticDitels.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse= await client.SendAsync(message);

                var apiContet=await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto=JsonConvert.DeserializeObject<T>(apiContet);
                return apiResponseDto;  

            }
            catch (Exception ex)
            {
                var dto = new ResponseDtoBase
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto= JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
