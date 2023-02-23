using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TeslaStockData.Models
{
    public class TeslaModel
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
        public float Adj_Price { get; set; }
        public int Volume { get; set; }
        public int CurrentPageIndex { get; set; }
        public int TotalRecords { get; set; }
    }
}