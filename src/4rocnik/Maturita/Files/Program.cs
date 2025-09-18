using System;
using System.Collections.Generic;
using System.IO;

namespace Files
{
    internal class Program
    {
        public static List<Movie> Movies = new List<Movie>();
        public static int EarliestYear = int.MaxValue;

        public static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"./movies.csv"))
            {
                string header = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (values.Length != 8)
                    {
                        Console.WriteLine($"Skipping invalid line: {line}");
                        continue;
                    }

                    try
                    {
                        Movies.Add(new Movie(
                            values[0],
                            values[1],
                            values[2],
                            values[3],
                            values[4],
                            values[5],
                            values[6],
                            values[7]));
                        
                        int year = int.Parse(values[7].Trim());
                        if (year <  EarliestYear) EarliestYear = year;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Error parsing line: {line}. Error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Unexpected error: {ex.Message}");
                    }
                }
            }
            
            Console.WriteLine(EarliestYear);

            // foreach (var movie in Movies)
            // {
            //     Console.WriteLine(movie.ToString());
            // }
        }

        public static string PlsParse(string str)
        {
            str = str.Replace("$", "");
            str = str.Replace("%", "");
            str = str.Replace(" ", "");
            str = str.Trim();
            return str;
        }
    }

    
}
