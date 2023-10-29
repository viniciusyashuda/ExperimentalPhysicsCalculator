namespace ExperimentalPhysicsCalculator
{
    internal class Measurement
    {
        public Measurement(
            decimal value, 
            decimal variation
        )
        {
            Value = value;
            Variation = variation;
        }

        public decimal Value { get; set; }
        public decimal Variation { get; set; }

        internal Measurement MultiplicateByConst(
            Measurement measurement,
            int constant
        )
        {
            measurement.Value *= constant;
            measurement.Variation *= constant;
            
            return measurement;
        }
    }
}