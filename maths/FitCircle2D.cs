using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Maths
{
    public class FitCircle2D
    {



        public CircleDataModel GetFittedCircle(List<PointsDataModel> pointsDataModels)
        {
            if (pointsDataModels.Count < 4)
                throw new Exception("Required minimun 4 points");


            var matrixJ = GetMatrixJXY(pointsDataModels);
            var vectorABC = GetVectorABC(matrixJ);

            var result = CalculateFittedCircleVector(vectorABC);


            return new CircleDataModel { X = result[0], Y = result[1], Radius = result[2] };
        }


        private Vector<double> CalculateFittedCircleVector(Vector<double> vectorABC)
        {
            double A = vectorABC[0];
            double B = vectorABC[1];
            double C = vectorABC[2];

            double aParams = Math.Round(-B / (2 * A),4);
            double bParams = Math.Round(-C / (2 * A), 4);
            double radius = Math.Round(Math.Sqrt(4 * A + Math.Pow(B, 2) + Math.Pow(C, 2))/(2*A),4);


            var result = Vector<double>.Build.Dense(3);

            result[0] = aParams;
            result[1] = bParams;
            result[2] = radius;

            return result;
        }


        private Vector<double> GetVectorABC(Matrix<double> matrixJ)
        {
            var vectorK = Vector<double>.Build.Dense(4, 1);

            LeasSquareVectorResult vectorResult = new LeasSquareVectorResult();

            return vectorResult.CalculateNormalVector(matrixJ, vectorK);
        }

        private Matrix<double> GetMatrixJXY(List<PointsDataModel> pointsDataModels)
        {
            int rows = pointsDataModels.Count();

            double[] columnX = pointsDataModels.Select(p => p.X).ToArray();
            double[] columnY = pointsDataModels.Select(p => p.Y).ToArray();
            double[] columnSqueredXY = pointsDataModels.Select(p => Math.Pow(p.X, 2) + Math.Pow(p.Y, 2)).ToArray();

            return AddColumnToMatrix(rows, columnSqueredXY, columnX, columnY);
        }

        private Matrix<double> AddColumnToMatrix(int rows, double[] column1, double[] column2, double[] column3)
        {
            var result = Matrix<double>.Build.Dense(rows, 3, 1);

            result.SetColumn(0, column1);
            result.SetColumn(1, column2);
            result.SetColumn(2, column3);

            return result;
        }
    }
}
