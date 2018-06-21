using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

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
            book.AddGrade(4);
            book.AddGrade(95.2f);
            book.AddGrade(45);
            GradeStatistics stats = book.ComputeStatistics();

            book.NameChanged += new NameChangedDelegate(OnNameChanged);
            
            book.Name = "Tom";
            book.Name = "Tom's";

            Console.WriteLine(book.Name + " gradebook.");
            WriteResults("Average ",stats.AverageGrade);
           WriteResults("Highest", (int)stats.HighestGrade);
            WriteResults("Lowest: ", stats.LowestGrade);



            Console.ReadLine();
        }
        //class helper method

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Gradebook changing name from {args.ExisingName} to {args.NewName}.");
        }

        static void WriteResults(String description,int result)
        {

            Console.WriteLine(description + ": " + result);

        }
        static void WriteResults(String description, float result)
        {

            Console.WriteLine($"{description}: {result:F2}");

        }
    }
}

