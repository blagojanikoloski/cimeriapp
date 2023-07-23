using Cimeri.Domain.DomainModels;
using Cimeri.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimeri.Repository.Implementation
{
    public class CimeriPostRepository : ICimeriPostRepository
    {
        private readonly ApplicationDbContext _context;

        public CimeriPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CimeriPost> GetCimeriPostsByUserId(string userId)
        {
            return _context.CimeriPost.Where(c => c.userID == userId).ToList();
        }

        public CimeriPost GetById(int id)
        {
            return _context.CimeriPost.FirstOrDefault(c => c.CimeriPostID == id);
        }

        public List<CimeriPost> GetAll()
        {
            return _context.CimeriPost.ToList();
        }

        public int GetLargestCimeriPostID()
        {
            return _context.CimeriPost.Max(cp => cp.CimeriPostID);
        }
    }
}
