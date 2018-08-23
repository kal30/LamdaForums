using LambdaForums.Data;
using LambdaForums.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LamdaForums.Service
{
    public class ForumService : IForum
    {
        private readonly ApplicationDbContext _context;

        public ForumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums
                .Include (forum => forum.Posts);
        }

        public Forum GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

       

        public Task UpdateForumDescription(int id, string newDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumTitle(int id, string newTitle)
        {
            throw new NotImplementedException();
        }
    }
}
