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

                List<Course> courses = LoadCatalogFromHTLM(context);
                //context.Courses.AddRange(courses);
                //context.SaveChanges();

                reader = new StreamReader(@"Aero CourseCoordinators.csv");
                csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                //var CourseCoordRecords = csvReader.GetRecords<CourseCoordinator>().ToList();

                var records = new List<CourseCoordinator>();
                csvReader.Read();
                csvReader.ReadHeader();
                while (csvReader.Read())
                {
                    var record = new CourseCoordinator
                    {
                        FirstName = csvReader.GetField("FirstName"),
                        LastName = csvReader.GetField("LastName"),
                        //ID = csvReader.GetField<Int32>("ID")
                    };
                    var courseDept = csvReader.GetField("Dept");
                    var courseNumber = csvReader.GetField<Int32>("Number");
                    record.CourseID = context.Courses.FirstOrDefault(c => c.Department == courseDept && c.Number == courseNumber).ID;

                    records.Add(record);
                }
                context.CourseCoordinators.AddRange(records);
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
                context.SaveChanges();

                List<Assessment> Assessments = new List<Assessment>
                {
                new Assessment() { CanvasAssessmentID = 1, CanvasCourseID = 560, OutcomeName = "Test Outcome", OutcomeMasteryScore = 3, OutcomeScore = 1},
                new Assessment() { CanvasAssessmentID = 2, CanvasCourseID = 560, OutcomeName = "Test Outcome", OutcomeMasteryScore = 3, OutcomeScore = 2},
                new Assessment() { CanvasAssessmentID = 3, CanvasCourseID = 560, OutcomeName = "Test Outcome", OutcomeMasteryScore = 3, OutcomeScore = 2},
                new Assessment() { CanvasAssessmentID = 4, CanvasCourseID = 560, OutcomeName = "Test Outcome", OutcomeMasteryScore = 3, OutcomeScore = 3},
                new Assessment() { CanvasAssessmentID = 5, CanvasCourseID = 560, OutcomeName = "Test Outcome", OutcomeMasteryScore = 3, OutcomeScore = 3},
                new Assessment() { CanvasAssessmentID = 6, CanvasCourseID = 560, OutcomeName = "Test Outcome", OutcomeMasteryScore = 3, OutcomeScore = 3},
                new Assessment() { CanvasAssessmentID = 7, CanvasCourseID = 560, OutcomeName = "Test Outcome", OutcomeMasteryScore = 3, OutcomeScore = 3},
                new Assessment() { CanvasAssessmentID = 8, CanvasCourseID = 560, OutcomeName = "Test Outcome", OutcomeMasteryScore = 3, OutcomeScore = 3},
                new Assessment() { CanvasAssessmentID = 9, CanvasCourseID = 560, OutcomeName = "Test Outcome", OutcomeMasteryScore = 3, OutcomeScore = 3},
                new Assessment() { CanvasAssessmentID = 10, CanvasCourseID = 560, OutcomeName = "Test Outcome", OutcomeMasteryScore = 3, OutcomeScore = 4},
                new Assessment() { CanvasAssessmentID = 11, CanvasCourseID = 560, OutcomeName = "Test Outcome2", OutcomeMasteryScore = 3, OutcomeScore = 1},
                new Assessment() { CanvasAssessmentID = 12, CanvasCourseID = 560, OutcomeName = "Test Outcome2", OutcomeMasteryScore = 3, OutcomeScore = 2},
                new Assessment() { CanvasAssessmentID = 13, CanvasCourseID = 560, OutcomeName = "Test Outcome2", OutcomeMasteryScore = 3, OutcomeScore = 2},
                new Assessment() { CanvasAssessmentID = 14, CanvasCourseID = 560, OutcomeName = "Test Outcome2", OutcomeMasteryScore = 3, OutcomeScore = 3},
                new Assessment() { CanvasAssessmentID = 15, CanvasCourseID = 560, OutcomeName = "Test Outcome2", OutcomeMasteryScore = 3, OutcomeScore = 3},
                new Assessment() { CanvasAssessmentID = 16, CanvasCourseID = 560, OutcomeName = "Test Outcome2", OutcomeMasteryScore = 3, OutcomeScore = 1},
                new Assessment() { CanvasAssessmentID = 17, CanvasCourseID = 560, OutcomeName = "Test Outcome2", OutcomeMasteryScore = 3, OutcomeScore = 3},
                new Assessment() { CanvasAssessmentID = 18, CanvasCourseID = 560, OutcomeName = "Test Outcome2", OutcomeMasteryScore = 3, OutcomeScore = 4},
                new Assessment() { CanvasAssessmentID = 19, CanvasCourseID = 560, OutcomeName = "Test Outcome2", OutcomeMasteryScore = 3, OutcomeScore = 4},
                new Assessment() { CanvasAssessmentID = 20, CanvasCourseID = 560, OutcomeName = "Test Outcome2", OutcomeMasteryScore = 3, OutcomeScore = 3},


                };
                context.Assessments.AddRange(Assessments);
                context.SaveChanges();
            }
        }
        public static List<Course> LoadCatalogFromHTLM(OutcomeManagementSystemContext context)
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
                //List<PreReqMap> preReqMaps = new List<PreReqMap>();
                List<PreReq> preReqs = new List<PreReq>();

                foreach (var courseXElem in coursesXElem)
                {
                    // Create a new course
                    var course = new Course();

                    // Get the course Department, Number, Title, and Units
                    IEnumerable<XElement> courseTitle = courseXElem.Elements("p").Where(a => a.Attribute("class").Value == "courseblocktitle");
                    string[] info = courseTitle.Elements("strong").FirstOrDefault().Value.Split("\n");
                    course.Department = info[1].Trim().Split(".")[0].Split(" ")[0].Trim();
                    course.Number = Convert.ToInt32(info[1].Trim().Split(".")[0].Split(" ")[1]);
                    course.Title = info[1].Trim().Split(".")[1].Trim();
                    //todo - fix this to deal with variable unit classes
                    course.Units = Convert.ToInt32(info[3].Trim().Split(" ")[0].Substring(0,1));

                    // Get the PreReqs for the course
                    IEnumerable<XElement> coursePrereqs = courseXElem.Elements("div").Where(c => c.Attribute("class").Value == "noindent courseextendedwrap");
                    IEnumerable<XElement> preReqNode = coursePrereqs.Elements("p");
                    
                    if (preReqNode.Count() > 0)
                    {
                        IEnumerable<XElement> preReqXElement = preReqNode.Elements("a").Where(c => c.Attribute("class").Value == "bubblelink code");
                        if (preReqXElement.Count() > 0)
                        {
                            foreach( var pr in preReqXElement)
                            {
                                string[] var = pr.Value.Split(" ");
                                var preReq = new PreReq();
                                preReq.CourseDept = course.Department;
                                preReq.CourseNumber = course.Number;
                                preReq.PreReqDept = var[0];
                                preReq.PreReqNumber = Convert.ToInt32(var[1]);
                                preReqs.Add(preReq);
                            }
                        }
                    }
                    
                   // Get the course Description
                    IEnumerable <XElement> courseDescXElem = courseXElem.Elements("div").Where(a => a.Attribute("class").Value == "courseblockdesc");
                    course.Description = courseDescXElem.Elements("p").FirstOrDefault().Value.Trim();

                    // Set Concentration, Year, and Quarter to "Default" values
                    course.Concentration = "Major";
                    course.Year = YearType.unknown;
                    course.Quarter = QuarterType.unknown;
                    courses.Add(course);
                }
                context.Courses.AddRange(courses);
                context.SaveChanges();
                
                foreach(var pr in preReqs)
                {
                    var course = courses.Find(c => c.Department == pr.CourseDept && c.Number == pr.CourseNumber);
                    var reqCourse = courses.Find(c => c.Department == pr.PreReqDept && c.Number == pr.PreReqNumber);

                    if (course != null && reqCourse != null)
                    {
                        pr.CourseID = course.ID;
                        pr.ReqCourseID = reqCourse.ID;
                        context.PreReqs.Add(pr);
                    }
                }
                
                /*
                foreach (var prm in preReqMaps)
                {
                    if (courses.Find(c => c.Department == prm.CourseDept && c.Number == prm.CourseNumber) != null)
                        prm.CourseID = courses.Find(c => c.Department == prm.CourseDept && c.Number == prm.CourseNumber).ID;


                    if (preReqs.Find(pr => pr.CourseDept == prm.PreReqDept && pr.CourseNumber == prm.PreReqNumber) != null)
                    {
                        prm.PreReqID = courses.Find(c => c.Department == prm.PreReqDept && c.Number == prm.PreReqNumber).ID;
                    }
                    else
                        prm.PreReqID = 1;

                    context.PreReqMaps.Add(prm);
                    context.SaveChanges();
                }
                //context.PreReqMaps.AddRange(preReqMaps);
                */
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                string s = "(ex, An error occurred seeding the DB.)";
            }
        
            return courses;
        }
    }
}
