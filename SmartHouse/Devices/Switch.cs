using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Abstracts;

namespace SmartHouse.Devices
{
    public class Switch : Device
    {
        public Switch(string name): base(name)
        {
        }

        public void Toggle()
        {
            if (isOn)
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }
        }
    }
}
