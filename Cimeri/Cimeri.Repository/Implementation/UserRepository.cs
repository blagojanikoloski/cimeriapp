using Cimeri.Domain.Identity;
using Cimeri.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cimeri.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<CimeriApplicationUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<CimeriApplicationUser>();
        }
        public IEnumerable<CimeriApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        
        public void Insert(CimeriApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(CimeriApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(CimeriApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public CimeriApplicationUser GetUserById(string userId)
        {
            // Assuming you have a DbSet<User> in your DbContext
            return context.Users.FirstOrDefault(u => u.Id == userId);
        }
    }
}
