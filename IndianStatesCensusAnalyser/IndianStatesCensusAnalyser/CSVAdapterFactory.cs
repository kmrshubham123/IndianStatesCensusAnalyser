using IndianStatesCensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesCensusAnalyser
{
    /// <summary>
    /// LoadCsvData:- Reterive the data from csv read it and throw it back on basic of parameter 
    /// </summary>
    class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
