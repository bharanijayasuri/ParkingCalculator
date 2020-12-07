using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingTicketCalculator;
using ParkingTicketCalculator.Exceptions;
using System;

namespace ParkingTicketCalculatorTests
{
    [TestClass]
    public class ShortStayParkingChargeCalculatorTests
    {
        [TestMethod]
        public void CalculateAndDisplayParkingCharge_StartDateGreaterThanEnd()
        {
            DateTime startDate = DateTime.UtcNow.AddDays(1);
            DateTime endDate = DateTime.UtcNow.AddHours(1);

            IOptions<CarParkCharges> mockOptions = Options.Create(new CarParkCharges());
            ShortStayParkingChargeCalculator calc = new ShortStayParkingChargeCalculator(mockOptions);

            Assert.ThrowsException<StartEndDateTimeException>(() => calc.CalculateAndDisplayParkingCharge(startDate, endDate));
        }
    }
}
