using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace TimePerson.Models
{
    public class TimePeople
    {
        /// <summary>
        /// Properties for TimePeople
        /// </summary>
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        /// <summary>
        /// Instantiation of class TimePeople passing arguments in
        /// </summary>
        public TimePeople (int year, string honor, string name, string country, int birthyear, int deathyear, string title, string category, string context)
        {
            Year = year;
            Honor = honor;
            Name = name;
            Country = country;
            BirthYear = birthyear;
            DeathYear = deathyear;
            Title = title;
            Category = category;
            Context = context;

        }

        /// <summary>
        /// Get Person method will grab information from the list of people by accessing the CSV file.
        /// Then grab the data, assign it to Object of TimePeople.
        /// Then querying the list using startYear and endYear.
        /// </summary>
        /// <param name="startYear"></param>
        /// <param name="endYear"></param>
        /// <returns></returns>
        public static List<TimePeople> GetPersons(int startYear, int endYear)
        {

            string path = Environment.CurrentDirectory;
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot/personOfTheYear.csv"));
            string[] allList = System.IO.File.ReadAllLines(newPath);

            List<TimePeople> listOfTimePerson = new List<TimePeople>();

            // Table Data
            for (int i = 1; i < allList.Length; i++)
            {
                string[] peopleStats = allList[i].Split(',');

                TimePeople people = new TimePeople
                    (
                        peopleStats[0] == "" ? 0 : Convert.ToInt32(peopleStats[0]), //year
                        peopleStats[1], //honor
                        peopleStats[2], //name
                        peopleStats[3], //country
                        peopleStats[4] == "" ? 0 : Convert.ToInt32(peopleStats[4]), //birthyear
                        peopleStats[5] == "" ? 0 : Convert.ToInt32(peopleStats[5]), //deathyear
                        peopleStats[6], //title
                        peopleStats[7], //category
                        peopleStats[8] //context
                    );
                listOfTimePerson.Add(people);
            }

            //Query to the list
            List<TimePeople> query2 = listOfTimePerson.Where(x => x.Year <= endYear && x.Year >= startYear).ToList();
            return query2;
        }
    }
}
