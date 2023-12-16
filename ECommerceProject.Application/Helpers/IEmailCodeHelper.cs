using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Application.Helpers
{
    public interface IEmailCodeHelper
    {
        public Task<int> GenerateCode();
    }
}
