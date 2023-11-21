using ClassDemoKaffeWebApp.model;
using System.Text.Json;

namespace ClassDemoKaffeWebApp.services
{
    public class KundeRepositoryJson:IKundeRepository
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
        public KundeRepositoryJson()
        {
            _katalog = ReadFromJson();
        }

        

        /*
         * metoder
         */
        public Kunde Tilføj(Kunde kunde)
        {
            if (!_katalog.ContainsKey(kunde.KundeNummer))
            {
                _katalog.Add(kunde.KundeNummer, kunde);


                WriteToJson();
                return kunde;
            }

            throw new ArgumentException($"KundeNummer {kunde.KundeNummer} findes i forvejen");
        }

        public Kunde Slet(int kundenummer)
        {
            Kunde slettetKunde = HentKunde(kundenummer);
            _katalog.Remove(kundenummer);

            WriteToJson();
            return slettetKunde;
        }

        public Kunde Opdater(Kunde kunde)
        {
            Kunde editKunde = HentKunde(kunde.KundeNummer);
            _katalog[kunde.KundeNummer] = kunde;


            WriteToJson();
            return kunde;
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
                throw new KeyNotFoundException($"kundenummer {kundenummer} findes ikke");
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

        public List<Kunde> Search(int? number, string? name, string? phone)
        {
            List<Kunde> retKunder = new List<Kunde>(HentAlleKunder());

            if (number is not null)
            {
                retKunder = retKunder.FindAll(k => k.KundeNummer == number);
            }

            if (name is not null)
            {
                retKunder = retKunder.FindAll(k => k.Navn.Contains(name));
            }


            if (phone is not null)
            {
                retKunder = retKunder.FindAll(k => k.Tlf.Contains(phone));
            }

            return retKunder;
        }



        public override string ToString()
        {
            String pænTekst = String.Join(", ", _katalog.Values);

            return $"{{{nameof(Katalog)}={pænTekst}}}";
        }


        /*
         * Hjælpe metoder til at læse og skrive til en fil i json format
         */

        private const string FILENAME = "KundeRepository.json";

        private Dictionary<int, Kunde> ReadFromJson()
        {
            if ( File.Exists(FILENAME) )
            {
                StreamReader reader = File.OpenText(FILENAME);
                Dictionary<int, Kunde> katalog = JsonSerializer.Deserialize<Dictionary<int, Kunde>>(reader.ReadToEnd());
                reader.Close();
                return katalog;
            }
            else
            {
                return new Dictionary<int, Kunde>();
            }
            
        }

        private void WriteToJson()
        {
            FileStream fs = new FileStream(FILENAME, FileMode.Create);
            Utf8JsonWriter writer = new Utf8JsonWriter(fs);
            JsonSerializer.Serialize(writer, _katalog);
            fs.Close();
        }

       
    }
}
