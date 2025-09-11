using System;
using System.Collections.Generic;
using System.IO;

namespace Files
{
  internal class Program
  {
    public static List<Movie> Movies = new List<Movie>();
    public static void Main(string[] args)
    {
      using(var reader = new StreamReader(@"./movies.csv"))
      {
        reader.ReadLine();
        while (!reader.EndOfStream)
        {
          var line = reader.ReadLine();
          var values = line.Split(',');
          try
          {
            Movies.Add(new Movie(
              values[0],
              values[1],
              values[2],
              int.Parse(values[3]),
              decimal.Parse(values[4]),
              int.Parse(values[5]),
              float.Parse(values[6].Replace("$", "")),
              int.Parse(values[7])));
          }
          catch (Exception e)
          {
            Console.WriteLine(e.Message);
          }
        }
      }
      
      foreach(var movie in Movies) Console.WriteLine(movie.ToString());
    }
  }
}