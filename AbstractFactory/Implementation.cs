namespace AbstractFactory
{

    public interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();
        IShippingCostsService CreateShippingCostsService();
    }

    public interface IDiscountService
    {
        int DiscountPercentage
        {
            get;
        }
    }

    public class BelgiumDiscountService : IDiscountService
    {
        public int DiscountPercentage => 20;
    }

    public class FranceDiscountService : IDiscountService
    {
        public int DiscountPercentage => 10;
    }

    public interface IShippingCostsService
    {
        decimal ShippingCosts { get; }
    }


    public class BelgiumShippingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 20;
    }

    public class FranceShippingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 22;
    }


    public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new BelgiumDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new BelgiumShippingCostsService();
        }
    }


    public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new FranceShippingCostsService();
        }
    }

    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostsService _shippingCostsService;
        private int _orderCosts;

        public ShoppingCart(IShoppingCartPurchaseFactory factory)
        {
            _discountService = factory.CreateDiscountService();
            _shippingCostsService = factory.CreateShippingCostsService();
            _orderCosts = 200;
        }

        public void CalculateCosts()
        {
            System.Console.WriteLine($"Total costs =  " +
                $"{_orderCosts - (_orderCosts / 100 * _discountService.DiscountPercentage) + _shippingCostsService.ShippingCosts}");
        }
    }
}