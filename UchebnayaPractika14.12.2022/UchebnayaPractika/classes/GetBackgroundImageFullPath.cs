using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UchebnayaPractika.db
{
    partial class Theme
    {
        public string BackgroundFullImagePath
        {
            get
            {
                if (string.IsNullOrEmpty(Image) || string.IsNullOrWhiteSpace(Image))
                {
                    return string.Empty;
                }
                return Directory.GetCurrentDirectory() + "/images/" + Image;
            }
        }
    }
}
