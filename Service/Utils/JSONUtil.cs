using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utils
{
    internal class JSONUtil
    {
        public static TObject DeserialiceObject<TObject>(string content)
        {
            return JsonConvert.DeserializeObject<TObject>(content);
        }
    }
}
