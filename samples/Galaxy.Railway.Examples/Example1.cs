using System;

namespace Galaxy.Railway.Examples
{
    public class Example1
    {
        public Unit Run(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentNullException();
            }

            var trimCity = city.Trim();

            var upperCity = trimCity.ToUpper();

            Console.WriteLine(upperCity);

            return Unit.Value;
        }

        public Unit RunFunc(string city) =>
               city.ThrowsIf(string.IsNullOrEmpty, new ArgumentNullException())
                .AndThen(c => c.Trim())
                .Map(c => c.ToUpper())
                .AndThen(Console.WriteLine)
                .Map(_ => Unit.Value);
    }
}
