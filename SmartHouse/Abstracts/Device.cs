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
        public string Id { get; private set; }
        public string Name { get; private set; }
        public bool isOn { get; private set; }

        public virtual bool IsOn { get { return isOn; } }

        protected Device(string name) { 
            Id = Guid.NewGuid().ToString();
            Name = name;
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

        
        public string GetStatus()
        {
            return $"The device with name: {Name} is turned {(IsOn ? "On" : "Off")}."; 
        }

    }
}
