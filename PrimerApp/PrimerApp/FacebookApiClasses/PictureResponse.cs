using System;
namespace analisis.FacebookApiClasses
{
    public class PictureResponse
    {
        public Picture picture { get; set; }
        public string id { get; set; }
    }

    public class Picture
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public bool is_silhouette { get; set; }
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }
}
