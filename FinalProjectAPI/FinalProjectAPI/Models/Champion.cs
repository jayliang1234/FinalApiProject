using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectAPI.Models
{
    public class Champion
    {
        [Key] public int ChampionId { get; set; }
        public string ChampionName { get; set; }
        public string ChampionRole { get; set; }
        public int Difficulty { get; set; }
        public Abilities? Ability { get; set; }

    }
}
