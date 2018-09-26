using System;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Api.Models
{

    public interface IRepository
{
    Task<Player> CreatePlayer(Player player);
    Task<Player> GetPlayer(Guid playerId);
    Task<Player[]> GetAllPlayers();
    Task<Player> UpdatePlayer(Guid playerId, ModifiedPlayer player);
    Task<Player> DeletePlayer(Guid playerId);
<<<<<<< HEAD
    Task<Player> BanPlayer(Guid playerId, BannedPlayer player);
=======
    Task<Player> BanPlayer(Guid id, BannedPlayer player);

>>>>>>> d2dc667c954aab4ae55312d3e36d3a2e9006d831
    Task<Player> GetFriend(Guid playerId, Guid friendId);
    Task<Player[]> GetAllFriends(Guid playerId);
    Task<Player> AddFriend(Guid playerId, Guid friendId);
    Task<Player> RemoveFriend(Guid playerId, Guid friendId);
<<<<<<< HEAD
    Task<Player> GetBlocked(Guid playerId, Guid blockedId);
    Task<Player[]> GetAllBlocked(Guid playerId);
    Task<Player> AddBlocked(Guid playerId, Guid blockedId);
    Task<Player> RemoveBlocked(Guid playerId, Guid blockedId);
    }
=======

     Task<Player> GetBlocked(Guid playerId, Guid friendId);
    Task<Player[]> GetAllBlocked(Guid playerId);
    Task<Player> AddBlocked(Guid playerId, Guid friendId);
    Task<Player> RemoveBlocked(Guid playerId, Guid friendId);

}
>>>>>>> d2dc667c954aab4ae55312d3e36d3a2e9006d831


    public class PlayerRepository : IRepository
    {
        
        MongoClient client;
        IMongoDatabase database;
        IMongoCollection<Player> playerCollection;
        
        public PlayerRepository()
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("game");
            playerCollection = database.GetCollection<Player>("players");
        }

        public async Task<Player> CreatePlayer(Player player)
        {
            await playerCollection.InsertOneAsync(player);
            return player;
        }

        public async Task<Player> GetPlayer(Guid playerId)
        {
            var filter = Builders<Player>.Filter.Eq("id", playerId);
            return await playerCollection.Find(filter).FirstAsync();
        }

        public async Task<Player[]> GetAllPlayers()
        {
            List<Player> players = await playerCollection.Find(new BsonDocument()).ToListAsync();
            return players.ToArray();
        }

        public async Task<Player> UpdatePlayer(Guid id, ModifiedPlayer player)
        {
            Player replacePlayer = GetPlayer(id).Result;
            replacePlayer.Score = player.Score;
            var filter = Builders<Player>.Filter.Eq("id", id);
            await playerCollection.ReplaceOneAsync(filter, replacePlayer);
            return replacePlayer;
        }

        public async Task<Player> DeletePlayer(Guid playerId)
        {
            var filter = Builders<Player>.Filter.Eq("id", playerId);
            playerCollection.DeleteOne(filter);
            return null;
        }

        public async Task<Player[]> GetAllFriends(Guid playerId)
        {
            return GetPlayer(playerId).Result.friendList.ToArray();
        }
        public async Task<Player> RemoveFriend(Guid playerId, Player friend)
        {
            var temp = GetPlayer(playerId);

            foreach(var playervar in temp.Result.friendList)
            {
                if (playervar.Id == friend.Id)
                {
                    temp.Result.friendList.Remove(playervar);
                    return playervar;
                }

            }
            return null;
        }


//implement later!
    Task<Player> GetBlocked(Guid playerId, Guid friendId);
    Task<Player[]> GetAllBlocked(Guid playerId);
    Task<Player> AddBlocked(Guid playerId, Guid friendId);
    Task<Player> RemoveBlocked(Guid playerId, Guid friendId);
    }
}
