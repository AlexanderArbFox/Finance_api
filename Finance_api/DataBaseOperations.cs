using Finance_api.Models;
using Finance_api.Models.Containers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Finance_api
{
    internal class DataBaseOperations
    {
        internal static string ConnectToDataBase()
        {
            return "Server=DESKTOP-0DG4D81; Database=Finance_api; Trusted_Connection=True; MultipleActiveResultSets=true";
        }
        internal async Task FillRows(MainDeserialize deserializePage)
        {
            using(var db = new SqlConnection(ConnectToDataBase()))
            {
                try
                {
                    await db.OpenAsync();
                    using(var transaction = await db.BeginTransactionAsync(IsolationLevel.ReadCommitted))
                    {
                        try
                        {
                            foreach (var stockInfo in deserializePage.data)
                            {
                                var stocksContainer = new StockCompanyContainer
                                {
                                    Stock_Company = new Stock_company
                                    {
                                        Name_original = stockInfo.symbol,
                                        //Name_full = String.Empty,
                                        //Country_id = 1
                                    }
                                }.StockCompanyParameters();
                            }
                            await transaction.CommitAsync().ConfigureAwait(false);
                        }
                        catch(Exception)
                        {
                            if(transaction != null)
                               await transaction.RollbackAsync().ConfigureAwait(false);
                            throw;
                        }
                        finally
                        {
                            if (transaction != null)
                                await transaction.DisposeAsync().ConfigureAwait(false);
                            GC.Collect(0, GCCollectionMode.Forced);
                            GC.Collect(1, GCCollectionMode.Forced);
                            GC.Collect(2, GCCollectionMode.Forced);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
