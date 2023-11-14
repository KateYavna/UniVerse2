using UniVerse.Models;

namespace UniVerse.Services.Interfaces
{
    public interface IClientService
    {
        Task<bool> CreateClient(Client client);
        Task<Client> GetClient(int id);
        Task<List<Client>> GetClientList();
        Task<Client> UpdateClient(Client client);
        Task<bool> DeleteClient(int id);
    }
}