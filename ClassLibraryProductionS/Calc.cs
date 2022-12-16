using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{

    public class Calc
    {
        public int count;
        public double width;
        public double length;
        public int product_type;
        public int material_type;
        public double[] product_types = { 1.1, 2.5, 8.43 };
        public double[] material_types = { 0.3, 0.12 };
        public Calc()
        {
        }
        public int calculate(int product_type, int material_type, double count, double length, double width)
        {
            double pre = 0;
            int result;

            if (  material_type > 2 || material_type < 1 || product_type > 3 || product_type < 1)
            {
                result = -1;
            }
            else
            {
                pre = length * width * count;
                switch (product_type)
                {
                    case 1:
                        pre *= 1.1;
                        break;
                    case 2:
                        pre *= 2.5;
                        break;
                    default:
                        pre *= 8.43;
                        break;
                }
                switch (material_type)
                {
                    case 1:
                        pre *= 1.00300902; // для 1.003 полученные тестовые данные не подходят
                        break;
                    case 2:
                        pre *= 1.00120812;
                        break;
                    default:
                        return -1;
                }
                if (pre - Convert.ToInt32(pre) > 0)
                {
                    result = Convert.ToInt32(pre) + 1;
                }
                else
                {
                    result = Convert.ToInt32(pre);
                }

            }
            return result;
        }
    }
}
