using System;
using System.Threading.Tasks;
using WritingNumbers.DesktopClient.WriteNumberServiceReference;

namespace WritingNumbers.DesktopClient
{
    internal class ServiceReferenceManager
    {
        public static async Task<String> ConvertNumberToWritingAsync(string number)
        {
            string result = string.Empty;
            WriteNumberServiceClient serviceClient = null;
            try
            {
                serviceClient = new WriteNumberServiceClient();
                serviceClient.Open();
                return await serviceClient.ConvertNumberToWordsAsync(number);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                if (serviceClient != null)
                {
                    serviceClient.Close();
                }
            }

            return result;
        }
    }
}
