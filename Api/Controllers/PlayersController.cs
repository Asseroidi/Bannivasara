using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController
    {
        PlayerProcessor myProcessor;
        public PlayersController(PlayerProcessor processor)
        {
            myProcessor = processor;

        }
        
        [HttpGet("{id}")]
        public Task<Player> Get(Guid id)
        {
            return myProcessor.Get(id);
        }

        [HttpGet]
        public Task<Player[]> GetAll()
        {
            return myProcessor.GetAll();
        }

        [HttpPost]
        public Task<Player> Create([FromBody] NewPlayer player)
        {
            return myProcessor.Create(player);
        }

        [HttpPut("{playerId}")]
        public Task<Player> Modify(Guid playerId, [FromBody] ModifiedPlayer player)
        {
            return myProcessor.Modify(playerId, player);
        }

        [HttpDelete("{playerId}")]
        public Task<Player> Delete(Guid playerId)
        {
            return myProcessor.Delete(playerId);
        }

        [HttpPut("{playerId}")]
        public Task<Player> BanPlayer (Guid playerId, [FromBody] BannedPlayer player)
        {
            return myProcessor.BanPlayer(playerId, player);
        }

        // // [Route("{playerId}/friends")]
        // [HttpGet("{playerId}/friends/{friendId}")]
        // public Task<Player> GetFriend(Guid playerId, Guid friendId)
        // {
        //     return myProcessor.GetFriend(playerId, friendId);
        // }

        // // [Route("{playerId}/friends")]
        // [HttpGet("{playerId}/friends")]
        // public Task<Player[]> GetAllFriends(Guid playerId)
        // {
        //     return myProcessor.GetAllFriends(playerId);
        // }

        // // [Route("{playerId}/friends")]
        // [HttpPut("{playerId}/friends/{friendId}")]
        // public Task<Player> AddFriend (Guid playerId, Guid friendId)
        // {
        //     return myProcessor.AddFriend(playerId, friendId);
        // }

        // // [Route("{playerId}/friends")]
        // [HttpDelete("{playerId}/friends/{friendId}")]
        // public Task<Player> RemoveFriend (Guid playerId, Guid friendId)
        // {
        //     return myProcessor.RemoveFriend(playerId, friendId);
        // }

        // // [Route("{playerId}/blocked")]
        // // [HttpGet("{blockedId}")]
        // [HttpGet("{playerId}/blocked/{blockedId}")]
        // public Task<Player> GetBlocked(Guid playerId, Guid blockedId)
        // {
        //     return myProcessor.GetBlocked(playerId, blockedId);
        // }

        // // [Route("{playerId}/blocked")]
        // [HttpGet("{playerId}/blocked")]
        // public Task<Player[]> GetAllBlocked(Guid playerId)
        // {
        //     return myProcessor.GetAllBlocked(playerId);
        // }

        // // [Route("{playerId}/blocked")]
        // [HttpPut("{playerId}/blocked/{blockedId}")]
        // public Task<Player> AddBlocked(Guid playerId, Guid blockedId)
        // {
        //     return myProcessor.AddBlocked(playerId, blockedId);
        // }

        // // [Route("{playerId}/blocked")]
        // [HttpDelete("{{playerId}/blocked/blockedId}")]
        // public Task<Player> RemoveBlocked(Guid playerId, Guid blockedId)
        // {
        //     return myProcessor.RemoveBlocked(playerId, blockedId);
        // }
        // //AddFriend, GetFriend, DeleteFriend
    }
}
