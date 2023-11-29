using System;
using System.Collections.Generic;
using System.Text;

namespace Sedmica5
{
    public class Mjesto
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Udaljenost { get; set; }

        public Mjesto(int id, string naziv, int udaljenost) {
            this.Id = id;
            this.Naziv = naziv;
            this.Udaljenost = udaljenost;
        }
    }
}
