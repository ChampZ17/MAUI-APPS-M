using System;
using System.Collections.Generic;
using System.Text;

namespace Sedmica5
{
    public class DodatneUsluga
    {
        public int Id { get; set; }
        public string NazivUsluge { get; set; }
        public float Cijena { get; set; }
        public bool Ugovorena { get; set; }

        public DodatneUsluga(int id, string nazivUsuge, float cijena, bool ugovorena = false)
        {
            this.Id = id;
            this.NazivUsluge = nazivUsuge;
            this.Cijena = cijena;
            this.Ugovorena = ugovorena;
        }
    }
}
