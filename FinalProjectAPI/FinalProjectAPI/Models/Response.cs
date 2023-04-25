using System;
using Microsoft.EntityFrameworkCore;
namespace FinalProjectAPI.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public List<Champion> champions { get; set; } = new();

        public List<Abilities> abilities { get; set; } = new(); 
    }
}
