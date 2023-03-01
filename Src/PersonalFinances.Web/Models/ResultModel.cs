using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinances.Web.Models
{
    public class ResultModel
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public object Error { get; set; }

        public ResultModel() { }

        public ResultModel(bool sucess, object data = null, object error = null)
        {
            Success = sucess;
            Data = data;
            Error = error;
        }
    }
}