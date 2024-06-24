using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DB.Models;

namespace Test.UserService
{
    internal class ManagerService : AbstractService.AbstractService
    {
        public ManagerService() : base() { }

        public List<string> LoadMaster()
        {
            try
            {
                return _db.Masters.Select(x => x.FullNameMaster).ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<OrderClient> GetListOrders()
        {
            try
            {
                return _db.OrderClients.Include(x => x.Status).Include(x => x.Master).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void AddOrderClient(string fullNameClient, string phoneClient, string deviceClient, string problemClient, string Master)
        {
            try
            {
                OrderClient orderClient = new OrderClient();
                orderClient.FullNameClient = fullNameClient;
                orderClient.Phone = phoneClient;
                orderClient.Device = deviceClient;
                orderClient.Problem = problemClient;
                orderClient.StatusId = _db.Statuss.FirstOrDefault(x => x.NameStatus == "Обратывается")!.Id;
                orderClient.DateTime = DateTime.Now;
                orderClient.MasterId = _db.Masters.FirstOrDefault(x => x.FullNameMaster == Master)!.Id;

                _db.Add(orderClient);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
