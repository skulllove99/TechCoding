using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TechCoding
{
    public class BusinessLogic
    {
        //Initialize class
        public BusinessLogic()
        {
        }

        /// <summary>
        /// Function to read data from txt file
        /// return data is a Array string
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string[] ReadDataFromFile(string path)
        {
            return File.ReadAllLines(path);
        }
        /// <summary>
        /// Function to create output file 
        /// </summary>
        /// <param name="path"></param>
        void CreateFile(string path)
        {
            // check file exist if not exist. Create new file
            var checkExistFile = File.Exists(path);
            if (!checkExistFile)
            {
                var file = File.Create(path);
                file.Close();
            }
        }
        //Initialize the calculation function
        public void Calculation()
        {
            // call Function ReadDataFromFile and get data return
            var lines = ReadDataFromFile("../../../In.txt");
            // Declare a dictionary variable containing the key which is the license plate and the value which is the number of occurrences
            var lstVehicle = new Dictionary<string, int>();
            // Declare a list string variable containing output
            var newLstOutput = new List<string>();

            // Get distinct variable in lines array
            var linesDistinct = lines.Distinct();
            // Use a loop to browse each element of the linesDistinct array

            foreach (var line in linesDistinct)
            {
                //count line
                var count = lines.Where(x => x == line).Count();
                // add List
                lstVehicle.Add(line, count);
            }
            string fileOutputPath = "../../../Out.txt";
            // call function create file
            CreateFile(fileOutputPath);
            // using foreach to add variables from lstVehicle to newLstOutput
            foreach (var row in lstVehicle)
            {
                newLstOutput.Add(string.Format("License plate numbers {0} appears {1}", row.Key, row.Value));
            }
            // Write file with file path and list data
            File.WriteAllLines(fileOutputPath, newLstOutput);
        }

       
    }
}
