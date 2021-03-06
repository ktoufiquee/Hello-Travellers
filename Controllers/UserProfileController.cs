using Hello_Travellers.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hello_Travellers.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        Entities db = new Entities();
        public ActionResult Index()
        {

            if (Session["Username"] != null)
            {

                var currUser = Session["Username"].ToString();
                List<User> user = db.Users.Where(temp => temp.Username == currUser).ToList();
                ViewBag.user = user[0];
                var posts = db.Posts.Where(temp => temp.CreatorUsername == currUser).ToArray();
                ViewBag.posts = posts;
                var mediaItems = new MediaItem[posts.Length];
                for (int i = 0; i < posts.Length; i++)
                {
                    var currentID = posts[i].PostID;
                    mediaItems[i] = db.MediaItems.Where(temp => temp.PostID == currentID).FirstOrDefault();
                }
                ViewBag.mediaItems = mediaItems;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserAuth");
            }

        }

        public ActionResult EditProfile()
        {
            if (Session["Username"] != null)
            {
                var currUser = Session["Username"].ToString();
                User existingUser = db.Users.Where(temp => temp.Username == currUser).FirstOrDefault();
                ViewBag.user = existingUser;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserAuth");
            }

        }
        [HttpPost]
        public ActionResult EditProfile(User user)
        {
            Entities db = new Entities();
            var currUser = Session["Username"].ToString();
            User existingUser = db.Users.Where(temp => temp.Username == currUser).FirstOrDefault();
            if (!String.IsNullOrEmpty(user.Name))
            {
                existingUser.Name = user.Name;
            }
            if (!String.IsNullOrEmpty(user.Email))
            {
                existingUser.Email = user.Email;
            }
            if (!String.IsNullOrEmpty(user.PhoneNumber))
            {
                existingUser.PhoneNumber = user.PhoneNumber;
            }
            if (!String.IsNullOrEmpty(user.About))
            {
                existingUser.About = user.About;
            }
            if (!String.IsNullOrEmpty(user.Password))
            {
                existingUser.Password = user.Password;
            }


            if (ModelState.IsValid)
            {
                db.Entry(existingUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }


        }

    }
}