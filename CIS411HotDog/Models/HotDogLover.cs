using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CIS411HotDog.Models
{
    public class HotDogLover
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Bio { get; set; }

        [Required]
        public string Favorite { get; set; }

        [Required]
        public string LastAte { get; set; }

    }

    public class ProfileDBContext : DbContext
    {
        public DbSet<HotDogLover> CIS411HotDogs { get; set; }
    }
}