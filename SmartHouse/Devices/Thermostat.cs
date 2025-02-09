using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Abstracts;

namespace SmartHouse.Devices
{
    public class Thermostat : Device
    {
        private int currentTemperature;
        private int? desiredTemperature;

        public Thermostat(string name, int initialTemperature) : base(name){
            currentTemperature = initialTemperature;
            desiredTemperature = null;
        }

        public void SetDesiredTemperature(int temperature)
        {
            if (temperature < 0 || temperature > 50)
            {
                throw new ArgumentOutOfRangeException("Temperature must be between 0 and 50 degrees ");
            }
            desiredTemperature = temperature;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            
            if (desiredTemperature.HasValue) 
            { 
                //usually it would read current temperature from sensor on thermostat into currentTemperature
                //this is for simulation purposes of the system
                currentTemperature = desiredTemperature.Value;
            }
            else
            {
                throw new InvalidOperationException("Cannot tunr on themostat without set desired temperatur.");
            }


        }
        public override string GetStatus()
        {
            string currentTempStatus = isOn ? $"Current temperature is: {currentTemperature}" : "Current temperature is: Unknown";
            string desiredTempStatus = desiredTemperature.HasValue ? $", Desired temperature is: {desiredTemperature.Value}": $", Desired temperature is: Not set";

            return $"{base.GetStatus()}{currentTempStatus}{desiredTempStatus}.";
        }
    }
}
