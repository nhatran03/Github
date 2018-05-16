using Github.Dtos;
using Github.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace Github.Controllers
{
	public class FollowingsController : ApiController
    {
	    private ApplicationDbContext _context;

	    public FollowingsController()
	    {
		    _context = new ApplicationDbContext();
	    }

	    public IHttpActionResult Follow(FollowingDto dto)
	    {
		    var userId = User.Identity.GetUserId();

		    if (_context.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId != ""))
		    {
			    return BadRequest("Folling already exists.");
		    }

		    var following = new Following
		    {
				FollowerId = User.Identity.GetUserId(),
				FolloweeId = dto.FollowerId
		    };
		    _context.Followings.Add(following);
		    _context.SaveChanges();

		    return Ok();
	    }
    }
}
