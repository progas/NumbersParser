using System.Globalization;
using System.ServiceModel.Activation;
using System.Threading;
using WritingNumbersService;

namespace WritingNumbers.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WritingNumberService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WritingNumberService.svc or WritingNumberService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WritingNumberService : IWriteNumberService
    {
        private WriteDollarCurrencyNumberService numberService;
       
        public WritingNumberService()
        {
            this.numberService = new WriteDollarCurrencyNumberService();
        }

        public string ConvertNumberToWords(string number)
        {
            return this.numberService.ConvertNumberToWords(number);
        }
    }
}
