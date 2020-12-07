using Microsoft.Extensions.Options;
using ParkingTicketCalculator.Exceptions;
using System;

namespace ParkingTicketCalculator
{
    public class ShortStayParkingChargeCalculator : IParkingChargeCalculator
    {
        private readonly CarParkCharges _carParkCharges;
        private readonly decimal _chargePerMinute;

        public ShortStayParkingChargeCalculator(IOptions<CarParkCharges> options)
        {
            _carParkCharges = options.Value;
            _chargePerMinute = _carParkCharges.ShortStayChargePerHour / 60;
        }

        public void CalculateAndDisplayParkingCharge(DateTime startDateTime, DateTime endDateTime)
        {
            try
            {
                if (startDateTime > endDateTime)
                    throw new StartEndDateTimeException("Start date/time cannot be greater than end date/time");

                var billableMinutes = getShortStayBillableMinutes(startDateTime, endDateTime);

                var charge = Math.Round(billableMinutes * _chargePerMinute, 2);

                Console.WriteLine($"Parking charges for parking in SHORT STAY car park between {startDateTime.ToString("dd-MM-yyyy HH:mm:ss")} && {endDateTime.ToString("dd-MM-yyyy HH:mm:ss")} is £{charge}");
                Console.WriteLine("\n");
            }
            catch(Exception msg) {
                Console.WriteLine(msg.Message);
                throw msg;
            }
        }

        private int getShortStayBillableMinutes(DateTime startTime, DateTime endTime)
        {
            var totalBillableMinutes = 0;

            for (DateTime i = startTime; i <= endTime; i = i.AddMinutes(1))
            {
                if (i.DayOfWeek == DayOfWeek.Saturday || i.DayOfWeek == DayOfWeek.Sunday)
                {
                    i = i.AddDays(i.DayOfWeek == DayOfWeek.Saturday ? 2 : 1).Date.AddHours(7).AddMinutes(59);
                    continue;
                }

                if (i.Hour >= 8 && i.Hour <= 17)
                {
                    ++totalBillableMinutes;
                }

            }

            return totalBillableMinutes;
        }
    }
}
