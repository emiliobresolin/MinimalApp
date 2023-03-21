using MinimalApp.Models;

namespace MinimalApp.Services
{
    public interface ICoffeeService
    {
        public CoffeeModel Create(CoffeeModel coffee); //this is about the coffee that is about to be created
        public CoffeeModel? Get(int id); //this is about returning the coffee by its ID
        public List<CoffeeModel> List(); //this is about returning a list of coffees
        public CoffeeModel? Update(CoffeeModel coffee); //this is about changing a coffee model
        public bool Delete(int id); //this is about delete a coffee model
    }
}
