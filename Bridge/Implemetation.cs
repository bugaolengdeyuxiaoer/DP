
namespace Bridge
{
    public abstract class Menu
    {
        public readonly ICoupon _coupon = null!;

        public Menu(ICoupon coupon)
        {
            _coupon = coupon;
        }
        public abstract int CalculatePrice();
    }

    public interface ICoupon
    {
        int CouponValue { get; }
    }

    public class VegetarianMenu: Menu
    {
        public VegetarianMenu(ICoupon coupon) : base(coupon)
        {
        }

        public override int CalculatePrice()
        {
            return 20 - _coupon.CouponValue;
        }
    }

    public class MeatMenu : Menu
    {
        public MeatMenu(ICoupon coupon) : base(coupon)
        {
        }

        public override int CalculatePrice()
        {
            return 30 - _coupon.CouponValue;
        }
    }
    public class NoCoupon: ICoupon
    {
        public int CouponValue { get => 0; }
    }
    public class OneEuroCoupon : ICoupon
    {
        public int CouponValue { get => 1; }
    }
    public class TwoEuroCoupon : ICoupon
    {
        public int CouponValue { get => 2; }
    }
}
