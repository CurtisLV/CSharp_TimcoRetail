﻿using System;
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
            ProductData products = new ProductData();

            decimal taxRate = ConfigHelper.GetTaxRate() / 100;

            foreach (var item in sale.SaleDetails)
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

            // Fill in available info
            // Create the Sale model
            // Save the Sale model
            // Get ID from sale model
            // Finish filling in the sale detail models

            // Save the sale detail models
        }
    }
}
