﻿using MinimalApp.Models;
using MinimalApp.Repositories;

namespace MinimalApp.Services
{
    public class CoffeeService : ICoffeeService
    {
        public CoffeeModel Create(CoffeeModel coffee)
        {
            coffee.Id = CoffeeRepository.Coffees.Count + 1;
            CoffeeRepository.Coffees.Add(coffee);

            return coffee;
        }

        public CoffeeModel? Get(int id)
        {
            var coffee = CoffeeRepository.Coffees.FirstOrDefault(o => o.Id == id);

            if (coffee is null) return null;

            return coffee;
        }

        public List<CoffeeModel> List()
        {
            var coffees = CoffeeRepository.Coffees;

            return coffees;
        }

        public CoffeeModel? Update(CoffeeModel newCoffee)
        {
            var oldCoffee = CoffeeRepository.Coffees.FirstOrDefault(o => o.Id == newCoffee.Id); //this is about getting the old coffee by the ID.

            if (oldCoffee is null) return null;

            oldCoffee.Name = newCoffee.Name; //if we find the old coffee ID we update it.
            oldCoffee.Description = newCoffee.Description;

            return newCoffee; //and then returing it back to the user.
        }

        public bool Delete(int id)
        {
            var oldCoffee = CoffeeRepository.Coffees.FirstOrDefault(o => o.Id == id); //this is about finding the coffee

            if (oldCoffee is null) return false;

            CoffeeRepository.Coffees.Remove(oldCoffee); //this is about removig the coffee from the list

            return true;
        }

    }
}
