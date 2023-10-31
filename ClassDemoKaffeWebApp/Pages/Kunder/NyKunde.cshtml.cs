using ClassDemoKaffeWebApp.model;
using ClassDemoKaffeWebApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClassDemoKaffeWebApp.Pages.Kunder
{
    public class NyKundeModel : PageModel
    {

        [BindProperty]
        public int NytKundeNummer { get; set; }
        [BindProperty]
        public string NytKundeNavn { get; set; }
        [BindProperty]
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
