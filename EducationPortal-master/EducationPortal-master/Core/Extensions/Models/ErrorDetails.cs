using Core.Entities.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions.Models
{
    public class ErrorDetails : IModel
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
