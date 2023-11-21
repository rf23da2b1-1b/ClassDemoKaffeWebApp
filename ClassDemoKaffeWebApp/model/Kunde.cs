namespace ClassDemoKaffeWebApp.model
{
    public class Kunde
    {
        /*
         * Instans felter
         */
        private int _kundeNummer;
        private string _navn;
        private string _tlf;
        private bool _isFirma;
        private double _ranking;

        /*
         * Properties
         */
        public int KundeNummer
        {
            get { return _kundeNummer; }
            set { _kundeNummer = value; }
        }

        public string Navn
        {
            get { return _navn; }
            set { _navn = value; }
        }

        public bool IsFirma
        {
            get { return _isFirma; }
            set { _isFirma = value; }
        }
        public double Ranking
        {
            get { return _ranking; }
            set { _ranking = value; }
        }

        public string Tlf
        {
            get { return _tlf; }
            set { _tlf = value; }
        }

        /*
         * Constructor
         */
        public Kunde()
        {
            _kundeNummer = 0;
            _navn = "";
            _tlf = "";
            _isFirma = false;
            _ranking = 0;
        }
        public Kunde(int nr, string navn, string tlf, bool firma, double ranking)
        {
            _kundeNummer = nr;
            _navn = navn;
            _tlf = tlf;
            _isFirma = firma;
            _ranking = ranking;
        }

        public override string ToString()
        {
            return $"{{{nameof(KundeNummer)}={KundeNummer.ToString()}, {nameof(Navn)}={Navn}, {nameof(IsFirma)}={IsFirma.ToString()}, {nameof(Ranking)}={Ranking.ToString()}, {nameof(Tlf)}={Tlf}}}";
        }
    }
}
