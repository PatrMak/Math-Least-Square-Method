using FluentAssertions;
using Maths;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Math_LeastSquare_Method.UnitTests
{
    public class FitCircle2DTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetFittedCircle_CorrectPoints_ReturnFittedCricle()
        {
            // Arange
            var circle = new FitCircle2D();
            // Act
            var points = new List<PointsDataModel>{
                new PointsDataModel{X=127.032,Y=127.050},
                new PointsDataModel{X=127.043,Y=-127.047},
                new PointsDataModel{X=-127.051,Y=-127.060},
                new PointsDataModel{X=-127.060,Y=127.038},
            };
            var result = circle.GetFittedCircle(points);
            var expected = new CircleDataModel { X = -0.0092, Y = -0.0053, Radius = 179.6725 };
            // Assert

            result.Should().Equals(expected);
        }

        [Test]
        public void GetFittedCircle_NotRquiredPointsCount_ThrowExeption()
        {
            // Arange
            var circle = new FitPlaneLeastSquares3D();
            // Act
            var points = new List<PointsDataModel>{
                new PointsDataModel{X=127.032,Y=127.050,Z=15.298},
                new PointsDataModel{X=127.043,Y=-127.047,Z=15.298},
            };
            // Assert
            Assert.That(() => circle.GetPlaneAngle(points), Throws.Exception);
        }
    }
    
}
