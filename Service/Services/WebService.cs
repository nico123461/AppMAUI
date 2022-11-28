using Service.Model;
using Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class WebService: AbstractWebService, IWebService
    {
        public WebService() { }

        public Task<List<Employee>> GetAllEmployees()
        {
            return ExecURI<List<Employee>>("");
        }
    }
}
