using System;
using System.Collections.Generic;

namespace Facade
{
    public class OrderService
    {
        public bool HasEnoughOrders(int customerID)
        {
            return (customerID > 6);
        }
    }

    public class CustomerDiscountBaseService
    {
        public double CalculateDiscountBase(int customerID)
        {
            return (customerID > 8) ? 10 : 20;
        }
    }

    public class DayOfTheWeekFactorService 
    {
        public double CalculateDayOfTheWeekFactor()
        {
            switch (DateTime.UtcNow.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return 0.8;
                default:
                    return 1.2;
            }
        }
    }

    public class DiscountFacade
    {
        private readonly OrderService _oderService = new OrderService();
        private readonly CustomerDiscountBaseService _customerDiscountBaseService = new CustomerDiscountBaseService();
        private readonly DayOfTheWeekFactorService _dayOfTheWeekFactorService = new DayOfTheWeekFactorService ();

        public double CalculateDiscountPercentage(int customID)
        {
            if (!_oderService.HasEnoughOrders(customID))
            {
                return 0;
            }
            return _customerDiscountBaseService.CalculateDiscountBase(customID) * _dayOfTheWeekFactorService.CalculateDayOfTheWeekFactor();
        }
    }

}
