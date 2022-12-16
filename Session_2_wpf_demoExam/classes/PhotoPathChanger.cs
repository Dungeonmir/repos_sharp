using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_2_wpf_demoExam.db
{
    partial class Product
    {
        public string fullImagePath
        {
            get
            {
                if (string.IsNullOrEmpty(Image) || string.IsNullOrWhiteSpace(Image))
                {
                    return "../images/picture.png";
                }

                return "../images/products/" + Image;
            }
        }
    }

    partial class Material
    {
        public string fullImagePath
        {
            get
            {
                if (string.IsNullOrEmpty(Image) || string.IsNullOrWhiteSpace(Image))
                {
                    return "../images/picture.png";
                }

                return "../images/materials/" + Image;
            }
        }
    }
}
