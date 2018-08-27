using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LambdaForums.Data;
using LambdaForums.Models.Post;
using LambdaForums.Models.Reply;
using Microsoft.AspNetCore.Mvc;

namespace LambdaForums.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;

        protected PostController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);

            var replies = BuildPostReplies(post.Replies);

            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImageUrl,
                AutorRating = post.User.Rating,
                Created = post.Created,
                PostContent = post.Content,
                Replies = replies

            };

            return View();
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyModel
            {
                Id = reply.Id,
                AuthorId = reply.User.Id,
                AuthorName = reply.User.UserName,
                AuthorImageUrl = reply.User.ProfileImageUrl,
                AutorRating = reply.User.Rating,
                Created = reply.Created,
                ReplyContent = reply.Content
            });

            
        }
    }
}