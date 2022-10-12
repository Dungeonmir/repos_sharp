using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session1_framework.data
{
    partial class Agent
    {
        public string fullImagePath
        {
            get
            {
                if (String.IsNullOrEmpty(Logo) || String.IsNullOrWhiteSpace(Logo) || Logo.Equals("picture.png"))
                {
                    return "/images/picture.png";
                }
                else
                {
                    return ("/images/" + Logo);
                }
            }
        }
    }
}
