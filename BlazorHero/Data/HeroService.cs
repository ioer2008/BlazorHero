using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorHero.Data
{
    public class HeroService
    {
        private static List<Hero> Heroes = new List<Hero>()
        {
            new Hero {Id = 11, Name = "Mr. Nice"},
            new Hero {Id = 12, Name = "Narco"},
            new Hero {Id = 13, Name = "Bombasto"},
            new Hero {Id = 14, Name = "Celeritas"},
            new Hero {Id = 15, Name = "Magneta"},
            new Hero {Id = 16, Name = "RubberMan"},
            new Hero {Id = 17, Name = "Dynama"},
            new Hero {Id = 18, Name = "Dr IQ"},
            new Hero {Id = 19, Name = "Magma"},
            new Hero {Id = 20, Name = "Tornado"}
        };

        public IList<Hero> GetHeroes(string name)
        {
            var heroes = Heroes;

            if (!string.IsNullOrWhiteSpace(name?.Trim()))
            {
                heroes = Heroes.Where(o => o.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()))
                    .ToList();
            }

            return heroes.OrderByDescending(o => o.Id).ToList();
        }

        public IList<Hero> GetTopHeroes()
        {
            return Heroes.Take(4).ToList();
        }

        public Hero GetById(int id)
        {
            return Heroes.FirstOrDefault(o => o.Id == id);
        }

        public Hero Create(Hero hero)
        {
            hero.Id = Heroes.Max(o => o.Id) + 1;
            Heroes.Add(hero);

            return GetById(hero.Id);
        }

        public Hero Update(int id, Hero input)
        {
            var hero = GetById(id);
            if (hero != null)
            {
                hero.Name = input.Name;
            }

            return hero;
        }

        public bool Delete(int id)
        {
            var hero = GetById(id);
            if (hero != null)
            {
               return Heroes.Remove(hero);
            }

            return false;
        }
    }
}
