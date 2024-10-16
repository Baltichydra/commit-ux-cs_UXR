using System;
using Commit_UX_CS.Entities;

namespace Commit_UX_CS
{
    public class DataProvider
    {
        public UserAccountManager[] AccountManagers { get; }
        public Account[] Accounts { get; }
        public Address[] Addresses { get; }
        public OrderItem[] OrderItems { get; }

        private readonly Random _random = new Random();
        
        public DataProvider(){
            AccountManagers = new []{
                    new AccountManager{FirstName = GetRandomItem(ItemType.FirstName), LastName = GetRandomItem(ItemType.SecondName), Department = "WestCorp"},
                    new AccountManager{FirstName = GetRandomItem(ItemType.FirstName), LastName = GetRandomItem(ItemType.SecondName), Department = "EastCorp"},
                    new AccountManager{FirstName = GetRandomItem(ItemType.FirstName), LastName = GetRandomItem(ItemType.SecondName), Department = "NorthCorp"}
            };

            Accounts = new []{
                    new Account{ AccountId = Guid.NewGuid(), FirstName = GetRandomItem(ItemType.FirstName), LastName = GetRandomItem(ItemType.SecondName), AccountManager = AccountManagers[0]},
                    new Account{ AccountId = Guid.NewGuid(), FirstName = GetRandomItem(ItemType.FirstName), LastName = GetRandomItem(ItemType.SecondName), AccountManager = AccountManagers[0]},
                    new Account{ AccountId = Guid.NewGuid(), FirstName = GetRandomItem(ItemType.FirstName), LastName = GetRandomItem(ItemType.SecondName), AccountManager = AccountManagers[1]},
                    new Account{ AccountId = Guid.NewGuid(), FirstName = GetRandomItem(ItemType.FirstName), LastName = GetRandomItem(ItemType.SecondName), AccountManager = AccountManagers[2]}
            };

            Addresses = new []{
                    new Address{Country = "United States", City = GetRandomItem(ItemType.City), Street = GetRandomItem(ItemType.Street), BuildingNumber = _random.Next(0, 100), ApartmentNumber = _random.Next(0, 10)},
                    new Address{Country = "United States", City = GetRandomItem(ItemType.City), Street = GetRandomItem(ItemType.Street), BuildingNumber = _random.Next(0, 100), ApartmentNumber = _random.Next(0, 10)},
                    new Address{Country = "United States", City = GetRandomItem(ItemType.City), Street = GetRandomItem(ItemType.Street), BuildingNumber = _random.Next(0, 100), ApartmentNumber = _random.Next(0, 10)},
                    new Address{Country = "United States", City = GetRandomItem(ItemType.City), Street = GetRandomItem(ItemType.Street), BuildingNumber = _random.Next(0, 100), ApartmentNumber = _random.Next(0, 10)},
                    new Address{Country = "United States", City = GetRandomItem(ItemType.City), Street = GetRandomItem(ItemType.Street), BuildingNumber = _random.Next(0, 100), ApartmentNumber = _random.Next(0, 10)},
                    new Address{Country = "United States", City = GetRandomItem(ItemType.City), Street = GetRandomItem(ItemType.Street), BuildingNumber = _random.Next(0, 100), ApartmentNumber = _random.Next(0, 10)}
            };

            OrderItems = new [] {
                    new OrderItem{Value = _random.Next(10, 100), Description = GetRandomItem(ItemType.OrderDescription)},
                    new OrderItem{Value = _random.Next(10, 100), Description = GetRandomItem(ItemType.OrderDescription)},
                    new OrderItem{Value = _random.Next(10, 100), Description = GetRandomItem(ItemType.OrderDescription)},
                    new OrderItem{Value = _random.Next(10, 100), Description = GetRandomItem(ItemType.OrderDescription)},
                    new OrderItem{Value = _random.Next(10, 100), Description = GetRandomItem(ItemType.OrderDescription)},
                    new OrderItem{Value = _random.Next(10, 100), Description = GetRandomItem(ItemType.OrderDescription)},
                    new OrderItem{Value = _random.Next(10, 100), Description = GetRandomItem(ItemType.OrderDescription)},
                    new OrderItem{Value = _random.Next(10, 100), Description = GetRandomItem(ItemType.OrderDescription)},
                    new OrderItem{Value = _random.Next(10, 100), Description = GetRandomItem(ItemType.OrderDescription)},
                    new OrderItem{Value = _random.Next(10, 100), Description = GetRandomItem(ItemType.OrderDescription)},
                    new OrderItem{Value = _random.Next(10, 100), Description = GetRandomItem(ItemType.OrderDescription)},
                    new OrderItem{Value = _random.Next(10, 100), Description = GetRandomItem(ItemType.OrderDescription)},
                    new OrderItem{Value = _random.Next(10, 100), Description = GetRandomItem(ItemType.OrderDescription)},
                    new OrderItem{Value = _random.Next(10, 100), Description = GetRandomItem(ItemType.OrderDescription)},
                    new OrderItem{Value = _random.Next(10, 100), Description = GetRandomItem(ItemType.OrderDescription)},
                    new OrderItem{Value = _random.Next(10, 100), Description = GetRandomItem(ItemType.OrderDescription)}
            };
        }

        private string GetRandomItem(ItemType type){
            string[] firstNames = {"James", "John", "Robert", "Michael", "William", "Mary", "Patricia", "Jennifer", "Linda", "Elizabeth"};
            string[] secondNames = {"Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis"};
            string[] cities = {"New York", "Los Angeles", "Washington", "Denver", "Chicago", "Boston", "San Francisco", "Philadelphia", "Seattle", "Portland"};
            string[] streets = {"Bradford Road", "Church Road", "Hill Street", "Wharf Road", "Brown Street", "Pound Lane"};
            string[] orderDescriptions = {"Books", "Computers", "Electronics", "Fashion", "Health", "Household", "Music", "Sport", "Tools", "Toys"};

            int i;
            switch (type){
                case ItemType.FirstName:
                    i = _random.Next(0, firstNames.Length);
                    return firstNames[i];
                case ItemType.SecondName:
                    i = _random.Next(0, secondNames.Length);
                    return secondNames[i];
                case ItemType.City:
                    i = _random.Next(0, cities.Length);
                    return cities[i];
                case ItemType.Street:
                    i = _random.Next(0, streets.Length);
                    return streets[i];
                case ItemType.OrderDescription:
                    i = _random.Next(0, orderDescriptions.Length);
                    return orderDescriptions[i];
            }
            return "NA";
        }

        private enum ItemType{
            FirstName,
            SecondName,
            City,
            Street,
            OrderDescription
        }
    }
    
    
}