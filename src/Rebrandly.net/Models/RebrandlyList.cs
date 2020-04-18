using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly.Models
{
    public class RebrandlyList<T> : RebrandlyEntity<RebrandlyList<T>>, IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
