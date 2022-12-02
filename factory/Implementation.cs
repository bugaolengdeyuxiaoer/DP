namespace Factory
{
	/// <summary>
	/// Product
	/// </summary>
	public abstract class DiscountService
	{
		public abstract int DiscountPercentage { get; }
	}

	/// <summary>
	/// ConcreteProdut
	/// </summary>
	public class CountryDiscountService : DiscountService
	{
		private readonly string _countryIndentifier;
		public CountryDiscountService(string countryIndentifier)
		{
			_countryIndentifier = countryIndentifier;
		}
		public override int DiscountPercentage
		{
			get
			{
				switch (_countryIndentifier)
				{
					case "BE":
						return 20;
					default:
						return 10;
				}
			}
		}
	}

	/// <summary>
	/// ConcreteProdut
	/// </summary>
	public class CodeDiscountService : DiscountService
	{
		private readonly string _code;
		public CodeDiscountService(string code)
		{
			_code = code;
		}
		public override int DiscountPercentage
		{
			get => 15;
		}
	}

	public abstract class DiscountFactory
	{
		public abstract DiscountService CreateDiscountService();
	}

	/// <summary>
	/// ConcreteProdut
	/// </summary>
	public class CodeDiscountFactory : DiscountFactory
	{
		private readonly string _code;
		public CodeDiscountFactory(string code)
		{
			_code = code;
		}
		public override DiscountService CreateDiscountService()
		{
			return new CodeDiscountService(_code);
		}
	}

	/// <summary>
	/// ConcreteProdut
	/// </summary>
	public class CountryDiscountFactory : DiscountFactory
	{
		private readonly string _country;
		public CountryDiscountFactory(string country)
		{
			_country = country;
		}
		public override DiscountService CreateDiscountService()
		{
			return new CountryDiscountService(_country);
		}
	}
}

