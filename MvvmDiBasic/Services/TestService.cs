using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmDiBasic.Services
{
    public class TestService : ITestService
    {
        public string HelloWorld()
        {
            return "Hello world"; 
        }
    }
}
