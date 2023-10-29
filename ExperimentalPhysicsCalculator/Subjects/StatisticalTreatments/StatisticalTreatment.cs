using System;

namespace ExperimentalPhysicsCalculator.Subjects.StatisticalTreatments
{
    public class StatisticalTreatment : IStatisticalTreatment
    {
        public void StatisticalTreatmentCalculation()
        {
            Console.WriteLine("What was the precision or variation with which the measurements were obtained?");
            var stringVariation = Console.ReadLine();
            var variation = decimal.Parse(stringVariation.Replace(",", "."));

            Console.WriteLine("How many measurements were taken? It must be at least 2, if you enter a lower number, it will be considered 2");
            var measurementsTaken = int.Parse(Console.ReadLine());
            measurementsTaken = measurementsTaken > 1 ? measurementsTaken : 2;

            Console.WriteLine("Please, enter each measurement's value");
            var measurements = new Measurement[measurementsTaken];

            for (int measurementPosition = 0; measurementPosition < measurementsTaken; measurementPosition++)
            {
                Console.Write("Measurement number " + (measurementPosition + 1) + ": ");
                var stringValue = Console.ReadLine();
                measurements[measurementPosition] = new Measurement(decimal.Parse(stringValue.Replace(",", ".")), variation);
            }

            Console.Clear();

            PerformStatisticalTreatment(measurements, variation, measurementsTaken);
        }

        private void PerformStatisticalTreatment(
            Measurement[] measurements,
            decimal variation,
            int measurementsTaken
        )
        {
            var avarage = CalculateAverage(measurements, measurementsTaken);
            var absoluteDeviation = CalculateAbsoluteDeviation(measurements, avarage, measurementsTaken);
            var meanAbsoluteDeviation = CalculateMeanAbsoluteDeviation(absoluteDeviation, measurementsTaken);
            var standardDeviation = CalculateStandardDeviation(absoluteDeviation, measurementsTaken);
            var meanStandardDeviation = CalculateMeanStandardDeviation(standardDeviation, measurementsTaken);
            var result = ShowFinalResult(meanStandardDeviation, avarage, variation);

            Console.WriteLine("\nResults obtained: \n");

            Console.WriteLine("Average: " + avarage);

            Console.WriteLine("Absolute Deviation:");
            for (int position = 0; position < absoluteDeviation.Length; position++)
                Console.WriteLine("d" + (position + 1) + "= " + Math.Round(absoluteDeviation[position], 2));

            Console.WriteLine("Mean Absolute Deviation: " + meanAbsoluteDeviation);

            Console.WriteLine("Standard Deviation: " + standardDeviation);

            Console.WriteLine("Mean Standard Deviation: " + meanStandardDeviation);

            Console.WriteLine("Result: " + result);
        }

        private decimal CalculateAverage(
            Measurement[] measurements,
            int measurementsTaken
        )
        {
            decimal measurementsSum = 0;

            foreach (var measurement in measurements)
                measurementsSum += measurement.Value;

            return Math.Round(measurementsSum / measurementsTaken, 2);
        }

        private decimal[] CalculateAbsoluteDeviation(
            Measurement[] measurements,
            decimal average,
            int measurementsTaken
        )
        {
            var absoluteDeviation = new decimal[measurementsTaken];

            for (int measurementPosition = 0; measurementPosition < measurementsTaken; measurementPosition++)
                absoluteDeviation[measurementPosition] = measurements[measurementPosition].Value - average;

            return absoluteDeviation;
        }

        private decimal CalculateMeanAbsoluteDeviation(
            decimal[] absoluteDeviation,
            int measurementsTaken
        )
        {
            decimal absoluteDeviationSum = 0;

            foreach (var value in absoluteDeviation)
                absoluteDeviationSum += value < 0 ? value * -1 : value;

            return Math.Round(absoluteDeviationSum / measurementsTaken, 2);
        }

        private decimal CalculateStandardDeviation(
            decimal[] absoluteDeviation,
            int measurementsTaken
        )
        {
            var absoluteDeviationPowSum = 0.0;

            foreach (var value in absoluteDeviation)
                absoluteDeviationPowSum += Math.Pow((double)value, 2);

            return Math.Round((decimal)Math.Sqrt(absoluteDeviationPowSum / (measurementsTaken - 1)), 2);
        }

        private decimal CalculateMeanStandardDeviation(
            decimal standardDeviation,
            int measurementsTaken
        ) =>
            Math.Round(standardDeviation / (decimal)Math.Sqrt(measurementsTaken), 2);

        private string ShowFinalResult(
            decimal meanStandardDeviation,
            decimal average,
            decimal variation
        ) =>
            average + " ± " + Math.Round(meanStandardDeviation + variation, 2);
    }
}