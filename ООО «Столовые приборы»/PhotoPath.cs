using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООО__Столовые_приборы_
{
    partial class Product
    {
        public string fullImagePath
        {
            get
            {
                string image = ProductPhoto;
                if (String.IsNullOrEmpty(image) || String.IsNullOrWhiteSpace(image) || ProductPhoto.Equals("picture.png"))
                {
                    return "../images/picture.png";
                }
                else
                {
                    return ("../images/" + image);
                }
            }
        }
    }
}
