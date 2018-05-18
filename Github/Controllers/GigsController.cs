using Github.Models;
using Github.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
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
		[Authorize]
	    public ActionResult Mine()
		{
			var userId = User.Identity.GetUserId();
			var gigs = context.Gig
				.Where(g => g.ArtistId == userId && g.Datetime > DateTime.Now)
				.Include(g => g.Genre)
				.ToList();

			return View(gigs);
		}

		[Authorize]
	    public ActionResult Attending()
	    {
		    var userId = User.Identity.GetUserId();
		    var gigs = context.Attendances
				.Where(x => x.AttendaneeId == userId)
			    .Select(x => x.Gig)
				.Include(g => g.Artist)
				.Include(g => g.Genre)
			    .ToList();

		    var viewModel = new GigsViewModel
		    {
			    UpcomingGigs = gigs,
			    ShowActions = User.Identity.IsAuthenticated,
				Heading = "Gigs I'm Attending"
		    };

		    return View("Gigs",viewModel);
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

            return RedirectToAction("Mine", "Gigs");
        }
    }
}