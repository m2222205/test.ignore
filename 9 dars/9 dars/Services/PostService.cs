namespace _9_dars.Services
{
    public class PostService
    {
        private List<Post> posts;

        public PostService()
        {
            posts = new List<Post>();
        }

        public Post AddPost(Post post1)
        {
            post1.Id = Guid.NewGuid();
            posts.Add(post1);
            return post1;
        }

        public bool DeletePost(Guid postId)
        {
            var exists = false;
            foreach (var post in posts)
            {
                if (post.Id == postId)
                {
                    posts.Remove(post);
                    exists = true;
                    break;
                }
            }
            return exists;
        }

        public Post GetbyId(Guid postid)
        {
            foreach (var post in posts)
            {
                if (post.Id == postid)
                {
                    return post;
                }
            }

            return null;
        }

        public bool UpdatePost(Post updatedpost)
        {
            var PostsFromDb = GetbyId(updatedpost.Id);
            if (PostsFromDb != null)
            {
                return false;
            }
            var index = posts.IndexOf(PostsFromDb);
            posts[index] = updatedpost;
            return true;
        }

        public List<Post> GetAllPosts()
        {
            return posts;
        }

        public void FrontEnd()
        {
            while (true)
            {
                Console.WriteLine("1. Add Post");
                Console.WriteLine("2. Delete Post");
                Console.WriteLine("3. Update Post");
                Console.WriteLine("4. Get all posts");
                Console.WriteLine("5. Most wieved Post");
                Console.WriteLine("6. Most Liked post");
                Console.WriteLine("7. Most Commented");
                Console.WriteLine("8. Get post by comment");
                Console.WriteLine("9. Add viewer name to post");
                Console.WriteLine("10. Add like to post");
                Console.WriteLine("11. Comment to post");
                Console.WriteLine("Enter your option");
                var option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Console.WriteLine("Owner Name");
                    var OwnerName = Console.ReadLine();
                    Console.WriteLine("Description");
                    var Description = Console.ReadLine();
                    Console.WriteLine("Type");
                    var Type = Console.ReadLine();




                }







            }

        }

        public Post GetMostLikedPost()
        {
            var mostLikedPost = posts[0];
            for (int i = 1; i < posts.Count; i++)
            {
                if (mostLikedPost.QuantityLikes < posts[i].QuantityLikes)
                {
                    mostLikedPost = posts[i];
                }
            }
            return mostLikedPost;
        }

        public Post GetMostViewedPost()
        {

            var MostViewed = posts[0];
            for (int i = 1; i < posts.Count; i++)
            {
                if (MostViewed.ViewersCount < posts[i].ViewersCount)
                {
                    MostViewed = posts[i];
                }
            }
            return MostViewed;
        }
        public Post GetMostCommentedPost()
        {
            var responsePost = new Post(); // return one single object
            foreach (var post in posts)
            {
                if (responsePost.Comment.Count < post.Comment.Count)
                {
                    responsePost = post;
                }
            }
            return responsePost;
        }

        public List<Post> GetPostsByComment(string comment)
        {
            var responsePost = new List<Post>(); // return List of a lot of objects
            foreach (var post in posts)
            {
                if (post.Comment.Contains(comment) is true)
                {
                    responsePost.Add(post);
                }
            }
            return responsePost;
        }

        public bool AddViewerNameToPost(Guid postId, string viewerName)
        {
            var result = GetbyId(postId); // result is Object
            if(result == null)
            {
                return false;
            }
            result.ViewersName.Add(viewerName);
            return true;

        }

        public bool AddLikeToPost(Guid postId) { 
            var result = GetbyId(postId);
            if(result == null)
            {
                return false;
            }
            result.QuantityLikes++;
            return true;
        }

        public bool AddCommentToPost(Guid postId, string comment)
        {
            var result = GetbyId(postId); // result is Object
            if (result == null)
            {
                return false;
            }
            result.Comment.Add(comment);
            return true;

        }

    }
}
