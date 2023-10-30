using ClassDemoKaffeWebApp.model;

namespace ClassDemoKaffeWebApp.services
{
    public class KundeRepository
    {
        // instans felt
        Dictionary<int, Kunde> _katalog;

        // properties
        public Dictionary<int, Kunde> Katalog
        {
            get { return _katalog; }
            set { _katalog = value; }
        }

        // konstruktør
        public KundeRepository(bool mockData = false)
        {
            _katalog = new Dictionary<int, Kunde>();


            if (mockData )
            {
                PopulateKundeRepository();
            }
        }

        private void PopulateKundeRepository()
        {
            _katalog.Clear();

            _katalog.Add(1, new Kunde(1, "peter", "33445566"));
            _katalog.Add(2, new Kunde(2, "vibeke", "99887766"));
            _katalog.Add(3, new Kunde(3, "anders", "44332211"));
            _katalog.Add(4, new Kunde(4, "henrik", "55446677"));
            _katalog.Add(5, new Kunde(5, "jakob", "88775533"));
        }





        /*
         * metoder
         */
        public Kunde Tilføj(Kunde kunde)
        {
            _katalog.Add(kunde.KundeNummer, kunde);

            return kunde;
        }

        public Kunde Slet(int kundenummer)
        {
            if (_katalog.ContainsKey(kundenummer))
            {
                Kunde slettetKunde = _katalog[kundenummer];
                _katalog.Remove(kundenummer);
                return slettetKunde;

            }
            else
            {
                return null;
            }
        }

        public Kunde HentKunde(int kundenummer)
        {
            if (_katalog.ContainsKey(kundenummer))
            {
                return _katalog[kundenummer];

            }
            else
            {
                // opdaget en fejl
                throw new KeyNotFoundException("kundenummer findes ikke");



                //return null;
            }
        }

        public List<Kunde> HentAlleKunder()
        {
            return _katalog.Values.ToList();
        }

        public Kunde HentKundeUdFraTlf(string tlf)
        {
            Kunde resKunde = null;

            foreach (Kunde k in _katalog.Values)
            {
                if (k.Tlf == tlf)
                {
                    return k;
                }
            }

            return resKunde;
        }

        public override string ToString()
        {
            String pænTekst = String.Join(", ", _katalog.Values);

            return $"{{{nameof(Katalog)}={pænTekst}}}";
        }


    }
}
