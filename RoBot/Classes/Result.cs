using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoBot.Classes
{
    /// <summary>
    /// General action result
    /// </summary>
    public class Result
    {
        public Result(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; set; }
    }
}
