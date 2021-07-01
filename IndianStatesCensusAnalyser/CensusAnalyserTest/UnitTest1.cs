using NUnit.Framework;
using IndianStatesCensusAnalyser.POCO;
using System.Collections.Generic;
using static IndianStatesCensusAnalyser.CensusAnalyser;
using IndianStatesCensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        string indiaStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        string indiaStateCodeHeaders = "SrNo,StateName,TIN,StateCode";
        string indiaStateCensusFilePath = @"D:\BridgeLabz\FileIOStreams\IndianState\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\IndiaStateCensusData.csv";
        string wrongHeaderIndiaCensusFilePath = @"D:\BridgeLabz\FileIOStreams\IndianState\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        string delimiterIndiaCensusFilePath = @"D:\BridgeLabz\FileIOStreams\IndianState\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\DelimeterIndiaStateCensusData.csv";
        string wrongIndiaStateCensusFilePath = @"D:\BridgeLabz\FileIOStreams\IndianState\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\IndiaData.csv";
        string wrongIndiaStateCensusFileType = @"D:\BridgeLabz\FileIOStreams\IndianState\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\WrongIndiaStateCensusData.txt";
        string indiaStateCodeFilePath = @"D:\BridgeLabz\FileIOStreams\IndianState\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\IndiaStateCode.csv";
        string wrongIndiaStateCodeFileType = @"D:\BridgeLabz\FileIOStreams\IndianState\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\WrongIndiaStateCode.txt";
        string delimiterIndiaStateCodeFilePath = @"D:\BridgeLabz\FileIOStreams\IndianState\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\DelimeterIndiaStateCode.csv";
        string wrongHeaderStateCodeFilePath = @"D:\BridgeLabz\FileIOStreams\IndianState\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\WrongIndiaStateCode.csv";
       
        IndianStatesCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStatesCensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        //Happy TC1.1:-To ensure the number of record match with CSV file.
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            //Act
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indiaStateCensusFilePath, indiaStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indiaStateCodeFilePath, indiaStateCodeHeaders);
            //Assert
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        //Sad TC1.2:-Returns a custom Exception if CSV file is wrong
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndiaStateCensusFilePath, indiaStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndiaStateCensusFilePath, indiaStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        //Sad TC1.3:Returns a custom Exception if CSV file is correct but type is wrong
        [Test]
        public void GivenWrongIndianCensusDataType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndiaStateCensusFileType, indiaStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndiaStateCensusFileType, indiaStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
        //Sad TC1.4:-Returns a custom Exception if CSV file is correct but Delimiter is wrong
        [Test]
        public void GivenCorrectIndianCensusCsvFileAndWrongHeader_WhenReaded_ShouldReturnInvalidHeaderCoustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndiaCensusFilePath, indiaStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndiaStateCodeFilePath, indiaStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }
        //Sad TC1.5:Returns a custom Exception if CSV file is correct but Header is wrong
        [Test]
        public void GivenCorrectIndianCensusCsvFileAndWrongHeader_WhenReaded_ShouldReturnInvalidHeaderCoustomExceptionUsingStateCodeObject()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndiaCensusFilePath, indiaStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderStateCodeFilePath, indiaStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}