using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectAPI.Models
{
    public class Abilities
    {
        [Key] public int AbilityId { get; set; }
        public string Ability1 { get; set; }
        public string Ability2 { get; set; }
        public string Ability3 { get; set; }
        public string Ult { get; set; }
        public string Innate { get; set; } 

    }
}
