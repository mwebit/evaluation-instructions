using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using middlewareTest.Models;
using middlewareTest.Services;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Web.Http;

namespace middlewareTest.Controllers
{
    [Route("v1/companies/{id}")]
    [ApiController]
    [Produces("application/json")]
    public class CompaniesController : ControllerBase
    {
        IB2BData _b2bData;
        IConfiguration _config;
        
        public CompaniesController(IConfiguration config, IB2BData b2bData)
        {
            _b2bData = b2bData;
            _config = config;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
       public async Task<IActionResult> getCompanies(int id)
        {
            try
            {
                string url = "";
                if (id == 1)
                {
                    url = _config.GetSection("urlsForXmlData").GetSection("url1").Value;
                }
                else if (id == 2)
                {
                    url = _config.GetSection("urlsForXmlData").GetSection("url2").Value;
                }
                else
                {
                    return NotFound();
                }

                string jsonData = await _b2bData.GetData(url);

                if (jsonData.Contains("error"))
                {
                    return NotFound();
                }
                else
                {
                    return new JsonResult(jsonData);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        
    }
}