using ClassDemoKaffeWebApp.model;

namespace ClassDemoKaffeWebApp.services
{
    public interface IKundeRepository
    {
        public Dictionary<int, Kunde> Katalog { get; set; }

        List<Kunde> HentAlleKunder();
        Kunde HentKunde(int kundenummer);
        Kunde HentKundeUdFraTlf(string tlf);
        Kunde Opdater(Kunde kunde);
        Kunde Slet(int kundenummer);
        Kunde Tilføj(Kunde kunde);


        List<Kunde> Search(int? number, string? name, string? phone);
        List<Kunde> SortNumber();
        List<Kunde> SortName();
    }
}