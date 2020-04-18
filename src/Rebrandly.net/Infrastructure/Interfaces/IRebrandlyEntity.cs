using Rebrandly.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly
{
    /// <summary>
    /// Interface that identifies all entities returned by Rebrandly.
    /// </summary>
    public interface IRebrandlyEntity
    {
        RebrandlyResponse RebrandlyResponse { get; set; }
    }
}
