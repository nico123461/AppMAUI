using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utils
{
    public interface IStopTaskWEB
    {
        /// <summary>
        /// Detiene cualquier tarea que se esté ejecutando en segundo plano
        /// </summary>
        void StopTask();
    }
}
