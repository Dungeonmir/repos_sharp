using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stroyka.db
{
    partial class dbStroyka
    {
        private static dbStroyka _context;
        public static dbStroyka getContext()
        {
            if (_context == null)
                _context = new dbStroyka();
            return _context;
        }
    }
}
