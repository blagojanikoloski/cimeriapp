using Cimeri.Domain.DomainModels;
using Cimeri.Repository;
using Cimeri.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cimeri.Web.Controllers
{
    [Authorize]
    public class CimeriPostController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICityService _cityService;
        private readonly ICimeriPostService _cimeriPostService;

        public CimeriPostController(ICityService cityService, ApplicationDbContext context, ICimeriPostService cimeriPostService)
        {
            _cityService = cityService;
            _context = context;
            _cimeriPostService = cimeriPostService;
        }

        public IActionResult Index()
        {
            //Get all cities for the CITY selection 
            List<City> allCities = _cityService.getAll();
            ViewBag.allCities = allCities;
            return View();
        }

        [HttpPost]
        public IActionResult Index(int cityID, int budget, int sameGenderRequired, int studentRequired, int optimalNumberOfRoommates, int howLong, int isSmoker, int guestsAllowed)
        {
            // Get the user ID of the logged-in user
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Create a CimeriPost object
            var cimeriPost = new CimeriPost
            {
                userID = userId,
                CityID = cityID,
                budget = budget,
                sameGenderRequired = sameGenderRequired,
                studentRequired = studentRequired,
                optimalNumberOfRoommates = optimalNumberOfRoommates,
                howLong = howLong,
                isSmoker = isSmoker,
                guestsAllowed = guestsAllowed
            };

            //Add to database
            _context.CimeriPost.Add(cimeriPost);
            _context.SaveChanges();

            int largestID = _cimeriPostService.GetLargestCimeriPostID();
            return Redirect($"/CimerList/{largestID}");
        }


        [HttpGet]
        public ActionResult Edit(int CimeriPostID)
        {
            List<City> allCities = _cityService.getAll();
            ViewBag.allCities = allCities;

            // Retrieve the CimeriPost from the database based on the provided id
            var cimeriPost = _context.CimeriPost.FirstOrDefault(c => c.CimeriPostID == CimeriPostID);

          
            ViewBag.cimeriPost = cimeriPost;
            // Pass the MyProfileDTO object to the view for editing
            return View();
        }

        [HttpPost]
        [Route("/CimeriPost/Edit/{CimeriPostID}")]
        public ActionResult Edit(int CimeriPostID, int cityID, int budget, int sameGenderRequired, int studentRequired, int optimalNumberOfRoommates, int howLong, int isSmoker, int guestsAllowed)
        {
            // Retrieve the existing CimeriPost object from the database based on the cimeriPostID
            CimeriPost cimeriPost = _context.CimeriPost.FirstOrDefault(c => c.CimeriPostID == CimeriPostID);

            // If the CimeriPost object is not found, return a not found response or handle the error as needed
            if (cimeriPost == null)
            {
                return NotFound();
            }

            // Update the properties of the CimeriPost object with the new values
            cimeriPost.CityID = cityID;
            cimeriPost.budget = budget;
            cimeriPost.sameGenderRequired = sameGenderRequired;
            cimeriPost.studentRequired = studentRequired;
            cimeriPost.optimalNumberOfRoommates = optimalNumberOfRoommates;
            cimeriPost.howLong = howLong;
            cimeriPost.isSmoker = isSmoker;
            cimeriPost.guestsAllowed = guestsAllowed;

            // Perform any additional validation or business logic here

            // Save the changes to the database
            _context.SaveChanges();

            // Redirect the user to a success page or a different view as needed
            return Redirect("/MyProfile");
        }

        [HttpPost]
        [Route("/CimeriPost/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            // Retrieve the CimeriPost from the database based on the provided id
            CimeriPost cimeriPost = _context.CimeriPost.FirstOrDefault(c => c.CimeriPostID == id);

            // Remove the CimeriPost from the database
            _context.CimeriPost.Remove(cimeriPost);
            _context.SaveChanges();

            // Redirect the user to a success page or a different view as needed
            return Redirect("/MyProfile");
        }
    }
}
