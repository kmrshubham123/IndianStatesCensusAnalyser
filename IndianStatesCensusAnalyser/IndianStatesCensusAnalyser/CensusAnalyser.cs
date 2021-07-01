using IndianStatesCensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesCensusAnalyser
{
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA
        }
        //Create a Dictionary which represents a collection of keys and values.
        Dictionary<string, CensusDTO> dataMap;
        /// <summary>
        /// create method with return type dictionary and LoadCensusData and passing three parameters.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="csvFilePath"></param>
        /// <param name="dataHeaders"></param>
        /// <returns></returns>
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }

    }
}
