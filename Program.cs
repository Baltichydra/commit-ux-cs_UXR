using System;
using System.Linq;
using System.Text;
using System.Threading;
using Commit_UX_CS.Entities;

namespace Commit_UX_CS
{
    class Program
    {
        private static void Main()
        {
            var transports = PrepareTransports();
            var jobs = new TransportJob[transports.Length];
            for (var i = 0; i < transports.Length; i++){
                jobs[i] = new TransportJob(transports[i]);
            }
            foreach (var job in jobs) {
                new Thread(job.Execute).Start();
            }
            Thread.Sleep(1000);
            while (CheckForActiveJobs(jobs)){
                var info = new StringBuilder("Transports in route | ");
                foreach (var j in jobs){
                    if (j.IsActive){
                        info.Append($"Transport ID: {j.Transport.TransportId.ToString().Split("-")[0]}, " + 
                                    $"delivery ID: {j.CurrentDeliveryId}, " + 
                                    $"destination: {j.Transport.CurrentDestination.City}, " + 
                                    $"progress: {j.Transport.GetProgress()} | ");
                    }
                }
                Console.WriteLine(info);
                Thread.Sleep(1000);
            }
        }
        
        static Transport[] PrepareTransports() {
            DataProvider dataProvider = new DataProvider();
            // Pack containers
            var c1 = new DeliveryContainer();
            c1.PackContainer(new[]{
                    dataProvider.OrderItems[0],
                    dataProvider.OrderItems[1],
                    dataProvider.OrderItems[2],
                    dataProvider.OrderItems[3],
                    dataProvider.OrderItems[4]});
            var c2 = new DeliveryContainer();
            c2.PackContainer(new[]{
                    dataProvider.OrderItems[5],
                    dataProvider.OrderItems[6],
                    dataProvider.OrderItems[7]});
            var c3 = new DeliveryContainer();
            c3.PackContainer(new[]{
                    dataProvider.OrderItems[8],
                    dataProvider.OrderItems[9],
                    dataProvider.OrderItems[10],
                    dataProvider.OrderItems[11]});
            var c4 = new DeliveryContainer();
            c4.PackContainer(new[]{
                    dataProvider.OrderItems[12],
                    dataProvider.OrderItems[13]});
            var c5 = new DeliveryContainer();
            c5.PackContainer(new[]{
                    dataProvider.OrderItems[14],
                    dataProvider.OrderItems[15]});

            // Set up delivery orders
            var o1 = new DeliveryOrder(
                    new[]{c1, c2},
                    dataProvider.Accounts[0],
                    dataProvider.Accounts[0].AccountManager,
                    dataProvider.Addresses[0]);
            var o2 = new DeliveryOrder(
                    new[]{c3, c4},
                    dataProvider.Accounts[1],
                    dataProvider.Accounts[1].AccountManager,
                    dataProvider.Addresses[1]);
            var o3 = new DeliveryOrder(
                    new[]{c5},
                    dataProvider.Accounts[2],
                    dataProvider.Accounts[2].AccountManager,
                    dataProvider.Addresses[2]);

            // Set up transports
            var t1 = new Transport();
            var t2 = new Transport();
            t1.Load(new[]{o1, o2});
            t2.Load(new[]{o3});

            return new[]{t1, t2};
        }

        static bool CheckForActiveJobs(TransportJob[] jobs)
        {
            return jobs.Any(job => job.IsActive);
        }
    }
}