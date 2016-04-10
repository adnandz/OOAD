using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMD.Models
{
    public class Uloga
    {
        public int UlogaId { get; set; }
        public string Naziv { get; set; }
        
        public ICollection<UlogaMeniStavka> UlogaMeniStavke 
        {
            get;
            set;
        }
        public Uloga ()
        {
            UlogaMeniStavke = new List<UlogaMeniStavka>();
        }
        //pridruzivanje MeniStavkeUlozi
        public void DodajMeniStavkuUlozi(MeniStavka menistavka)
        {
            this.UlogaMeniStavke.Add(new UlogaMeniStavka(this, menistavka));
        }
    }
}
