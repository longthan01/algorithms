using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_1_8
    {
        public void ZeroMatrix(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            bool[] rFlags = Enumerable.Repeat(false, rows).ToArray();
            bool[] cFlags = Enumerable.Repeat(false, cols).ToArray();

            int r = 0;
            while (r < rows)
            {
                int c = 0;
                while (c < cols)
                {
                    if (matrix[r][c] == 0)
                    {
                        rFlags[r] = true;
                        cFlags[c] = true;
                    }
                    c++;
                }

                r++;
            }

            for (int i = 0; i < rFlags.Length; i++)
            {
                if (rFlags[i])
                {
                    NullifyRow(matrix, i);
                }
            }

            for (int i = 0; i < cFlags.Length; i++)
            {
                if (cFlags[i])
                {
                    NullifyCol(matrix, i);
                }
            }

        }

        private void NullifyRow(int[][] matrix, int r)
        {
            for (int i = 0; i < matrix[0].Length; i++)
            {
                matrix[r][i] = 0;
            }
        }

        private void NullifyCol(int[][] matrix, int c)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i][c] = 0;
            }
        }
    }
}
