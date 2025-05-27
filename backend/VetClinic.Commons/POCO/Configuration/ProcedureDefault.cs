namespace VetClinic.Commons.Configuration
{
    public class ProcedureDefault
    {
        public ProcedureDefault() { }

        public ProcedureDefault(string code, TimeSpan duration, decimal price) 
        {
            Code = code;
            Duration = duration;
            Price = price;
        }

        public string Code { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Price {  get; set; }

    }
}
