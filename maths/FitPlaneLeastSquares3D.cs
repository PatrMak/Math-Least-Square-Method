using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maths
{
    public class FitPlaneLeastSquares3D
    {

        public double GetPlaneAngle(List<PointsDataModel> pointsDataModels)
        {

            if (pointsDataModels.Count < 4)
                throw new Exception("Required minimun 4 points");

            var vectorNormalPlane = GetNormalPlane(pointsDataModels);

            //assign value to formula a=arcsin|B*u2|/((sqrt(A^2+B^2+C^2))*(sqrt(u2^2)))
            // Yaxis vector is u=(0,1,0)

            var A = vectorNormalPlane[0];
            var B = vectorNormalPlane[1];
            var C = 1;
            var u2 = 1;

            var numerator = B * u2; 
            var sqrtNormal = Math.Sqrt(Math.Pow(A,2) + Math.Pow(B,2) + Math.Pow(C,2));
            var sqrtYaxis = Math.Sqrt(Math.Pow(u2, 2));

            var arcsin = numerator/(sqrtNormal*sqrtYaxis);



            return Math.Round((180 / Math.PI) * Math.Asin(arcsin),4);
        }


        private Vector<double> GetNormalPlane(List<PointsDataModel> pointsDataModels)
        {
            var matrixXY = GetPointsXYMatrix(pointsDataModels);

            var vectorZ = GetPointsZVector(pointsDataModels);

            LeasSquareVectorResult vectorResult = new LeasSquareVectorResult();
           
            return vectorResult.CalculateNormalVector(matrixXY, vectorZ);
        }


        private Matrix<double> GetPointsXYMatrix(List<PointsDataModel> pointsDataModels)
        {
            int listCount = pointsDataModels.Count();

            double[] columnX = pointsDataModels.Select(p => p.X).ToArray();
            double[] columnY = pointsDataModels.Select(p => p.Y).ToArray();

            int rows = pointsDataModels.Count();

            var result = Matrix<double>.Build.Dense(rows,3,1);
            result.SetColumn(0, columnX);
            result.SetColumn(1, columnY);

            return result;
        }

        private Vector<double> GetPointsZVector(List<PointsDataModel> pointsDataModels)
        {
            int listCount = pointsDataModels.Count();
            double[] columnZ = pointsDataModels.Select(p => p.Z).ToArray();
            var result = Vector<double>.Build.Dense(columnZ);

            return result;
        }

    }
}
