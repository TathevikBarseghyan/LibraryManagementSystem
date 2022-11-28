using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Models.ResponseModel
{
    public class OperationResultModel
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public string Result { get; set; }
    }
}
