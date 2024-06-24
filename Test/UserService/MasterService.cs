using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DB.Models;

namespace Test.UserService
{
    internal class MasterService : AbstractService.AbstractService
    {
        public MasterService() : base() { }

        public List<OrderClient> GetOrderClientToMaster(int masterId)
        {
            try
            {

                return _db.OrderClients.Where(x => x.MasterId == masterId).Include(x => x.Master).Include(x => x.Status).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SetStatus(int orderId, string status)
        {
            try
            {
                OrderClient orderClient = _db.OrderClients.FirstOrDefault(x => x.Id == orderId)!;
                orderClient.StatusId = _db.Statuss.FirstOrDefault(x => x.NameStatus == status)!.Id;

                _db.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
