using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session010_Interfaces
{
    interface IDrivable
    {
        //interfaces contain abstract methods and values.
        //classes that implement this interface must
        //also implement ALL methods and use ALL values in here.

        int Wheels { get; set; }
        double Speed { get; set; }

        void Move();
        void Stop();
    }
}
