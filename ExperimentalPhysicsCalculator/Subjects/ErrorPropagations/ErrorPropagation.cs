using System;

namespace ExperimentalPhysicsCalculator.Subjects.ErrorPropagations
{
    public class ErrorPropagation : IErrorPropagation
    {
        public void ErrorPropagationCalculation()
        {
            var measurements = GetMeasurement();
            var measurement1 = measurements.Item1;
            var measurement2 = measurements.Item2;

            Console.Write(
                "\nWhat operation would you like to do?\n" +
                "(1) Sum\n" +
                "(2) Subtraction\n" +
                "(3) Multiplication\n" +
                "(4) Division\n" +
                "(5) Potentiation\n" +
                "Operation: "
            );

            var operation = Console.ReadLine();
            Console.Clear();

            switch (operation)
            {
                case "1":
                    Console.WriteLine("Answer: " + Sum(measurement1, measurement2));
                    break;

                case "2":
                    Console.WriteLine("Answer: " + Subtraction(measurement1, measurement2));
                    break;

                case "3":
                    Console.WriteLine("Answer: " + Multiplication(measurement1, measurement2));
                    break;

                case "4":
                    Console.WriteLine("Answer: " + Division(measurement1, measurement2));
                    break;

                case "5":
                    Console.WriteLine("To what power would you like to raise?");
                    var power = Console.ReadLine();

                    Console.WriteLine("Answer: " + Potentiation(measurement1, int.Parse(power)));
                    break;

                default:
                    break;
            }
        }

        private (Measurement, Measurement) GetMeasurement()
        {
            Console.Write("Please, enter the first measurement's value: ");
            var stringValue1 = Console.ReadLine();

            Console.Write("Please, enter the first measurement's variation: ");
            var stringVariation1 = Console.ReadLine();

            Console.Write("Please, enter the second measurement's value: ");
            var stringValue2 = Console.ReadLine();

            Console.Write("Please, enter the second measurement's variation: ");
            var stringVariation2 = Console.ReadLine();

            return (new Measurement(
                    decimal.Parse(stringValue1.Replace(",", ".")),
                    decimal.Parse(stringVariation1.Replace(",", "."))
                ),
                new Measurement(
                    decimal.Parse(stringValue2.Replace(",", ".")),
                    decimal.Parse(stringVariation2.Replace(",", "."))
                )
            );
        }

        private string Sum(
            Measurement measurement1,
            Measurement measurement2
        ) =>
            measurement1.Value + measurement2.Value +
            " +/- " +
            (measurement1.Variation + measurement2.Variation);

        private string Subtraction(
            Measurement measurement1,
            Measurement measurement2
        ) =>
            measurement1.Value - measurement2.Value +
            " +/- " +
            (measurement1.Variation + measurement2.Variation);

        private string Multiplication(
            Measurement measurement1,
            Measurement measurement2
        ) =>
            measurement1.Value * measurement2.Value +
            " +/- " +
            (measurement1.Value * measurement2.Variation + measurement2.Value * measurement1.Variation);

        private string Division(
            Measurement measurement1,
            Measurement measurement2
        ) =>
            measurement1.Value / measurement2.Value +
            " +/- " +
            1 / (decimal)Math.Pow((double)measurement2.Value, 2) *
            (measurement1.Value * measurement2.Variation + measurement2.Value * measurement1.Variation);

        private string Potentiation(
            Measurement measurement1,
            int power
        ) =>
            Math.Pow((double)measurement1.Value, power) +
            " +/- " +
            power * (decimal)Math.Pow((double)measurement1.Value, power - 1) * measurement1.Variation;
    }
}