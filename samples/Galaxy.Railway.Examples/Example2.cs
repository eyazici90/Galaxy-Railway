using System.Threading.Tasks;

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

        public async Task<Optional<string>> RunAsync()
        {
            var city = Task.FromResult("Amsterdam");

            var result = await city;

            var upper = result.ToUpper();

            return new Optional<string>(upper);
        }

        public async Task<Optional<string>> RunFuncAsync() =>
            await Task.FromResult("Amsterdam")
                      .MapAsync(c => c.ToUpper()).ToOptionalAsync();
    }
}
