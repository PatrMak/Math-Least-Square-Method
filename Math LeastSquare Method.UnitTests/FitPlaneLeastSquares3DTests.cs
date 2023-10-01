using Maths;
using NUnit.Framework;
using System.Collections.Generic;

namespace Math_LeastSquare_Method.UnitTests
{
    public class FitPlaneLeastSquares3DTests
       {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetPlaneAngle_PlaneIsInclinedToXaxis_ReturnPositiveXaxisAngle()
        {
            // Arange
            var planeAngle = new FitPlaneLeastSquares3D();
            // Act
            var points = new List<PointsDataModel>{
                new PointsDataModel{X=127.032,Y=127.050,Z=15.288},
                new PointsDataModel{X=127.043,Y=-127.047,Z=15.282},
                new PointsDataModel{X=127.051,Y=-127.060,Z=15.285},
                new PointsDataModel{X=127.060,Y=127.038,Z=15.291},
            };
            var result = planeAngle.GetPlaneAngle(points);
            // Assert
            Assert.That(result, Is.EqualTo(0.0014));
        }

        [Test]
        public void GetPlaneAngle_PlaneIsInclinedToXAxis_ReturnNegativeXAxisAngle()
        {
            // Arange
            var planeAngle = new FitPlaneLeastSquares3D();
            // Act
            var points = new List<PointsDataModel>{
                new PointsDataModel{X=127.032,Y=127.050,Z=15.298},
                new PointsDataModel{X=127.043,Y=-127.047,Z=15.296},
                new PointsDataModel{X=127.051,Y=-127.060,Z=15.295},
                new PointsDataModel{X=127.060,Y=127.038,Z=15.292},
                new PointsDataModel{X=127.060,Y=127.038,Z=15.291},
            };
            var result = planeAngle.GetPlaneAngle(points);
            // Assert
            Assert.That(result, Is.EqualTo(-0.0002));
        }

        [Test]
        public void GetPlaneAngle_PlaneIsInclinedToYAxis_ReturnZero()
        {
            // Arange
            var planeAngle = new FitPlaneLeastSquares3D();
            // Act
            var points = new List<PointsDataModel>{
                new PointsDataModel{X=127.032,Y=127.050,Z=15.298},
                new PointsDataModel{X=127.043,Y=-127.047,Z=15.298},
                new PointsDataModel{X=127.051,Y=-127.060,Z=15.294},
                new PointsDataModel{X=127.060,Y=127.038,Z=15.294},
            };
            var result = planeAngle.GetPlaneAngle(points);
            // Assert
            Assert.That(result, Is.EqualTo(0.0));
        }

        [Test]
        public void GetPlaneAngle_NotRquiredPointsCount_ThrowExeption()
        {
            // Arange
            var planeAngle = new FitPlaneLeastSquares3D();
            // Act
            var points = new List<PointsDataModel>{
                new PointsDataModel{X=127.032,Y=127.050,Z=15.298},
                new PointsDataModel{X=127.043,Y=-127.047,Z=15.298},
            };
            // Assert
            Assert.That(()=>planeAngle.GetPlaneAngle(points), Throws.Exception);
        }


    }
}