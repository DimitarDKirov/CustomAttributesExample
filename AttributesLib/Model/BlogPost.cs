using System.Text.Json.Serialization;

namespace AttributesLib.Model {
    public class BlogPost {
        
        public int UserID { get; set; }

        public int id { get; set; }
        
        [JsonPropertyName("title")]
        public string PostTitle { get; set; }

        [JsonPropertyName("body")]
        public string PostContent { get; set; }
        
    }
}