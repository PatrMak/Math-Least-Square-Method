using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maths
{
    public class LeasSquareVectorResult
    {
        public Vector<double> CalculateNormalVector(Matrix<double> matrixXY, Vector<double> vectorZ)
        {
            var result = (matrixXY.Transpose() * matrixXY).Inverse() * (matrixXY.Transpose() * vectorZ);

            return result;
        }

    }
}
