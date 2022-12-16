using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2
{
    partial class Material
    {
        public string suppliers
        {
            get
            {
                //not working
                return session2Entities.getContext().Supplier.Find(keyValues: idMaterial).supplierName.ToList().ToString();
            }
        }
    }
}
