using System;

namespace LambdaForums.Models.Reply
{
    public class PostReplyModel
    {
        public int Id { get; set; }
        public string ReplyContent { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public int AutorRating { get; set; }
        public DateTime Created { get; set; }
        public bool IsAuthorAdmin { get; set; }

        public int PostId { get; set; }
    }
}
