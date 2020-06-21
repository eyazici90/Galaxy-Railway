namespace Galaxy.Railway.Examples
{ 
    public class Example2
    { 
        public Optional<string> Run()
        {
            var city = "Amsterdam";

            var upper = city.ToUpper();

            return new Optional<string>(upper);
        } 

        public Optional<string> RunFunc() =>
            "Amsterdam".ToUpper().ToOptional();
    }
}
