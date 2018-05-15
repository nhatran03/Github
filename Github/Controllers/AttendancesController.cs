using Github.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace Github.Controllers
{
	[Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend([FromBody] int gigid)
        {
			var userId = User.Identity.GetUserId();

	        if (_context.Attendances.Any(a => a.AttendaneeId == userId
			                                  && a.GigId == gigid))
			{
				return BadRequest("The Acctendance already exists.");
			}

            var attendance = new Attendance
            {
                GigId = gigid,
                AttendaneeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok();
        }
    }
}
