using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoPark
{
    public class Dictionary
    {
        public Dictionary<string, int> Details { get; set; }
        public string[] DetailsName { get; set; }

        public Dictionary() { }

        public Dictionary(string orders)
        {
            DetailsName = LoadDetails(orders);
        }

        public string[] LoadDetails(string inFile)
        {
            string[] detailsName = new string[] {};
            string line;
            string allLines = String.Empty;
            try
            {
                using (StreamReader streamReader = new StreamReader(inFile))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (allLines.Equals(String.Empty))
                        {
                            allLines += line;
                        }
                        else
                        {
                            allLines += "," + line;
                        }
                    }

                    detailsName = allLines.Split(","); 
                }

            }
            catch (Exception)
            {
                Console.WriteLine($"File {inFile} wasn't found");
            }

            return detailsName;
        }

        public void FillDictionary()
        {
            Dictionary<string, int> details = new Dictionary<string, int>();
            int counter = 1;
            for (int i = 0; i < DetailsName.Length; i++)
            {
                for (int j = i+1; j < DetailsName.Length; j++)
                {
                    if (DetailsName[i].Equals(DetailsName[j]))
                    {
                        counter++;
                    }
                }
                if (!details.ContainsKey(DetailsName[i]))
                {
                    details.Add(DetailsName[i],counter);
                }
                counter = 1;
            }

            Details = details;
        }
    }
}