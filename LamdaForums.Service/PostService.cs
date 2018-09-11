using LambdaForums.Data;
using LambdaForums.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaForums.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public Task AddReply(PostReply reply)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts
                .Include(post => post.User)
                .Include(post => post.Replies).ThenInclude(reply => reply.User)
                .Include(post => post.Forum);
        }

        public IEnumerable<Post> GetLatestPosts(int n)
        {
            return GetAll().OrderByDescending(post => post.Created).Take(n);
        }


        public Post GetById(int id)
        {
            return _context.Posts
                .Where(post => post.Id == id)
                .Include(post => post.User)
                .Include(post => post.Replies).ThenInclude(reply => reply.User)
                .Include(post => post.Forum)
                .First();

            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetFilteredPosts(Forum forum, string search)
        {
            return string.IsNullOrEmpty(search) ?  // if query is null return all posts else only search query
                forum.Posts :
                forum.Posts.Where(post =>
            post.Title.Contains(search) ||
            post.Content.Contains(search));
        }

        public IEnumerable<Post> GetFilteredPosts(string search)
        {
            return GetAll().Where(post
                => post.Title.Contains(search)
                || post.Content.Contains(search));
        }


        public IEnumerable<Post> GetPostsByForum(int id)
        {
            var posts = _context.Forums
                .Where(forum => forum.Id == id)
                .FirstOrDefault().Posts;
            return posts;

        }
    }

        
}
