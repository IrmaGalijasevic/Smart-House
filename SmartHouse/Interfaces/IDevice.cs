using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Interfaces
{
    public interface IDevice
    {
        string id { get; }
        string deviceName { get; }
        bool isOn { get;}

        void TurnOff();
        void TurnOn();
        string GetStatus();

    }
}
