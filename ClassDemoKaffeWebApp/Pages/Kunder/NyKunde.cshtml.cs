using ClassDemoKaffeWebApp.model;
using ClassDemoKaffeWebApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Der skal v�re et navn")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Der skal v�re mindst to tegn i et navn")]
        public string NytKundeNavn { get; set; }



        [BindProperty]
        public string NytKundetlf { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if ( !ModelState.IsValid)
            {
                return Page();
            }
            Kunde nyKunde = new Kunde(NytKundeNummer, NytKundeNavn, NytKundetlf);

            //KundeRepository repo = new KundeRepository(true);
            _repo.Tilf�j(nyKunde);

            return RedirectToPage("Index");
        }
    }
}
