using Microsoft.AspNetCore.Http;
using System;

namespace LambdaForums.Models.ApplicationUsers
{
    public class ProfileModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public string UserRating { get; set; }
        public bool IsAdmin { get; set; }

        public DateTime MemeberSice { get; set; }
        public IFormFile ImageUpload { get; set; }
    }
}
