using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUI.Services
{
    public partial class BiometricService
    {
        public partial void FingerprintValidate(Action onSuccess, Action onFailure);
    }
}
