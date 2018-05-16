using Github.Dtos;
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
        public IHttpActionResult Attend(AttendanceDto dto)
        {
			var userId = User.Identity.GetUserId();

	        if (_context.Attendances.Any(a => a.AttendaneeId == userId
			                                  && a.GigId == dto.GigId))
			{
				return BadRequest("The Acctendance already exists.");
			}

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendaneeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok();
        }
    }
}
