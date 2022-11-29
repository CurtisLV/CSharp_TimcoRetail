using System.Collections.Generic;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    //public List<ProductModel> GetProducts()
    //{
    //    SqlDataAccess sql = new SqlDataAccess();

    //    var output = sql.LoadData<ProductModel, dynamic>(
    //        "dbo.spProduct_GetAll",
    //        new
    //        {
    //        },
    //        "TRMData"
    //    );

    //    return output;
    //}
    public class SaleData
    {
        public void SaveSale(SaleModel sale)
        {
            // TODO: Make it SOLID/DRY/Better
            // Start filling in the models we will save to DB
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();

            foreach (var item in sale.SaleDetails)
            {
                var detail = new SaleDetailDBModel()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                };

                // Get info about the product

                details.Add(detail);
            }

            // Fill in available info
            // Create the Sale model
            // Save the Sale model
            // Get ID from sale model
            // Finish filling in the sale detail models

            // Save the sale detail models
        }
    }
}
