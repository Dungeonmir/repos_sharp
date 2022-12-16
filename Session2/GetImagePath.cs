using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2
{
    partial class Material
    {
        public string fullImagePath
        {
            get
            {
                if (String.IsNullOrEmpty(image) || String.IsNullOrWhiteSpace(image) || image == "picture.png")
                {
                    return "../Images/picture.png";
                }
                else
                {
                    return ("../Images" + image);
                }
            }
        }
    }
}
