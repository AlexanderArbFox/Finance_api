using Dapper;
using System;
using System.Data;

namespace Finance_api.Models.Containers
{
    internal class StockCompanyContainer
    {
        public Stock_company Stock_Company { get; set; }

        internal DynamicParameters StockCompanyParameters()
        {
            var stockParameters = new DynamicParameters();
            stockParameters.Add("@name_original", Stock_Company.Name_original);
            stockParameters.Add("@name_full", Stock_Company.Name_full);
            stockParameters.Add("@country_id", Stock_Company.Country_id);
            stockParameters.Add("@id_max_stock", DBNull.Value, DbType.Int64, direction:ParameterDirection.Output);
            return stockParameters;
        }
    }
}
