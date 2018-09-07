using LambdaForums.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaForums.Models.Home
{
    public class HomeIndexModel
    {
        public IEnumerable<PostListingModel> LatestPost { get; set; }
        public string SearchQuery { get; set; }
    }
}
