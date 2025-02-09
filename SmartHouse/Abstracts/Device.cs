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

        public event Action<string> StatusChanged;

        protected Device(string name) { 
            id = Guid.NewGuid().ToString();
            deviceName = name;
            isOn = false;
        }

        public virtual void TurnOn()
        {
            isOn = true;
            OnStatusChanged($"Device {deviceName} is turned on");
        }
        public virtual void TurnOff()
        {
            isOn = false;
            OnStatusChanged($"Device {deviceName} is turned off");
        }

        
        public virtual string GetStatus()
        {
            return $"The device with name: {deviceName} is turned {(isOn ? "On" : "Off")}."; 
        }

        protected void OnStatusChanged(string status)
        {
            StatusChanged?.Invoke(status);
        }

    }
}
