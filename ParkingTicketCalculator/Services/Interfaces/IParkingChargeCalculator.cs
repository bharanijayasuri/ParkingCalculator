using System;
namespace ParkingTicketCalculator
{
    public interface IParkingChargeCalculator
    {
        void CalculateAndDisplayParkingCharge(DateTime startDateTime, DateTime endDateTime);
    }
}
