using UniVerse.Models;

namespace UniVerse.Services.Interfaces
{
    public interface IPostService
    {
        Task<bool> CreatePost(Post post);
        Task<Post> GetPost(int id);
        Task<List<Post>> GetPostList();
        Task<Post> UpdatePost(Post post);
        Task<bool> DeletePost(int id);
    }
}