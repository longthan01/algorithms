using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_1_7
    {
        // rotate matrix 90 degree clockwise
        public void Rotate(int[][] imageMatrix)
        {
            int matrixLength = imageMatrix.Length;

            int nestedSquares = matrixLength / 2;
            for (int r = 0; r < nestedSquares; r++)
            {
                for (int c = r; c < matrixLength - r - 1; c++)
                {
                    int topLeft = imageMatrix[r][c];
                    imageMatrix[r][c] = imageMatrix[matrixLength - c - 1][r];
                    imageMatrix[matrixLength - c - 1][r] = imageMatrix[matrixLength - r - 1][matrixLength - c - 1];
                    imageMatrix[matrixLength - r - 1][matrixLength - c - 1] = imageMatrix[c][matrixLength - r - 1];
                    imageMatrix[c][matrixLength - r - 1] = topLeft;
                }
            }
        }
    }
}
