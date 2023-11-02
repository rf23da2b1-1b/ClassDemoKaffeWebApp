using ClassDemoKaffeWebApp.model;
using ClassDemoKaffeWebApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClassDemoKaffeWebApp.Pages.Kunder
{
    public class NyKundeModel : PageModel
    {
        private KundeRepository _repo;

        public NyKundeModel(KundeRepository repo)
        {
            _repo = repo;
        }






        [BindProperty]
        public int NytKundeNummer { get; set; }
        [BindProperty]
        public string NytKundeNavn { get; set; }
        [BindProperty]
        public string NytKundetlf { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Kunde nyKunde = new Kunde(NytKundeNummer, NytKundeNavn, NytKundetlf);

            //KundeRepository repo = new KundeRepository(true);
            _repo.Tilføj(nyKunde);

            return RedirectToPage("Index");
        }
    }
}
