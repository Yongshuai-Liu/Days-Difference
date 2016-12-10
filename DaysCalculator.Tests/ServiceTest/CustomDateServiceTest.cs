using System;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaysCalculator.BLL.Services.ServiceInterfaces;
using DaysCalculator.BLL.Services.ServiceImpl;

namespace DaysCalculator.Tests.ServiceTest
{
    [TestFixture]
    public class CustomDateServiceTest
    {
        /// <summary>
        /// Test custom date service calculateDaysDiff function to compare result with build in Days function
        /// </summary>
        [Test]
        public void CalculateDaysDiff_Test()
        {
            //Arrange
            var customDateService = new CustomDateService();
            DateTime from = new DateTime(2011, 6, 10);
            DateTime to = new DateTime(2015, 3, 10);
            //Act
            var dayDiffByLibrary = (to - from).Days;
            var dayDiffByCustomService = customDateService.CalculateDaysDiff(from, to);
            //Assert
            NUnit.Framework.Assert.AreEqual(dayDiffByLibrary, dayDiffByCustomService);
        }
    }
}
