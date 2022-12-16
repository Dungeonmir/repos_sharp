using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2
{
    partial class session2Entities
    {
        private static session2Entities _context;
        public static session2Entities getContext()
        {
            if (_context == null)
                _context = new session2Entities();
            return _context;
        }
    }
}
