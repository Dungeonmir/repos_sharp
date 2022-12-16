using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООО__Столовые_приборы_
{
    partial class TradeEntities
    {
        private static TradeEntities _context;
        public static TradeEntities getContext()
        {
            if (_context == null)
                _context = new TradeEntities();
            return _context;
        }
    }
}
