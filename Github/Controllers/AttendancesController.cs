using Github.Models;
using Microsoft.AspNet.Identity;
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
            var attendance = new Attendance
            {
                GigId = gigid,
                AttendaneeId = User.Identity.GetUserId()
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok();
        }
    }
}
