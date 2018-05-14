using System;

namespace PipedriveNet
{
    [Serializable]
    public class PipedriveException : Exception
    {
        public PipedriveException(string error) : base(error)
        {

        }
    }
}
