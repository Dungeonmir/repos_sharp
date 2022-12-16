using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UchebnayaPractika.db
{
    partial class uchebnayaPraktikaEntities
    {
        private static uchebnayaPraktikaEntities _context = new uchebnayaPraktikaEntities();

        public static uchebnayaPraktikaEntities getContext()
        {
            if( _context == null)
            {
                _context = new uchebnayaPraktikaEntities();
            }
            return _context;
        }
    }
}
