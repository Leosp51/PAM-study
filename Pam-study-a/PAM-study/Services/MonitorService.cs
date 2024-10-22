
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PAM_study.Services
{
    public class MonitorService
    {
        private HttpClient client;
        private ObservableCollection<Models.Monitor> monitores;
        private Models.Monitor monitor;
        private JsonSerializerOptions serializerOptions;

        public MonitorService()
        {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            monitores = new();
        }
        public async Task<ObservableCollection<Models.Monitor>> getAllMonitorsAsync()
        {
            Uri uri = new Uri("http://localhost:8080/monitores");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode) {
                    string content = await response.Content.ReadAsStringAsync();
                    monitores = JsonSerializer.Deserialize<ObservableCollection<Models.Monitor>>(content, serializerOptions);
                }
            } catch (Exception ex) {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return monitores;
        }
        public async Task<Models.Monitor> getMonitorByIdAsync(int id)
        {
            Uri uri = new Uri("http://localhost:8080/monitores/" + id.ToString());
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    monitor = JsonSerializer.Deserialize<Models.Monitor>(content, serializerOptions);
                }
            }
            catch (Exception ex) {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return monitor;
        }

        public async Task postMonitor(Models.Monitor monitor,  bool isNewItem = false)
        {
            Uri uri = new Uri("http://localhost:8080/monitores/");

            try
            {
                string json = JsonSerializer.Serialize<Models.Monitor>(monitor, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                    response = await client.PostAsync(uri, content);
                else
                    response = await client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
