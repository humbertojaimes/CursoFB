using System;
namespace analisis.FacebookApiClasses
{
    public class FeedResponse
    {
        public Post[] data { get; set; }
        public PagingFeed paging { get; set; }
    }

    public class PagingFeed
    {
        public string previous { get; set; }
        public string next { get; set; }
    }

    public class Post
    {
        public string message { get; set; }
        public string story { get; set; }
        public DateTime updated_time { get; set; }
        public string id { get; set; }
    }
}
