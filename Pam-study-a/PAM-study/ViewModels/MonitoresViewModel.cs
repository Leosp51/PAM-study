using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PAM_study.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAM_study.ViewModels
{
    public partial class MonitoresViewModel:ObservableObject
    {
        private MonitorService service = new MonitorService();
        [ObservableProperty]
        public ObservableCollection<Models.Monitor> monitores;

        public MonitoresViewModel() {
            Monitores = new();
            carregarMonitores();
            Monitores.Add(new Models.Monitor
            {
                Nome = "Carinha",
                Whatsapp = "593",
                Foto = "https://images.generated.photos/-t6chrwY4d4Ro2AXJ8fY0jv6NsX7rbGyejtYzHRF704/rs:fit:512:512/wm:0.95:sowe:18:18:0.33/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/NDM4Njk0LmpwZw.jpg",
                Email = "@gmail.com",
                Conteudo = "Muito conteúdo\n + muito conteúdo + outros conteúdo\n bla bla",
            });
        }
        [RelayCommand]
        public void AtualizarLista()
        {
            carregarMonitores();
        }

        public async void carregarMonitores()
        {
            var resultado = await service.getAllMonitorsAsync();
            
            
            Monitores = resultado;
            
        }
    }
}
