using System;
using System.Configuration;

namespace TRMDesktopUI.Library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        // TODO - move this from config to the API someday maybe
        public decimal GetTaxRate()
        {
            string rateText = ConfigurationManager.AppSettings["taxRate"];

            bool isValidTaxRate = Decimal.TryParse(rateText, out decimal output);

            if (isValidTaxRate == false)
            {
                throw new ConfigurationErrorsException("Tax rate is not set up properly!");
            }

            return output;
        }
    }
}
