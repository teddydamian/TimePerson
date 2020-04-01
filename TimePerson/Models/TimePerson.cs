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
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }


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

        public static List<TimePeople> GetPersons(int startYear, int endYear)
        {

            string filepath = @"../TimePerson/wwwroot/personOfTheYear.csv";

            string[] allList = File.ReadAllLines(filepath);


            List<TimePeople> listOfTimePerson = new List<TimePeople>();

            //Header of table
            string[] header = allList[0].Split(',');

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

            List<TimePeople> query2 = listOfTimePerson.Where(x => x.Year <= endYear && x.Year >= startYear).ToList();
            return query2;
        }
    }
}
