using Cimeri.Domain.DomainModels;
using Cimeri.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimeri.Service.Interface
{
    public interface ICimeriPostService
    {
        List<CimeriPost> GetCimeriPostsByUserId(string userId);

        MyProfileDTO TranslateCimeriPostToStrings(CimeriPost cimeriPost);


        CimeriPost GetCimeriPostById(int id);

        List<CimeriPost> GetAllCimeriPosts();

        int GetLargestCimeriPostID();
    }
}
