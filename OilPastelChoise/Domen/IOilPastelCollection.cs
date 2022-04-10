using System;
using System.Collections.Generic;
using System.Text;

namespace OilPastelChoise
{
    public interface IOilPastelCollection
    {
        public List<OilPastel> ReadAll();
        public void AddPastel(OilPastel pastel);
        public void DeleteOilPastel(int Id);
        public void UpdateOilPastel(int id, OilPastel pastel);
        public List<OilPastel> FindForBrand(string brand);
        public List<OilPastel> FindFofUserLevel(string userLevel);
        public List<OilPastel> FindForColorNumber(int colorNumber);
        public List<OilPastel> FindForPrice(int minPrice, int maxPrice);

    }
}
