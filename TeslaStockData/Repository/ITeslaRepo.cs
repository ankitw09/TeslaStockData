using TeslaStockData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeslaStockData.Repository
{
    public interface ITeslaRepo
    {
         int AddStockData(TeslaModel obj);
         List<TeslaModel> GetStockData(int currentPageIndex);
         bool UpdateStockData(TeslaModel obj);

        bool DeleteStockData(int Id);
    }
}