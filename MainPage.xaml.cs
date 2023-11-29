namespace Sedmica5
{
    public partial class MainPage : ContentPage
    {
        public List<VrstaPosiljke> VrstaPosiljkeList { get; set; }
        public List<DodatneUsluga> DodatneUslugaList { get; set; }
        public List<Mjesto> MjestoList { get; set; }
        
        public MainPage()
        {
            VrstaPosiljkeList = new List<VrstaPosiljke>()
            {
                new VrstaPosiljke(1, "Paket", 3),
                new VrstaPosiljke(2, "Dokument", 1)
            };

            MjestoList = new List<Mjesto>()
            {
                new Mjesto(1, "Zenica", 10),
                new Mjesto(2, "Sarajevo", 100),
                new Mjesto(3, "Travnik", 50),
                new Mjesto(4, "Tešanj", 70)
            };

            DodatneUslugaList = new List<DodatneUsluga>()
            {
                new DodatneUsluga(1, "Hitna pošiljka", 30),
                new DodatneUsluga(2, "Dostava vikendom", 35),
                new DodatneUsluga(3, "Povrat otpremnice", 40),
                new DodatneUsluga(4, "Lomljivo", 45),
                new DodatneUsluga(5, "Otvaranje pošiljke", 50),
                new DodatneUsluga(6, "Naplata poduzećem", 55),
                new DodatneUsluga(7, "Pakovanje", 60),
                new DodatneUsluga(8, "Dodatno osiguranje", 65)
            };

            BindingContext = this;
            InitializeComponent();

            RokIsporuke.MinimumDate = DateTime.Now;
            RokIsporuke.MaximumDate = DateTime.Now.AddDays(3);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (start.SelectedIndex == end.SelectedIndex)
            {
                DisplayAlert("Greška", "Nije moguće koristiti istu lokaciju za pošiljaoca i primaoca", "OK");
                return;
            }

            double masa = -1;
            if (!double.TryParse(Masa.Text, out masa) || masa < 0)
            {
                DisplayAlert("Greška", "Neispravna masa", "OK");
                return;
            }

            if (start.SelectedItem == null || end.SelectedItem == null)
            {
                DisplayAlert("Greška", "Mjesta pošiljke i primanja paketa su obavezna!", "OK");
                return;
            }
            
            double baznaCijena = 0;
            if (masa >= 0.1 && masa < 0.5) baznaCijena = 3;
            else if (masa >= 0.5 && masa < 1) baznaCijena = 5;
            else if (masa >= 1 && masa < 5) baznaCijena = 10;
            else if (masa >= 5 && masa < 10) baznaCijena = 30;
            else if (masa >= 10 && masa <= 20) baznaCijena = 50;
            else baznaCijena = 70;

            int diff = (int)(RokIsporuke.Date - DateTime.Now).TotalDays;
            if (diff >= 2) baznaCijena *= 0.8;

            if (VrstaPosiljkeList[0].Ugovorena) baznaCijena *= VrstaPosiljkeList[0].FaktorCijene;
            if (VrstaPosiljkeList[1].Ugovorena) baznaCijena *= VrstaPosiljkeList[1].FaktorCijene;

            baznaCijena += DodatneUslugaList.Where(usluga => usluga.Ugovorena).Sum(usluga => usluga.Cijena) + ((Mjesto)end.SelectedItem).Udaljenost * 0.1f;

            DisplayAlert("Usluga brze pošte", $"Ukupna vrijednost usluge: {baznaCijena:F2} KM\n" +
                $"Broj odabranih dopunskih usluga: {DodatneUslugaList.Where(usluga => usluga.Ugovorena).Count()}\n" +
                $"Udaljenost za dostavu: {((Mjesto)end.SelectedItem).Udaljenost} km\n" +
                $"Rok dostave: {(int)(RokIsporuke.Date - DateTime.Now).TotalDays} dana", "OK");
        }
    }
}