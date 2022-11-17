using Ex02.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ex02.Repositories
{
    public static class QualityoflifeRepository
    {
        //areas:
        //https://mct-qualityoflife.azurewebsites.net/api/areas
        //area details:
        //https://mct-qualityoflife.azurewebsites.net/api/areas/{areaId}
        //score of area:
        //https://mct-qualityoflife.azurewebsites.net/api/areas/{areaId}/QualityScores
        //update area score:
        //https://mct-qualityoflife.azurewebsites.net/api/QualityScore/{scoreId}

        private const string _BASEAPI = "https://mct-qualityoflife.azurewebsites.net/api/"; 
        //private const string _BASEAPI = "http://10.0.2.2:8080/api/";
        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public static async Task<List<Area>> GetAreasAsync()
        {
            string url = string.Format("{0}areas/", _BASEAPI);
            using (HttpClient client = GetClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    return JsonConvert.DeserializeObject<List<Area>>(json);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static async Task<AreaData> GetAreaDataAsync(Guid areaId)
        {
            string url = string.Format("{0}areas/{1}", _BASEAPI, areaId);
            using (HttpClient client = GetClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    return JsonConvert.DeserializeObject<AreaData>(json);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static async Task<List<QualityScore>> GetQualityScoresAsync(Guid areaId)
        {
            string url = string.Format("{0}areas/{1}/QualityScores", _BASEAPI, areaId);
            using (HttpClient client = GetClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    return JsonConvert.DeserializeObject<List<QualityScore>>(json);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static async Task UpdateQualityScoreAsync(QualityScore score)
        {
            string url = string.Format("{0}QualityScore/{1}", _BASEAPI, score.Id);
            using (HttpClient client = GetClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(score);
                    StringContent cnt = new StringContent(json, Encoding.UTF8, "application/json");

                    await client.PutAsync(url, cnt);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
