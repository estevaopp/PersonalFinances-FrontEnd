using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PersonalFinances.Web.Controllers
{
    [Route("[controller]")]
    public abstract class ControllerBase : Controller
    {
        protected readonly ILogger<ControllerBase> _logger;

        protected ControllerBase(ILogger<ControllerBase> logger)
        {
            _logger = logger;
        }

        protected async Task<List<T>> RequestToApi<T>(HttpClient client)
        {
            string message = "";
            List<T> reponseData = new List<T>();

            using (HttpResponseMessage res = await client.GetAsync("v1/Employees"))
            {
                var result = res.Content.ReadAsStringAsync().Result;

                if (res.IsSuccessStatusCode)
                {
                    var resultModel = JsonConvert.DeserializeObject<ResultModel>(result);
                    if (!resultModel.Success)
                    {
                        message = resultModel.Error;

                        _logger.LogError(result.ToString());
                        ViewBag.ErroMessage = message;
                    }
                    else
                    {
                        reponseData = JsonConvert.DeserializeObject<List<T>>(resultModel.Data.ToString());
                    }
                }
            }

            return reponseData;
        }
    }
}