using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipedriveNet
{
    [Serializable]
    public class PipedriveException : Exception
    {
        public PipedriveException(string error):base(error)
        {
            
        }
    }
}
