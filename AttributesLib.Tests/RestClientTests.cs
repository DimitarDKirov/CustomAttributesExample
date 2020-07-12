using System.Threading.Tasks;
using AttributesLib.Model;
using NUnit.Framework;

namespace AttributesLib.Tests {
    public class RestClientTests 
    {
        [Test]
        public async Task GetAll_ReturnsArray_WhenValid() {
            var client = new RESTClient("https://jsonplaceholder.typicode.com");
            var posts = await client.GetAll<BlogPost>("posts");
            
            Assert.NotNull(posts);
            Assert.Greater(posts.Count, 80);
        }
        
        [Test]
        public async Task GetAll_ReturnsNull_WhenNotValid() {
            var client = new RESTClient("https://jsonplaceholder.typicode.com");
            var posts = await client.GetAll<BlogPost>("invalid_posts");
            
            Assert.Null(posts);
        }
        
        [Test]
        public async Task GetOne_ReturnsItem_WhenValid() {
            var client = new RESTClient("https://jsonplaceholder.typicode.com");
            var blogPost = await client.GetOne<BlogPost>("posts", 3);
            
            Assert.NotNull(blogPost);
            Assert.IsTrue(blogPost.PostTitle.Contains("molestias"));
        }
        
        [Test]
        public async Task GetOne_ReturnsNull_WhenInvalid() {
            var client = new RESTClient("https://jsonplaceholder.typicode.com");
            var blogPost = await client.GetOne<BlogPost>("posts", int.MaxValue);
            
            Assert.Null(blogPost);
        }
    }
}