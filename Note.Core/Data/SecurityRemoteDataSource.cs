using Note.Core.Utility;
using Note_3.DTOs;
using Note_3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Note.Core

{
    public class SecurityRemoteDataSource
    {
        public static readonly HttpClient client = new HttpClient();

        public SecurityRemoteDataSource()
        {
            client.BaseAddress = new Uri("http://localhost:5010/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //        public async Task<SecurityResponse> GetRespons(int id)
        //        {
        //            SecurityResponse security_response = null;

        //            HttpResponseMessage response = await client.GetAsync($"api/Respons/{id}");
        //            if (response.IsSuccessStatusCode)
        //            {
        //                security_response = DataSerializer.Deserialize<SecurityResponse>(
        //                   await response.Content.ReadAsStringAsync());
        //            }
        //            return security_response;
        //        }

        //        public async Task<List<SecurityResponse>> GetRespons()
        //        {

        //            HttpResponseMessage response = await client.GetAsync(
        //                "api/Respons");
        //            response.EnsureSuccessStatusCode();

        //            List<SecurityResponse> security_response = new List<SecurityResponse>();
        //            if (response.IsSuccessStatusCode)
        //            {
        //                security_response = DataSerializer.Deserialize<List<SecurityResponse>>(
        //                    await response.Content.ReadAsStringAsync());
        //            }
        //            return security_response;
        //        }
        //    }
        //}

        public async Task<SecurityResponse> Login(SecurityRequest request)
        {
            HttpResponseMessage response = await client.PostAsync(
                ("api/Security/login"), JsonContent.Create(request));


            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Регистрация завершилась с ошибкой!");
            }SecurityResponse security = DataSerializer.Deserialize<SecurityResponse>(
                    await response.Content.ReadAsStringAsync())!;
            return security;
        }

        public async Task Register(SecurityRequest request)
        {
            HttpResponseMessage response = await client.PostAsync(
                ("api/Security/register"), JsonContent.Create(request));

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Вход завершился с ошибкой!");
            }
            
            return;
        }
    }
}
