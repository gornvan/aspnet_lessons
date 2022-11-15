using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decorator_bonus
{
    public abstract class Logger
    {

        public virtual void Log(string message) {
            // todo: every time we log, write to DB
            Console.WriteLine(message);

        }

    }
}
