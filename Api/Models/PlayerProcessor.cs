using System;
using System.Threading.Tasks;

namespace Api.Models
{
    public class PlayerProcessor
    {
        IRepository myRepository;

        public PlayerProcessor(IRepository repository)

        {
            myRepository = repository;
        }

        public Task<Player> Get(Guid id)
        {
            return myRepository.GetPlayer(id);
        }
        public Task<Player[]> GetAll()
        {
            return myRepository.GetAllPlayers();
        }
        public Task<Player> Create(NewPlayer player)
        {
            Player forwarded = new Player();
            forwarded.Name = player.Name;
            forwarded.CreationTime = DateTime.Now;
            forwarded.IsBanned = false;
            forwarded.Score = 0;
            forwarded.Id = Guid.NewGuid();
            return myRepository.CreatePlayer(forwarded);
        }
        public Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            return myRepository.UpdatePlayer(id, player);
        }

        public Task<Player> Delete(Guid id)
        {
            return myRepository.DeletePlayer(id);
        }
    }
}