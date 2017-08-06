using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session010_Interfaces
{
    class Television : IElectronicDevice
    {
        private int volume;

        public Television()
            : this(0) { }

        public Television(int volume)
        {
            Volume = volume;
        }

        //defined volume here
        public int Volume {
            get
            {
                return volume;
            }
            set
            {
                if(value < 0)
                {
                    volume = 0;
                }
                else
                {
                    volume = value;
                }
            }
        }

        public void Off()
        {
            Console.WriteLine("The TV is Off.");
        }

        public void On()
        {
            Console.WriteLine("The TV is On.");
        }

        public void VolumeDown()
        {
            if(volume != 0)
            {
                --volume;
                Console.WriteLine($"Volume is down to {volume}");
            }
        }

        public void VolumeUp()
        {
            if (volume != 100)
            {
                ++volume;
                Console.WriteLine($"Volume is up to {volume}");
            }
        }
    }
}
