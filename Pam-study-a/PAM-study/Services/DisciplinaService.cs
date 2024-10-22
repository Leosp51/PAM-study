using PAM_study.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PAM_study.Services
{
    public class DisciplinaService
    {
        private HttpClient client;
        private List<Disciplina> disciplinas;
        private Disciplina disciplina;
        private JsonSerializerOptions serializerOptions;

        public DisciplinaService() {

            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            disciplinas = new List<Disciplina>();
            disciplina = new Disciplina();
        }
        public async Task<List<Disciplina>> getAllMonitorsAsync()
        {
            Uri uri = new Uri("http://localhost:8080/monitores");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    disciplinas = JsonSerializer.Deserialize<List<Disciplina>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return disciplinas;
        }
        public async Task<Disciplina> getDisciplinaById(int id)
        {
            Uri uri = new Uri("http://localhost:8080/disciplinas/" + id.ToString());
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    disciplina = JsonSerializer.Deserialize<Disciplina>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return disciplina;
        }
    }
}
