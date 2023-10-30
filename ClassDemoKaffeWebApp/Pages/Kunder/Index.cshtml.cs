using ClassDemoKaffeWebApp.model;
using ClassDemoKaffeWebApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClassDemoKaffeWebApp.Pages.Kunder
{
    public class IndexModel : PageModel
    {
        // property til View'et
        public List<Kunde> Kunder { get;  set; }

        public void OnGet()
        {
            KundeRepository repo = new KundeRepository(true);

            Kunder = repo.HentAlleKunder();

        }
    }
}
