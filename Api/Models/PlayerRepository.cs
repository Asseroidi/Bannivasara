using System;
using System.Threading.Tasks;

namespace Api.Models
{

    public interface IRepository
{
    Task<Player> CreatePlayer(Player player);
    Task<Player> GetPlayer(Guid playerId);
    Task<Player[]> GetAllPlayers();
    Task<Player> UpdatePlayer(Guid id, ModifiedPlayer player);
    Task<Player> DeletePlayer(Guid playerId);
}


    public class PlayerRepository
    {
        
    }
}