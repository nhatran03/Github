using Github.Models;
using Github.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Github.Controllers
{
	public class GigsController : Controller
    {
        private readonly ApplicationDbContext context;
        
        public GigsController() {
            context = new ApplicationDbContext();
        }

	    public ActionResult Mine()
	    {
		    var userId = User.Identity.GetUserId();
		    var gis = context.Gig.Where(g => g.ArtistId == userId && g.Datetime > DateTime.Now)
			    .ToList();
		    return View("");
	    }

	    // GET: Gigs
        [Authorize]
        public ActionResult Create()
        {
            var viewmodel = new GigFormViewModel
            {
                Genres = context.Genre.ToList()
            };
            return View(viewmodel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewmodel) {
            if (!ModelState.IsValid) {
                viewmodel.Genres = context.Genre.ToList();
                return View("Create", viewmodel);
            }
                
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                Datetime = viewmodel.GetDateTime(),
                GenreId = viewmodel.Genre,
                Vanue = viewmodel.Vanue
            };
            context.Gig.Add(gig);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}