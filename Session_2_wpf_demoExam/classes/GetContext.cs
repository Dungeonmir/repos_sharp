using Session_2_wpf_demoExam.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_2_wpf_demoExam.db
{
    partial class materials2Entities
    {
        private static materials2Entities _context;
        public static materials2Entities Ctx()
        {
            if (_context == null)
                _context = new materials2Entities();
            return _context;
        }
    }
}
