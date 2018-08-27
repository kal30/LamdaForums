using LambdaForums.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LambdaForums.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(string search);
        IEnumerable<Post> GetPostsByForum(int id);

        Task Add(Post post);
        Task Delete(int id);
        Task EditPostContent(int id, string newContent);

        Task AddReply(PostReply reply);
       
    }
}
