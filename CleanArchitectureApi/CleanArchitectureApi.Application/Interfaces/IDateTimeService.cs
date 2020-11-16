using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureApi.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
