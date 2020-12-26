using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Business.Interfaces
{
    public interface ICustomLogger
    {
        public void LogError(string message);
    }
}
