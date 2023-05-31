using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app1.Models
{
    public class MatrixModel
    {
        public int[,] Matrix { get; set; }

        public MatrixModel(int[,] ints)
        {
            Matrix = ints;
        }
    }
}
