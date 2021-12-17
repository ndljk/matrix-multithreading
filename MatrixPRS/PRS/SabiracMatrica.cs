using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixPRS.PRS
{
    public abstract class SabiracMatrica
    {

        protected Stopwatch stopwatch = new Stopwatch();
        public long Time { get { return stopwatch.ElapsedMilliseconds; } }
        public abstract Matrix Saberi(Matrix matricaA, Matrix matricaB);
    }
}
