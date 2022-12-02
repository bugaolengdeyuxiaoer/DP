﻿
namespace ClassAdapter
{
    public class CityFromExternalSystem
    {
        public string Name { get; private set; }

        public string NickName { get; private set; }

        public int Inhabitants { get; private set; }

        public CityFromExternalSystem(string name, string nickName, int inhabitants)
        {
            Name = name;
            NickName = nickName;
            Inhabitants = inhabitants;
        }
    }
    public class ExternalSystem
    {
        public CityFromExternalSystem GetCity()
        {
            return new CityFromExternalSystem("Antwrap", "Stad", 50000);
        }
    }

    public class City
    {
        public string FullName { get; private set; }
        public long Inhabitants { get; private set; }
        public City(string fullName, long inhabitants)
        {
            FullName = fullName;
            Inhabitants = inhabitants;
        }
    }

    public interface ICityAdapter
    {
        City GetCity();
    }

    public class CityAdapter : ExternalSystem, ICityAdapter
    {
        public City GetCity()
        {
            var cityFromExternalSystem = base.GetCity();
            return new City($"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}", cityFromExternalSystem.Inhabitants);

        }
    }
}
