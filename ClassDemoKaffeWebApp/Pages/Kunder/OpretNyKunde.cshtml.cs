using ClassDemoKaffeWebApp.model;
using ClassDemoKaffeWebApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClassDemoKaffeWebApp.Pages.Kunder
{
    public class OpretNyKundeModel : PageModel
    {

        public int NytKundeNummer { get; set; }
        public string NytKundeNavn { get; set; }
        public string NytKundetlf { get; set; }


        public void OnGet()
        {
        }

        public void OnPost()
        {
            Kunde nyKunde = new Kunde(NytKundeNummer, NytKundeNavn, NytKundetlf);

            KundeRepository repo = new KundeRepository(true);
            repo.Tilføj(nyKunde);


        }
    }
}
