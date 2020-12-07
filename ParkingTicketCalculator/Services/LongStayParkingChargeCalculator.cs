using System;
using Microsoft.Extensions.Options;
using ParkingTicketCalculator.Exceptions;

namespace ParkingTicketCalculator
{
    public class LongStayParkingChargeCalculator : IParkingChargeCalculator
    {
        private readonly CarParkCharges _carParkCharges;

        public LongStayParkingChargeCalculator(IOptions<CarParkCharges> options)
        {
            _carParkCharges = options.Value;
        }

        public void CalculateAndDisplayParkingCharge(DateTime startDateTime, DateTime endDateTime)
        {
            try
            {
                if (startDateTime > endDateTime)
                    throw new StartEndDateTimeException("Start date/time cannot be greater than end date/time");

                var numberOfDays = 0;

                for (var i = startDateTime.Date; i <= endDateTime.Date; i = i.AddDays(1))
                {
                    ++numberOfDays;
                }

                var charge = Math.Round(numberOfDays*_carParkCharges.LongStayChargePerDay,2);

                Console.WriteLine($"Parking charges for parking in LONG STAY car park between {startDateTime.ToString("dd-MM-yyyy HH:mm:ss")} && {endDateTime.ToString("dd-MM-yyyy HH:mm:ss")} is £{charge}");
                Console.WriteLine("\n");
            }
            catch(Exception msg) {
                Console.WriteLine(msg.Message);
                throw msg;
            }
        }

    }
}
