using MyClientApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyClientApp.Services
{
    public class EmployeeServices
    {
        private string restUrl = "https://mybackendservicesapp.azurewebsites.net/";
        private HttpClient _client;

        public EmployeeServices()
        {
            _client = new HttpClient();
        }

        public async Task<List<Employee>> GetData()
        {
            var data = new List<Employee>();
            var uri = new Uri($"{restUrl}api/Employee");
            try
            {
                var response = await _client.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<List<Employee>>(content);
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task InsertData(Employee emp)
        {
            var uriPost = new Uri($"{restUrl}api/Employee");
            try
            {
                var json = JsonConvert.SerializeObject(emp);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uriPost, content);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Gagal tambah data !");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //dd
        public async Task UpdateData(Employee emp)
        {
            var uriPut = new Uri($"{restUrl}api/Employee");
            try
            {
                var json = JsonConvert.SerializeObject(emp);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(uriPut, content);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Gagal edit data !");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteData(string id)
        {
            var uriPut = new Uri($"{restUrl}api/Employee/{id}");
            try
            {
                var response = await _client.DeleteAsync(uriPut);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Gagal delete data !");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
