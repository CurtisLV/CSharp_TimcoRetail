using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDataManager.Library.Internal.DataAccess;

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
        public void SaveSale(SaleData sale)
        {
            // TODO: Make it SOLID/DRY/Better
            // Start filling in the models we will save to DB
            // Fill in available info
            // Create the Sale model
            // Save the Sale model
            // Get ID from sale model
            // Finish filling in the sale detail models

            // Save the sale detail models
        }
    }
}
