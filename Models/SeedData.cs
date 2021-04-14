using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OutcomeManagementSystem.Data;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using CsvHelper;
using System.Globalization;

namespace OutcomeManagementSystem.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OutcomeManagementSystemContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<OutcomeManagementSystemContext>>()))
            {
                // Look for any courses.
                if (context.Courses.Any())
                {
                    return;   // DB has been seeded
                }

                var reader = new StreamReader(@"ABET SOs.csv");
                var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                var SORecords = csvReader.GetRecords<StudentOutcome>().ToList();
                context.StudentOutcomes.AddRange(SORecords);
                context.SaveChanges();

                reader = new StreamReader(@"ABET POs.csv");
                csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                var PORecords = csvReader.GetRecords<ProgramOutcome>().ToList();
                context.ProgramOutcomes.AddRange(PORecords);
                context.SaveChanges();

                reader = new StreamReader(@"Aero KPIs.csv");
                csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                var KPIRecords = csvReader.GetRecords<SO_KPI>().ToList();
                context.SO_KPIs.AddRange(KPIRecords);
                context.SaveChanges();

                List<Course> courses = LoadCatalogFromHTLM();
                context.Courses.AddRange(courses);
                context.SaveChanges();

                reader = new StreamReader(@"Aero CLOs.csv");
                csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

                csvReader.Read();
                csvReader.ReadHeader();
                
                while (csvReader.Read())
                {
                    var record = new CLO();
                    record = csvReader.GetRecord<CLO>();
                    
                    record.CourseID = context.Courses.FirstOrDefault(c => c.Number == record.CourseID).ID;
                    context.CLOs.Add(record);
                }
                int i = 1;
                context.SaveChanges();

                var preReqs = new PreReq[]
                {
                    new PreReq{Type=PreReqType.PreReq, CourseID=1},
                    new PreReq{Type=PreReqType.PreReq, CourseID=2 }
                };
                context.PreReqs.AddRange(preReqs);
                context.SaveChanges();

                var preReqMap = new PreReqMap[]
                {
                    new PreReqMap{CourseID=3, PreReqID=1},
                    new PreReqMap{CourseID=3, PreReqID=2}
                };
                context.PreReqMaps.AddRange(preReqMap);
                context.SaveChanges();

            }
        }
        public static List<Course> LoadCatalogFromHTLM()
        {
            var courses = new List<Course>();
            try
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.Load("AeroCatalog.html");
                string catalogText = htmlDoc.Text;
                string noBlah = Regex.Replace(catalogText, @"&nbsp;", " ").Trim();
                //File.WriteAllText("AeroCatalog_clean.xml", noBlah);

                XDocument doc = XDocument.Parse(noBlah);

                IEnumerable<XElement> coursesXElem = doc.Elements("div").Elements("div").Where(e => e.Attribute("class").Value == "courseblock");

                foreach (var courseXElem in coursesXElem)
                {

                    var course = new Course();
                    IEnumerable<XElement> courseTitle = courseXElem.Elements("p").Where(a => a.Attribute("class").Value == "courseblocktitle");
                    string[] info = courseTitle.Elements("strong").FirstOrDefault().Value.Split("\n");
                    course.Department = info[1].Trim().Split(".")[0].Split(" ")[0].Trim();
                    course.Number = Convert.ToInt32(info[1].Trim().Split(".")[0].Split(" ")[1]);
                    course.Title = info[1].Trim().Split(".")[1].Trim();
                    //todo - fix this to deal with variable unit classes
                    course.Units = Convert.ToInt32(info[3].Trim().Split(" ")[0].Substring(0,1));

                    IEnumerable<XElement> courseDescXElem = courseXElem.Elements("div").Where(a => a.Attribute("class").Value == "courseblockdesc");
                    course.Description = courseDescXElem.Elements("p").FirstOrDefault().Value.Trim();
                    course.Concentration = "Major";
                    course.Year = YearType.unknown;
                    course.Quarter = QuarterType.unknown;
                    courses.Add(course);
                }
            }
            catch (Exception ex)
            {
                string s = "(ex, An error occurred seeding the DB.)";
            }
        
            return courses;
        }
    }
}
