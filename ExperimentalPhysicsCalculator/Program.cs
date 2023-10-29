using ExperimentalPhysicsCalculator.Subjects.ErrorPropagations;
using ExperimentalPhysicsCalculator.Subjects.StatisticalTreatments;
using System;

namespace ExperimentalPhysicsCalculator
{
    public class Program
    {
        public static IErrorPropagation _errorPropagation = new ErrorPropagation();
        public static IStatisticalTreatment _statisticalTreatment = new StatisticalTreatment();

        public Program(
            IErrorPropagation errorPropagation,
            IStatisticalTreatment statisticalTreatment
        )
        {
            _errorPropagation = errorPropagation;
            _statisticalTreatment = statisticalTreatment;
        }

        static void Main(string[] args)
        {
            var subject = "";

            do
            {
                Console.WriteLine("######## Home ########");
                Console.WriteLine(
                    "(1) Error propagation\n" +
                    "(2) Statistical treatment\n" +
                    "(3) Leave"
                );

                Console.Write("Subject: ");
                subject = Console.ReadLine();

                Console.Clear();

                switch (subject)
                {
                    case "1":
                        _errorPropagation.ErrorPropagationCalculation();
                        break;

                    case "2":
                        _statisticalTreatment.StatisticalTreatmentCalculation();
                        break;

                    case "3":
                        Console.WriteLine("Leaving...");
                        break;

                    default:
                        Console.WriteLine("Invalid  option. Try again");
                        break;
                }

                Console.Clear();

            } while (subject != "3");
        }
    }
}
