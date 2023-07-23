using Cimeri.Domain.DomainModels;
using Cimeri.Domain.DTO;
using Cimeri.Domain.Identity;
using Cimeri.Repository;
using Cimeri.Repository.Interface;
using Cimeri.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cimeri.Web.Controllers
{
    [Authorize]
    public class MyProfileController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly ICimeriPostService _cimeriPostService;
        private readonly IUserRepository _userRepository;

        public MyProfileController(ApplicationDbContext context,ICimeriPostService cimeriPostService, IUserRepository userRepository)
        {
            _context = context;
            _cimeriPostService = cimeriPostService;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<CimeriPost> cimeriPosts = _cimeriPostService.GetCimeriPostsByUserId(userId);


            List<MyProfileDTO> allCimeriPosts = new List<MyProfileDTO>();

            foreach (var cimeriPost in cimeriPosts)
            {
                MyProfileDTO myProfileDTO = _cimeriPostService.TranslateCimeriPostToStrings(cimeriPost);
                allCimeriPosts.Add(myProfileDTO);
            }

            ViewBag.allCimeriPosts = allCimeriPosts;

            CimeriApplicationUser loggedInUser = _userRepository.GetUserById(userId);
            ViewBag.email = loggedInUser.Email;
            ViewBag.firstname = loggedInUser.FirstName;
            ViewBag.lastname = loggedInUser.LastName;
            ViewBag.phonenumber = loggedInUser.PhoneNumber;

            return View();
        }

        




    }
}
