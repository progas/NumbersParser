﻿using System.Globalization;
using System.ServiceModel;

namespace WritingNumbersService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWriteNumberService
    {
        [OperationContract]
        string ConvertNumberToWords(string number);
    }
}
