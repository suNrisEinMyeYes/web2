using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weblab2.Models
{
    public class ResultModel
    {
        public int first { get; set; }
        public int second { get; set; }
        public int calculationResult { get; set; }
        public string operation { get; set; }

        public ResultModel() { }
        public ResultModel(int first,int second,string operation)
        {
            this.first = first;
            this.second = second;
            this.operation = operation;
        }
    }
}
