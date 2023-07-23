using Cimeri.Domain.DomainModels;
using Cimeri.Domain.DTO;
using Cimeri.Repository.Interface;
using Cimeri.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cimeri.Service.Implementation
{
    public class CimeriPostService : ICimeriPostService
    {

        private readonly ICimeriPostRepository _cimeriPostRepository;
        private readonly ICityService _cityService;

        public CimeriPostService(ICimeriPostRepository cimeriPostRepository, ICityService cityService)
        {
            _cimeriPostRepository = cimeriPostRepository;
            _cityService = cityService;
        }
        public List<CimeriPost> GetAllCimeriPosts()
        {
            return _cimeriPostRepository.GetAll();
        }

        public CimeriPost GetCimeriPostById(int id)
        {
            return _cimeriPostRepository.GetById(id);
        }

        public int GetLargestCimeriPostID()
        {
            return _cimeriPostRepository.GetLargestCimeriPostID();
        }

        public List<CimeriPost> GetCimeriPostsByUserId(string userId)
        {
            return _cimeriPostRepository.GetCimeriPostsByUserId(userId);
        }


        private string TranslateValueToString(int value, Dictionary<int, string> translations, string defaultValue)
        {
            if (translations.TryGetValue(value, out var translatedValue))
            {
                return translatedValue;
            }

            return defaultValue;
        }

        public MyProfileDTO TranslateCimeriPostToStrings(CimeriPost cimeriPost)
        {
            City neededCity = _cityService.getCityById(cimeriPost.CityID);
            var myProfileDTO = new MyProfileDTO
            {
                CimeriPostID = cimeriPost.CimeriPostID,
                city = neededCity.CityName,
                budget = cimeriPost.budget,
                sameGenderRequired = TranslateValueToString(cimeriPost.sameGenderRequired, new Dictionary<int, string> { { -1, "Не е селектирано" }, { 0, "Не" }, { 1, "Да" } }, string.Empty),
                studentRequired = TranslateValueToString(cimeriPost.studentRequired, new Dictionary<int, string> { { -1, "Не е селектирано" }, { 0, "Не" }, { 1, "Да" } }, string.Empty),
                optimalNumberOfRoommates = cimeriPost.optimalNumberOfRoommates == 0 ? "Не е селектирано" : cimeriPost.optimalNumberOfRoommates.ToString(),
                howLong = TranslateValueToString(cimeriPost.howLong, new Dictionary<int, string> { { -1, "Не е селектирано" }, { 1, "3 месеци или помалку" }, { 2, "3 месеци до 1 година" }, { 3, "1+ година" } }, string.Empty),
                isSmoker = TranslateValueToString(cimeriPost.isSmoker, new Dictionary<int, string> { { -1, "Не е селектирано" }, { 0, "Не" }, { 1, "Да" } }, string.Empty),
                guestsAllowed = TranslateValueToString(cimeriPost.guestsAllowed, new Dictionary<int, string> { { -1, "Не е селектирано" }, { 0, "Не" }, { 1, "Да" } }, string.Empty),
                userID = cimeriPost.userID
            };

            return myProfileDTO;
        }


    }
}
