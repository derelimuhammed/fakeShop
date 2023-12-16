using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Application.Helpers;

namespace ECommerceProject.Persistence.Helpers
{
    public class EmailCodeHelper:IEmailCodeHelper
    {
        public Task<int> GenerateCode()
        {
            Random random = new Random();
            int code;
            code = random.Next(100000, 1000000);
            return Task.FromResult<int>(code); 
        }
    }
}
