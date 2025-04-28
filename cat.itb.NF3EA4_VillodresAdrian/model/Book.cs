using System.Collections.Generic;
using Newtonsoft.Json;

namespace cat.itb.M6UF3EA2_sol.model
{
    [Serializable]
    public class Book
    {

        //ATTRIBUTES

        [JsonProperty("_id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("isbn")]
        public String Isbn { get; set; }

        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("publishedDate")]
        public PublishedDate PublishedDate { get; set; }

        [JsonProperty("thumbnailUrl")]
        public String ThumbnailUrl { get; set; }

        [JsonProperty("shortDescription")]
        public String ShortDescription { get; set; }

        [JsonProperty("longDescription")]
        public String LongDescription { get; set; }

        [JsonProperty("status")]
        public String Status { get; set; }

        [JsonProperty("authors")]
        public List<String> Authors { get; set; }

        [JsonProperty("categories")]
        public List<String> Categories { get; set; }

        //ToSTRING
        public override string ToString()
        {
            return
                "Book{" +
                "Id = '" + Id + '\'' +
                ",Title = '" + Title + '\'' +
                ",Isbn = '" + Isbn + '\'' +
                ",PageCount = '" + PageCount + '\'' +
                ",PublishedDate = '" + PublishedDate + '\'' +
                ",ThumbnailUrl = '" + ThumbnailUrl + '\'' +
                ",ShortDescription = '" + ShortDescription + '\'' +
                ",LongDescription = '" + LongDescription + '\'' +
                ",Status = '" + Status + '\'' +
                ",Authors = '" + Authors + '\'' +
                ",Categories = '" + Categories + '\'' +
                "}";
        }
    }
}

