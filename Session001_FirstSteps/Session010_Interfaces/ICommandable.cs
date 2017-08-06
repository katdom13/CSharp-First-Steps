using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session010_Interfaces
{
    interface ICommandable
    {
        //model of what happens when a button is pressed
        //and undone.
        void Execute();
        void Undo();
    }
}
