using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAM_study.Models
{
    public class Monitor
    {
        public long Id {  get; set; }
        public string Nome { get; set; }
        public string Foto {  get; set; }
        public string Whatsapp { get; set; }
        public string Email { get; set; }
        public string Conteudo { get; set; }
        public Disciplina Disciplina { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
        public Monitor()
        {

        }
    }
}
