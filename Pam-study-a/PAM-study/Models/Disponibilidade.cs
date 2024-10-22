using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAM_study.Models
{
    public class Disponibilidade
    {
        public long Id { get; set; }
        public string DiaSemana {  get; set; }
        public DateTime DtDas {  get; set; }
        public DateTime DtAte { get; set; }
    }
}
