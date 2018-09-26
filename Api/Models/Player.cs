using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace Api.Models

{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public bool IsBanned { get; set; }
        public DateTime CreationTime { get; set; }
        public List<Guid> friendList = new List<Guid>();
        public List<Guid> blockedList = new List<Guid>();

    }

    public class NewPlayer
    {
        public string Name { get; set; }
    }

        public class ModifiedPlayer
    {
        public int Score { get; set; }
    }

    public class BannedPlayer
    {
        public bool IsBanned { get; set; }
    }

}