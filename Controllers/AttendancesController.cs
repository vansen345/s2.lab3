using Microsoft.AspNet.Identity;
using s2.lab3.DTOs;
using s2.lab3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace s2.lab3.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbConText ;
        public AttendancesController()
        {
            _dbConText = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbConText.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The Attendnace already exists");
            var attenddance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = User.Identity.GetUserId()
            };
            _dbConText.Attendances.Add(attenddance);
            _dbConText.SaveChanges();
            return Ok();
        }
    }
}
