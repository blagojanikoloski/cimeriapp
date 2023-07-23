using Cimeri.Domain.DomainModels;
using Cimeri.Domain.DTO;
using Cimeri.Repository.Interface;
using Cimeri.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cimeri.Web.Controllers
{
    [Authorize]
    public class CimerListController : Controller
    {
        private readonly ICimeriPostService _cimeriPostService;
        private readonly IUserRepository _userRepository;
        public CimerListController(ICimeriPostService cimeriPostService, IUserRepository userRepository)
        {
            _cimeriPostService = cimeriPostService;
            _userRepository = userRepository;
        }


        [HttpGet]
        [Route("CimerList/{id}")]
        public IActionResult Index(int id)
        {
            //Base CimeriPost
            var cimeriPost = _cimeriPostService.GetCimeriPostById(id);

            //All CimeriPosts
            var allCimeriPosts = _cimeriPostService.GetAllCimeriPosts();


            // Filter by city
            var filteredByCity = allCimeriPosts.Where(cp => cp.CityID == cimeriPost.CityID);

            // Filter by budget
            var filteredByBudget = filteredByCity.Where(cp => cp.budget <= cimeriPost.budget);

            // Filter by same gender requirement
            var filteredByGender = filteredByBudget.Where(cp =>
            {
                var ownerGender = _userRepository.GetUserById(cimeriPost.userID)?.Gender;
                var postGender = _userRepository.GetUserById(cp.userID)?.Gender;
                return (((cp.sameGenderRequired == -1 || cp.sameGenderRequired == 0) && (cimeriPost.sameGenderRequired == -1 || cimeriPost.sameGenderRequired == 0)) || ((cp.sameGenderRequired == cimeriPost.sameGenderRequired) &&
                       (ownerGender == postGender)));
            });

            // Filter by student requirement
            var filteredByStudent = filteredByGender.Where(cp =>
                ((cp.studentRequired == -1 || cp.studentRequired==0) && (cimeriPost.studentRequired==-1 && cimeriPost.studentRequired==0)) || (cp.studentRequired == cimeriPost.studentRequired)
            );

            var cimerList = new List<CimerListDto>();

            foreach (var post in filteredByStudent)
            {
                //Skip if the post is itself
                if (post.CimeriPostID == cimeriPost.CimeriPostID)
                    continue;

                //Skip if the post is by the same user
                if (post.userID == cimeriPost.userID)
                    continue;

                double compatibilityPercentage = 0;

                // Check if optimal number of roommates match
                if (post.optimalNumberOfRoommates == cimeriPost.optimalNumberOfRoommates)
                    compatibilityPercentage += 25;

                // Check if how long match
                if (post.howLong == cimeriPost.howLong)
                    compatibilityPercentage += 25;

                // Check if smoker preference match
                if (post.isSmoker == cimeriPost.isSmoker)
                    compatibilityPercentage += 25;

                // Check if guests allowed match
                if (post.guestsAllowed == cimeriPost.guestsAllowed)
                    compatibilityPercentage += 25;


                //Get user and extract his info
                var user = _userRepository.GetUserById(post.userID);

                if (user != null)
                {
                    // Create CimerListDto and populate with data
                    var cimerDto = new CimerListDto
                    {
                        Name = user.FirstName, // Replace with the appropriate property from the user identity table
                        Age = user.Age, // Replace with the appropriate property from the user identity table
                        Email = user.Email, // Replace with the appropriate property from the user identity table
                        PhoneNumber = user.PhoneNumber, // Replace with the appropriate property from the user identity table
                        Compatibility = compatibilityPercentage
                    };

                    cimerList.Add(cimerDto);
                }
            }

            ViewBag.cimerList = cimerList;
            return View();
        }
    }
}
