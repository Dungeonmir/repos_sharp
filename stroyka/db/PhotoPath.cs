using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stroyka.db
{
    partial class Material
    {
        public string fullImagePath
        {
            get
            {
                if (String.IsNullOrEmpty(image) || String.IsNullOrWhiteSpace(image))
                {
                    return "../Resources/plug.jpg";
                }
                else
                {
                    return ("../Resources/" + image);
                }
            }
        }
    }
}
