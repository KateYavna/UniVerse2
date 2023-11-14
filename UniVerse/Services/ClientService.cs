using UniVerse.Models;
using UniVerse.Services.Interfaces;

namespace UniVerse.Services
{
    public class ClientService : IClientService
    {
        private readonly IDbService _dbService;
        public ClientService(IDbService dbService)
        {
            _dbService = dbService;
        }
        public async Task<bool> CreateClient(Client client)
        {
            var result =
            await _dbService.EditData(
                "INSERT INTO public.client (id, name, email, password) VALUES (@Id, @Name, @Email, @Password)",
                client);
            return true;
        }

        public async Task<bool> DeleteClient(int id)
        {
            var deleteClient = await _dbService.EditData("DELETE FROM public.client WHERE id=@Id", new { id });
            return true;
        }

        public async Task<Client> GetClient(int id)
        {
            var client = await _dbService.GetAsync<Client>("SELECT * FROM public.client where id=@id", new { id });
            return client;
        }

        public async Task<List<Client>> GetClientList()
        {
            var clientList = await _dbService.GetAll<Client>("SELECT * FROM public.client", new { });
            return clientList;
        }

        public async Task<Client> UpdateClient(Client client)
        {
            var updateClient =
            await _dbService.EditData(
                "UPDATE public.client SET name = @Name, password = @Password, email = @Email WHERE id = @Id",
                client);
            return client;
        }
    }
}