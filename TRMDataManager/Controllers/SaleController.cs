﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TRMDataManager.Library.DataAccess;

namespace TRMDataManager.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        //public List<ProductModel> Get()
        //{
        //    ProductData data = new ProductData();
        //    return data.GetProducts();
        //}

        public void Post()
        {
            //
        }
    }
}