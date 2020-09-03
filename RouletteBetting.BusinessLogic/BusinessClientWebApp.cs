using Newtonsoft.Json;
using RouletteBetting.Entities.Dto;
using RouletteBetting.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBetting.BusinessLogic
{
    public enum HttpMethod
    {
        GET = 0,
        POST,
        PUT
    }

    public class BusinessClientWebApp
    {
        private static BusinessClientWebApp instance = null;

        private BusinessClientWebApp()
        {

        }

        public static BusinessClientWebApp GetInstance()
        {
            if (instance == null)
            {
                instance = new BusinessClientWebApp();
            }

            return instance;
        }

        public int CreateUser(string uri)
        {
            string data = this.GetData(uri);
            int userId = 0;
            if (!string.IsNullOrEmpty(data))
            {
                userId = JsonConvert.DeserializeObject<int>(data);
            }

            return userId;
        }

        public List<UserViewModel> GetUsers(string uri)
        {
            List<UserViewModel> users = null;
            string data = this.GetData(uri);
            if (!string.IsNullOrEmpty(data))
            {
                users = JsonConvert.DeserializeObject<List<UserViewModel>>(data);
            }

            return users;
        }

        public List<RouletteViewModel> GetRoulettes(string uri)
        {
            List<RouletteViewModel> roulettes = null;
            string data = this.GetData(uri);
            if (!string.IsNullOrEmpty(data))
            {
                roulettes = JsonConvert.DeserializeObject<List<RouletteViewModel>>(data);
            }

            return roulettes;
        }

        public RouletteViewModel GetRoulette(string uri)
        {
            throw new NotImplementedException();
        }

        public int CreateRoulette(string uri)
        {
            string data = this.GetData(uri);
            int rouletteId = 0;
            if (!string.IsNullOrEmpty(data))
            {
                rouletteId = JsonConvert.DeserializeObject<int>(data);
            }

            return rouletteId;
        }

        public List<GetBetViewModel> CloseRoulette(string uri)
        {
            List<GetBetViewModel> bets = null;
            string data = this.GetData(uri);
            if (!string.IsNullOrEmpty(data))
            {
                bets = JsonConvert.DeserializeObject<List<GetBetViewModel>>(data);
            }
            return bets;
        }

        public string OpenRoulette(string uri)
        {
            string data = this.GetData(uri);
            string result = string.Empty;
            if (!string.IsNullOrEmpty(data))
            {
                result = JsonConvert.DeserializeObject<string>(data);
            }

            return result;
        }

        public string MakeBet(string uri, HttpContent content)
        {
            string result = this.GetData(uri, content);

            return result;
        }

        private string GetData(string uri, HttpContent content)
        {
            string data = string.Empty;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage httpResponseMessage = httpClient.PostAsync(uri, content).Result;
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        private string GetData(string uri)
        {
            string data = string.Empty;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage httpResponseMessage = httpClient.GetAsync(uri).Result;
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }
    }
}
