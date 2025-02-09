using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Interfaces;

namespace SmartHouse.Abstracts
{
    public abstract class Device : IDevice
    {
        public string id { get; private set; }
        public string deviceName { get; protected set; }
        public bool isOn { get; protected set; }


        protected Device(string name) { 
            id = Guid.NewGuid().ToString();
            deviceName = name;
            isOn = false;
        }

        public virtual void TurnOn()
        {
            isOn = true;
        }
        public virtual void TurnOff()
        {
            isOn = false;
        }

        
        public virtual string GetStatus()
        {
            return $"The device with name: {deviceName} is turned {(isOn ? "On" : "Off")}."; 
        }

    }
}
