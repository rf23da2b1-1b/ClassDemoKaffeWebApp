using ClassDemoKaffeWebApp.model;
using ClassDemoKaffeWebApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ClassDemoKaffeWebApp.Pages.Kunder
{
    public class EditKundeModel : PageModel
    {
        private KundeRepository _repo;

        public EditKundeModel(KundeRepository repo)
        {
            _repo = repo;
        }


        [BindProperty]
        public int NytKundeNummer { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Der skal være et navn")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Der skal være mindst to tegn i et navn")]
        public string NytKundeNavn { get; set; }



        [BindProperty]
        public string NytKundetlf { get; set; }




        public void OnGet(int nummer)
        {
            Kunde kunde = _repo.HentKunde(nummer);

            NytKundeNummer = kunde.KundeNummer;
            NytKundeNavn = kunde.Navn;
            NytKundetlf = kunde.Tlf;
        }


        public IActionResult OnPost()
        {
            if ( !ModelState.IsValid )
            {
                return Page();
            }

            Kunde kunde = _repo.HentKunde(NytKundeNummer);

            kunde.Navn = NytKundeNavn;
            kunde.Tlf = NytKundetlf;

            return RedirectToPage("Index");
        }
    }
}
