using Microsoft.AspNet.Identity;
using s2.lab3.DTOs;
using s2.lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace s2.lab3.Controllers
{
    public class FollowingController : ApiController
    {
        private readonly ApplicationDbContext _dbConText;
            public FollowingController()
        {
            _dbConText = new ApplicationDbContext();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Follow (FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbConText.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists");
            var folowing = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };
            _dbConText.Followings.Add(folowing);
            _dbConText.SaveChanges();
            return Ok();

        }
        // GET: Following
       
    }
}