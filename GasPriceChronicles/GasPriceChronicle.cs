using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace GasPriceChronicles
{

    internal class GasPriceChronicle
    {
        const int ROUND_BY_2 = 2;
        const char CHARACTER_SEPERATOR = ':';
        const int DATE_INDEX = 0;
        const int PRICE_INDEX = 1;
        private Dictionary<DateOnly, decimal> dateGasPricePairs;
        public GasPriceChronicle(string fileName)
        {
            if(ValidateFileName(fileName) == false)
            {
                throw new ArgumentException($"Error: Invalid GasPriceChronicle file name argument. File must be a .txt file. File {fileName}.");
            }

            dateGasPricePairs = PopulateData(fileName);
        
        }
        public Dictionary<int, decimal> AveragePricePerYear()
        {
            Dictionary<int, decimal> results = new Dictionary<int, decimal>();

            //like a nested dictionary. key is year(int) and value is dictionary with date keys in that year.
            IEnumerable<IGrouping<int, KeyValuePair<DateOnly, decimal>>> groupDateKeysByYear = dateGasPricePairs.GroupBy(year => year.Key.Year);
            //projects each group into a anonymous type as a object with two properties. (Year and AvgPrice). AvgPrice is calculated by summing values of year key in group
            var yearWithAveragePriceOfThatYear = groupDateKeysByYear.Select(groupDateKeysByYear => new { Year = groupDateKeysByYear.Key, AvgPrice = groupDateKeysByYear.Average(key => key.Value) });

            foreach (var pair in yearWithAveragePriceOfThatYear)
            {
                results.Add(pair.Year, Utils.RoundAtMid(pair.AvgPrice));
            }

            return results;
        }
        public Dictionary<string, decimal> AveragePricePerMonth()
        {
            Dictionary<string, decimal> results = new Dictionary<string, decimal>();


            IEnumerable<IGrouping<int, KeyValuePair<DateOnly, decimal>>> groupDateKeysByMonth = dateGasPricePairs.GroupBy(month => month.Key.Month);
            var monthWithAveragePriceOfThatMonth = groupDateKeysByMonth.Select(groupDateKeysByMonth => new { Month = groupDateKeysByMonth.Key, AvgPrice = groupDateKeysByMonth.Average(key => key.Value) });
            monthWithAveragePriceOfThatMonth = monthWithAveragePriceOfThatMonth.OrderBy(d => d.Month);
            foreach (var pair in monthWithAveragePriceOfThatMonth)
            {
                string monthAsName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(pair.Month);
                results.Add(monthAsName, Utils.RoundAtMid(pair.AvgPrice));
            }

            return results;
        }
        public Dictionary<int, (DateOnly date, decimal price)> HighestPricePerYear()
        {
            Dictionary<int, (DateOnly date, decimal price)> results = new Dictionary<int, (DateOnly date, decimal price)>();   

            
            IEnumerable<IGrouping<int, KeyValuePair<DateOnly, decimal>>> groupDateKeysByYear = dateGasPricePairs.GroupBy(year => year.Key.Year);
           
            //for each group. find max price for that year. 
            //then find the first date that max price occurred on using group of date keys each year is associated with
            var dateWithHighestPriceForEachYear = groupDateKeysByYear.Select(group =>
            {
 
                var maxPrice = group.Max(key => key.Value);
                var maxDatePriceOccurred = group.First(key => key.Value == maxPrice).Key;
                return new { Year = group.Key, MaxPrice = maxPrice, Date = maxDatePriceOccurred };
            });

            foreach (var dateOccurrance in dateWithHighestPriceForEachYear)
            {
                results.Add(dateOccurrance.Year, (dateOccurrance.Date, Utils.RoundAtMid(dateOccurrance.MaxPrice)));
            }

            return results;

        }
        public Dictionary<int, (DateOnly date, decimal price)> LowestPricePerYear()
        {
            Dictionary<int, (DateOnly date, decimal price)> results = new Dictionary<int, (DateOnly date, decimal price)>();


            IEnumerable<IGrouping<int, KeyValuePair<DateOnly, decimal>>> groupDateKeysByYear = dateGasPricePairs.GroupBy(year => year.Key.Year);

            //for each group. find max price for that year. 
            //then find the first date that lowest price occurred on using group of date keys each year is associated with
            var dateWithLowestPriceForEachYear = groupDateKeysByYear.Select(group =>
            {

                var minPrice = group.Min(key => key.Value);
                var minDatePriceOccurred = group.First(key => key.Value == minPrice).Key;
                return new { Year = group.Key, MinPrice = minPrice, Date = minDatePriceOccurred };
            });

            foreach (var dateOccurrance in dateWithLowestPriceForEachYear)
            {
                results.Add(dateOccurrance.Year, (dateOccurrance.Date, Utils.RoundAtMid(dateOccurrance.MinPrice)));
            }

            return results;

        }
        public Dictionary<DateOnly, decimal> SortByPriceAscending()
        {
            return dateGasPricePairs
                .OrderBy(p => p.Value)
                .ToDictionary(p => p.Key, p => p.Value);
        }
        public Dictionary<DateOnly, decimal> SortByPriceDescending()
        {
            return dateGasPricePairs
                .OrderByDescending(p => p.Value)
                .ToDictionary(p => p.Key, p => p.Value);
        }
        public void StoreModifiedGasPriceChronicleInFile(Dictionary<DateOnly, decimal> modifiedDataItems, string fileName)
        {
            var path = Path.Combine(Environment.CurrentDirectory,fileName);
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var dataItem in modifiedDataItems)
                {
                    writer.WriteLine($"{dataItem.Key.ToString("MM-dd-yyyy")}:{dataItem.Value}");
                }
            }
        }
        private Dictionary<DateOnly, decimal> PopulateData(string fileName)
        {
            if (ValidateFileAccess(fileName) == false)
            {
                throw new ArgumentException($"Error: Failed to access data file. File: {fileName}.");
            }
            
            const int DATA_ITEMS_PER_LINE = 2;

            Dictionary<DateOnly, decimal> results = new Dictionary<DateOnly, decimal>();


            using (StreamReader reader = new StreamReader(fileName))
            {

                string? line = string.Empty;
                string[] lineData = new string[DATA_ITEMS_PER_LINE];
                while (line != null)
                {
                    if (line != string.Empty)
                    {
                        (DateOnly date, decimal price) = ParseData(line, lineData);
                         results.Add(date, price);
                    }
                    line = reader.ReadLine();

                }
            }
         

            return results;
        }
        private (DateOnly date, decimal price) ParseData(string line,string[] lineData)
        {
            (DateOnly date, decimal price) results;

            lineData = line.Split(CHARACTER_SEPERATOR);

            results.date = DateOnly.ParseExact(lineData[DATE_INDEX], "MM-dd-yyyy");
            results.price = decimal.Parse(lineData[PRICE_INDEX]);

            return results;

        }
        private bool ValidateFileName(string fileName)
        {
            int fileNameSize = fileName.Length;
            const int DOT_TXT_EXTENSION_SIZE = 4;
            const string DOT_TXT_EXTENSION = ".txt";

            if (fileNameSize <= DOT_TXT_EXTENSION_SIZE)
            {
                return false;
            }
            
            if(fileName.Substring(fileNameSize - DOT_TXT_EXTENSION_SIZE) != DOT_TXT_EXTENSION)
            {
                return false;
            }

            return true;
        }
        private bool ValidateFileAccess(string fileName)
        {
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)))
            {
                return false;
            }

            return true;
        }
    }
}
