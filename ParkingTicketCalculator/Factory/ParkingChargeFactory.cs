using System;
namespace ParkingTicketCalculator
{
    public class ParkingChargeFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ParkingChargeFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IParkingChargeCalculator GetParkingChargeCalculator(StayType staytype)
        {
            IParkingChargeCalculator parkingChargeCalculator = null;
            switch (staytype)
            {
                case StayType.ShortStay:
                    {
                        parkingChargeCalculator = (IParkingChargeCalculator)_serviceProvider.GetService(typeof(ShortStayParkingChargeCalculator));
                        break;
                    }
                case StayType.LongStay:
                    {
                        parkingChargeCalculator = (IParkingChargeCalculator)_serviceProvider.GetService(typeof(LongStayParkingChargeCalculator));
                        break;
                    }
            }

            return parkingChargeCalculator;
        }

    }
}
