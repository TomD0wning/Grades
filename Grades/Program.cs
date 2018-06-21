using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello! This is the grade book program");
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello! This is the grade book program");

            GradeBook book = new GradeBook();

            GetBookName(book);

            //book.NameChanged += new NameChangedDelegate(OnNameChanged
            //book.Name = "Tom";
            //book.Name = "Tom's";

            AddGrades(book);

            SaveGrades(book);

            WriteResults(book);
        }

        private static void WriteResults(GradeBook book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name + " gradebook.");
            WriteResults("Average ", stats.AverageGrade);
            WriteResults("Highest", (int)stats.HighestGrade);
            WriteResults("Lowest: ", stats.LowestGrade);
            WriteResults(stats.Description, stats.LetterGrade);

            Console.ReadLine();
        }

        private static void SaveGrades(GradeBook book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
                //outputFile.Dispose();
            }
        }

        private static void AddGrades(GradeBook book)
        {
            book.AddGrade(88);
            book.AddGrade(95.2f);
            book.AddGrade(41);
        }

        private static void GetBookName(GradeBook book)
        {
            try
            {
                Console.WriteLine("Enter a gradebook name:");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Somthing went wrong");
            }
        }

        //class helper method

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Gradebook changing name from {args.ExisingName} to {args.NewName}.");
        }

        //static void WriteResults(String description,int result)
        //{

        //    Console.WriteLine(description + ": " + result);

        //}
        static void WriteResults(String description, float result)
        {

            Console.WriteLine($"{description}: {result:F2}");

        }
        static void WriteResults(String description, string result)
        {

            Console.WriteLine($"{description}: {result}");

        }
    }
}

