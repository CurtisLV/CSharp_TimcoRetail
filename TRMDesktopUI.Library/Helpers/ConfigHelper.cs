using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public double GetTaxRate()
        {
            string rateText = ConfigurationManager.AppSettings["taxRate"];

            bool isValidTaxRate = Double.TryParse(rateText, out double output);

            if (isValidTaxRate == false)
            {
                throw new ConfigurationErrorsException("Tax rate is not set up properly!");
            }

            return output;
        }
    }
}
