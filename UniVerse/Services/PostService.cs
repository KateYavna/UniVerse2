using UniVerse.Models;
using UniVerse.Services.Interfaces;

namespace UniVerse.Services
{
    public class PostService : IPostService
    {
        private readonly IDbService _dbService;
        public PostService(IDbService dbService) 
        {
            _dbService = dbService;
        }
        public async Task<bool> CreatePost(Post post)
        {
            var result =
            await _dbService.EditData(
                "INSERT INTO public.post (title, body, author, likes) VALUES (@Title, @Body, @Author, @Likes)",
                post);
            return true;
        }

        public async Task<bool> DeletePost(int id)
        {
            var deletePost = await _dbService.EditData("DELETE FROM public.post WHERE id=@Id", new { id });
            return true;
        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _dbService.GetAsync<Post>("SELECT * FROM public.post where id=@id", new { id });
            return post;
        }

        public async Task<List<Post>> GetPostList()
        {
            var postList = await _dbService.GetAll<Post>("SELECT * FROM public.post", new { });
            return postList;
        }

        public async Task<Post> UpdatePost(Post post)
        {
            var updatePost =
           await _dbService.EditData(
               "UPDATE public.post SET title = @Title, body = @Body, author = @Author, likes = @Likes WHERE id = @Id",
               post);
            return post;
        }
    }
}