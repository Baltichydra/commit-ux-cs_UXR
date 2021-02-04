using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Commit_UX_CS.Entities
{
    
    public class Account {
        public Guid AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AccountManager AccountManager { get; set; }
    }
    
    public class Address {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int ApartmentNumber { get; set; }
    }
    
    public class AccountManager {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }
    
    public class OrderItem {
        public int Value { get; set;}
        public string Description { get; set;}
    }
    
    public class DeliveryContainer {
        public Dictionary<Guid, OrderItem> Orders { get; set;}

        public void PackContainer(OrderItem[] orderItems){
            Orders = orderItems.ToDictionary(item => Guid.NewGuid());
        }
    }
    
    public class DeliveryOrder {
        private Dictionary<Guid, DeliveryContainer> Containers { get; }
        private Account Account { get; }
        private AccountManager AccountManager { get; }
        public Address DeliveryAddress { get; }

        public DeliveryOrder(DeliveryContainer[] containers, Account account, AccountManager manager, Address address){
            Containers = new Dictionary<Guid, DeliveryContainer>();
            foreach (var container in containers) {
                Containers.Add(Guid.NewGuid(), container);
            }
            Account = account;
            AccountManager = manager;
            DeliveryAddress = address;
        }
    }
    
    public class Transport {
        public Guid TransportId { get; }
        public Dictionary<Guid, DeliveryOrder> Orders { get; }
        public Address CurrentDestination { get; set;}
        public int DestinationTime { get; set;}
        public int ProgressTime { get; set;}

        public Transport(){
            TransportId = Guid.NewGuid();
            Orders = new Dictionary<Guid, DeliveryOrder>();
        }

        public void Load(DeliveryOrder[] orders){
            foreach (var order in orders) {
                Orders.Add(Guid.NewGuid(), order);
            }
        }

        public string GetProgress()
        {
            return ((float) ProgressTime / DestinationTime * 100).ToString("F0") + "%";
        }
    }
    
    public class TransportJob {
        public Transport Transport { get; }
        public bool IsActive { get; private set;}
        public string CurrentDeliveryId { get; private set;}

        public TransportJob(Transport transport)
        {
            Transport = transport;
            IsActive = false;
        }

        public void Execute(){
            if (Transport.Orders.Count > 0){
                Console.WriteLine($"Transport {Transport.TransportId} has departed.");
                IsActive = true;
                foreach (var order in Transport.Orders) {
                    Transport.CurrentDestination = order.Value.DeliveryAddress;
                    Transport.DestinationTime = new Random().Next(10, 100);
                    Transport.ProgressTime = 0;
                    CurrentDeliveryId = order.Key.ToString().Split("-")[0];
                    while (Transport.DestinationTime - Transport.ProgressTime != 0) {
                        Thread.Sleep(200);
                        Transport.ProgressTime++;
                    }
                }
                IsActive = false;
            }
            else {
                Console.WriteLine($"Transport {Transport.TransportId} is empty.");
            }
        }
    }
    
}
