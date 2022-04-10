using System;
using System.Collections.Generic;
using System.Text;

namespace OilPastelChoise
{
    class OilPastelCollection: IOilPastelCollection
    {
        private static List<OilPastel> oilPastels = new List<OilPastel>();
        public OilPastelCollection()
        {
            StartData();
        }

        public void AddPastel(OilPastel pastel)
        {
            pastel.Id = oilPastels.Count + 1;
            oilPastels.Add(pastel);
        }

        public void DeleteOilPastel(int Id)
        {
            if (Id < 0 || Id > oilPastels.Count)
                return;
            oilPastels.RemoveAt(Id - 1);
            for (var i = Id - 1; i < oilPastels.Count; i++)
                oilPastels[i].Id--;
        }

        public void UpdateOilPastel(int id, OilPastel oilPastel)
        {
            foreach (var elem in oilPastels)
                if (elem.Id == id)
                {
                    elem.Brand = oilPastel.Brand;
                    elem.Name = oilPastel.Name;
                    elem.UserLevel = oilPastel.UserLevel;
                    elem.ColorNumber = oilPastel.ColorNumber;
                    elem.OriginCountry = oilPastel.OriginCountry;
                    elem.Price = oilPastel.Price;
                }
        }

        public List<OilPastel> FindForBrand(string brand)
        {
            var result = new List<OilPastel>();
            foreach (var item in oilPastels)
                if (item.Brand.Equals(brand))
                    result.Add(item);
            return result;
        }

        public List<OilPastel> FindFofUserLevel(string userLevel)
        {
            var result = new List<OilPastel>();
            foreach (var item in oilPastels)
                if (item.UserLevel.Equals(userLevel))
                    result.Add(item);
            return result;
        }

        public List<OilPastel> FindForColorNumber(int colorNumber)
        {
            var result = new List<OilPastel>();
            foreach (var item in oilPastels)
                if (item.ColorNumber == colorNumber)
                    result.Add(item);
            return result;
        }

        public List<OilPastel> FindForPrice(int minPrice, int maxPrice)
        {
            var result = new List<OilPastel>();
            foreach (var item in oilPastels)
                if (item.Price >= minPrice && item.Price <= maxPrice)
                    result.Add(item);
            return result;
        }

        private void StartData()
        {
            var pastel1 = new OilPastel()
            {
                Brand = "VISTA-ARTISTA",
                Name = "Studio GTG-VAOP-24",
                UserLevel = "Ученическая",
                ColorNumber = 24,
                OriginCountry = "Китай",
                Price = 335
            };
            AddPastel(pastel1);

            var pastel2 = new OilPastel()
            {
                Brand = "MUNGYO",
                Name = "Mungyo Gallery",
                UserLevel = "Профессиональная",
                ColorNumber = 72,
                OriginCountry = "Корея",
                Price = 9976
            };
            AddPastel(pastel2);

            var pastel3 = new OilPastel()
            {
                Brand = "PENTEL",
                Name = "Large Sticks",
                UserLevel = "Ученическая",
                ColorNumber = 24,
                OriginCountry = "Тайвань",
                Price = 877
            };
            AddPastel(pastel3);

            var pastel4 = new OilPastel()
            {
                Brand = "Я - Художник!",
                Name = "Я - Художник! Набор масляной пастели",
                UserLevel = "Детская",
                ColorNumber = 12,
                OriginCountry = "Китай",
                Price = 179
            };
            AddPastel(pastel4);
        }

        public List<OilPastel> ReadAll()
        {
            return oilPastels;
        }
    }
}
