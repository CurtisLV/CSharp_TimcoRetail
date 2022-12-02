using System;
using System.Collections.Generic;
using System.Linq;
using TRMDataManager.Library.Internal.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class SaleData
    {
        public void SaveSale(SaleModel saleInfo, string cashierId)
        {
            // TODO: Make it SOLID/DRY/Better
            // Start filling in the models we will save to DB
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            ProductData products = new ProductData();

            decimal taxRate = ConfigHelper.GetTaxRate() / 100;

            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDBModel()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                };

                // Get info about the product

                var productInfo = products.GetProductById(detail.ProductId);

                if (productInfo == null)
                {
                    throw new Exception(
                        $"The product ID of {detail.ProductId} could not be found in the database!"
                    );
                }

                detail.PurchasePrice = (productInfo.RetailPrice * detail.Quantity);

                if (productInfo.IsTaxable)
                {
                    detail.Tax = (detail.PurchasePrice * taxRate);
                }

                details.Add(detail);
            }

            // Create the Sale model

            SaleDBModel sale = new SaleDBModel()
            {
                SubTotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x => x.Tax),
                CashierId = cashierId
            };

            sale.Total = sale.SubTotal + sale.Tax;

            // Save the Sale model





            using (SqlDataAccess sql = new SqlDataAccess())
            {
                sql.StartTransaction("TRMData");
                sql.SaveDataInTransaction("dbo.spSale_Insert", sale);
            }

            // Get ID from sale model

            sale.Id = sql.LoadData<int, dynamic>(
                    "spSale_Lookup",
                    new { sale.CashierId, sale.SaleDate },
                    "TRMData"
                )
                .FirstOrDefault();

            // Finish filling in the sale detail models

            foreach (SaleDetailDBModel item in details)
            {
                item.SaleID = sale.Id;
                // Save the sale detail models
                sql.SaveData("dbo.spSaleDetail_Insert", item, "TRMData");
            }
        }
    }
}
