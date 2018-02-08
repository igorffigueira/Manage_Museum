using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.DataBaseModel;

namespace ManageMuseumData.GetData
{
    /// <summary>
    /// classe abstrata responsável pela a logica da aplicação
    /// </summary>
    public abstract class AData
    {
      
        

        public DbAccess db { get; set; }

        protected AData()
        {
            db = DbAccess.getInstance();          
        }

      
    }
}
