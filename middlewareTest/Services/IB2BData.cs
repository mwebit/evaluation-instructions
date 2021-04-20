using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using middlewareTest.Models;

namespace middlewareTest.Services
{
    public interface IB2BData
    {
       Task<string> GetData(string url);
    }
}
