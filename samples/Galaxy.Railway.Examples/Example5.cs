using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Railway.Examples
{
    public class Example5
    {
        private readonly IFakeService _fakeService;
        private readonly ISomeAnotherService _someAnotherService;
        public Example5(IFakeService fakeService,
            ISomeAnotherService someAnotherService)
        {
            _fakeService = fakeService;
            _someAnotherService = someAnotherService;
        }

        public async Task<IEnumerable<int>> Run(string identifer)
        {
            var data = await _fakeService.Get(identifer); 
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException();
            } 
            var result = await _someAnotherService.Do(data); 
            var mapped = result.Select(int.Parse); 
            return mapped;
        }

        public async Task<IEnumerable<int>> RunFunc(string identifer) =>
           await _fakeService.Get(identifer)
            .ThrowsIfAsync(string.IsNullOrEmpty, new ArgumentNullException())
            .AndThenAsync(_someAnotherService.Do)
            .SelectAsync(int.Parse);
    }

    public interface IFakeService
    {
        Task<string> Get(string id);
    }
    public interface ISomeAnotherService
    {
        Task<IEnumerable<string>> Do(string name);
    }
}
