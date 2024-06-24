using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DB.Db_Context;

namespace Test.AbstractService
{
    abstract class AbstractService
    {
        protected Db_Context _db;
        protected AbstractService() 
        {
            try
            {
                _db = new Db_Context();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
