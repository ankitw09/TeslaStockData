
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeslaStockData.Models;

namespace TeslaStockData.Repository
{
    public class TeslaRepo:ITeslaRepo
    {
        private readonly string connectionString;
        private SqlConnection con;

        public TeslaRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private void connection()
        {
            con = new SqlConnection(connectionString);
        }

        public bool AddStockData(TeslaModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddStockData", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Date", obj.Date);
            com.Parameters.AddWithValue("@Open", obj.Open);
            com.Parameters.AddWithValue("@High", obj.High);
            com.Parameters.AddWithValue("@Low", obj.Low);
            com.Parameters.AddWithValue("@Close", obj.Close);
            com.Parameters.AddWithValue("@Adj_Close", obj.Adj_Price);
            com.Parameters.AddWithValue("@Volume", obj.Volume);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
           bool res = i >= 1 ? true: false;

            return res;
        }


        public List<TeslaModel> GetStockData(int currentPageIndex)
        {
            connection();
            List<TeslaModel> StockData = new List<TeslaModel>();

            SqlCommand com = new SqlCommand("GetStockData", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@page", currentPageIndex);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dt = new DataSet();

            con.Open();
            da.Fill(dt);
            con.Close();
            int totalRecords = Convert.ToInt32(dt.Tables[1].Rows[0]["totalRecords"]) / 15 + 1;
            
            foreach (DataRow dr in dt.Tables[0].Rows)
            {

                StockData.Add(

                    new TeslaModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Date = Convert.ToDateTime(dr["Date"]),
                        Open = Convert.ToSingle(dr["Open"]),
                        High = Convert.ToSingle(dr["High"]),
                        Low = Convert.ToSingle(dr["Low"]),
                        Close = Convert.ToSingle(dr["Close"]),
                        Adj_Price = Convert.ToSingle(dr["Adj.Close"]),
                        Volume = Convert.ToInt32(dr["Volume"]),
                        CurrentPageIndex = currentPageIndex,
                        TotalRecords = totalRecords
                    }


                    ) ;


            }
        
            return StockData;


        }


        public bool UpdateStockData(TeslaModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateStockData", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", obj.Id);
            com.Parameters.AddWithValue("@Date", obj.Date);
            com.Parameters.AddWithValue("@Open", obj.Open);
            com.Parameters.AddWithValue("@High", obj.High);
            com.Parameters.AddWithValue("@Low", obj.Low);
            com.Parameters.AddWithValue("@Close", obj.Close);
            com.Parameters.AddWithValue("@Adj_Close", obj.Adj_Price);
            com.Parameters.AddWithValue("@Volume", obj.Volume);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool res = i >= 1 ? true : false;

            return res;

        }

        public bool DeleteStockData(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("DeleteStockDataById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool res = i >= 1 ? true : false;

            return res;

        }
    }
}