using System;
using System.Collections.Generic;
using System.Text;

namespace Sedmica5
{
    public class VrstaPosiljke
    {
        public int Id { get; set; }
        public string Vrsta { get; set; }
        public float FaktorCijene { get; set; }
        public bool Ugovorena { get; set; }

        public VrstaPosiljke(int id, string vrsta, float faktor, bool ugovorena = false)
        {
            this.Id = id;
            this.Vrsta = vrsta;
            this.FaktorCijene = faktor;
            this.Ugovorena = ugovorena;
        }
    }
}
