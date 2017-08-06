using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session010_Interfaces
{
    class VolumeButton : ICommandable
    {

        public IElectronicDevice Device { get; set; }

        public VolumeButton(IElectronicDevice device)
        {
            Device = device;
        }
        
        public void Execute()
        {
            Device.VolumeUp();
        }

        public void Undo()
        {
            Device.VolumeDown();
        }
    }
}
