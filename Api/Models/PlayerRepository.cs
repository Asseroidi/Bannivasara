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
    Task<Player> UpdatePlayer(Guid id, Player player);
    Task<Player> DeletePlayer(Guid playerId);

    Task<Player> GetFriend(Guid playerId, Guid friendId);
    Task<Player[]> GetAllFriends(Guid playerId);
    Task<Player> AddFriend(Guid playerId, Guid friendId);
    Task<Player> RemoveFriend(Guid playerId, Guid friendId);

     Task<Player> GetBlocked(Guid playerId, Guid blockedId);
    Task<Player[]> GetAllBlocked(Guid playerId);
    Task<Player> AddBlocked(Guid playerId, Guid blockedId);
    Task<Player> RemoveBlocked(Guid playerId, Guid blockedId);


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

        public async Task<Player> UpdatePlayer(Guid id, Player replacePlayer)
        {
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

        public async Task<Player> GetFriend(Guid playerId, Guid friendId)
        {
            var temp = GetPlayer(playerId);

            foreach(var playervar in temp.Result.friendList)
            {
                if(playervar  == friendId)
                {
                    return GetPlayer(playervar).Result;
                }
            }
            return null;
        }

        public async Task<Player[]> GetAllFriends(Guid playerId)
        {
            var listOfFriends = GetPlayer(playerId).Result.friendList;
            var betterList = new List<Player>();
            foreach(var playervar in listOfFriends)
            {
                
            }


            return ;
        }

        public async Task<Player> AddFriend(Guid playerId, Guid friendId)
        {
            var temp = GetPlayer(playerId);
            temp.Result.friendList.Add(friendId);
            return item;
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

        public async Task<Player> GetBlocked(Guid playerId, Guid blockedId)
        {
            var temp = GetPlayer(playerId);

            foreach(var playervar in temp.Result.blockedList)
            {
                if(playervar.Id  == blockedId)
                {
                    return playervar;
                }
            }
            return null;
        }

        public async Task<Player[]> GetAllBlocked(Guid playerId)
        {
            return GetPlayer(playerId).Result.blockedList.ToArray();
        }
        public async Task<Player> RemoveBlocked(Guid playerId, Player friend)
        {
            var temp = GetPlayer(playerId);

            foreach(var playervar in temp.Result.blockedList)
            {
                if (playervar.Id == friend.Id)
                {
                    temp.Result.blockedList.Remove(playervar);
                    return playervar;
                }

            }
            return null;
        }
    }
}
