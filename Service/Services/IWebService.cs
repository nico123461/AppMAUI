using Service.Model;
using Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface IWebService: IStopTaskWEB
    {
        Task<List<Employee>> GetAllEmployees();
    }
}
