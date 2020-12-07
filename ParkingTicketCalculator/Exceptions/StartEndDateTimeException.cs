using System;

namespace ParkingTicketCalculator.Exceptions
{
    public class StartEndDateTimeException : Exception
    {
        public StartEndDateTimeException()
        { }

        public StartEndDateTimeException(string message): base(message)
        { }

    }
}
