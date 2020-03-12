using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorHero.Data
{
    public class Hero
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
