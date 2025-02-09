using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Abstracts;

namespace SmartHouse.Services
{
    public class DeviceManager
    {
        private List<Device> devices;
        private Logger logger;

        public DeviceManager(Logger logger) 
        {
            devices = new List<Device>();
            this.logger = logger;
        }

        public void AddDevice(Device device)
        {
            if (device == null)
            {
                throw new ArgumentNullException("Device is not defined");
            }
            devices.Add(device);
            device.StatusChanged += logger.Log;
        }

        public Device FindDevice(string name) 
        {
            var device = devices.Find(d => d.deviceName.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (device == null)
            {
                throw new InvalidOperationException($"Device with name '{name}' not found.");
            }
            return device;
        }

        public void RemoveDevice(Device device)
        {
            if (device == null)
            {
                throw new ArgumentNullException("Device not found");
            }
            device.StatusChanged -= logger.Log;
            if (!devices.Remove(device))
            {
                throw new InvalidOperationException("Device not found");
            }

        }

        public string ListDevices()
        {
            if (devices.Count == 0)
            {
                return "No devices found.";
            }

            StringBuilder deviceList = new StringBuilder();
            deviceList.AppendLine($"Total number of devices: {devices.Count}");
            deviceList.AppendLine("Devices: ");
            foreach (Device device in devices)
            {
                string deviceType = device.GetType().Name;
                deviceList.AppendLine($" - {device.deviceName} ({deviceType}) : {device.GetStatus()}");
            }
            return deviceList.ToString();
        }

        public void ClearDevices()
        {
            foreach (var device in devices)
            {
                device.StatusChanged -= logger.Log;
            }
            devices.Clear();
        }

        public void TurnOnDevice(string deviceName)
        {
            var device = FindDevice(deviceName);
            device.TurnOn();
        }

        public void TurnOffDevice(string deviceName)
        {
            var device = FindDevice(deviceName);
            device.TurnOff();
        }

        public string GetDeviceStatus(string deviceName)
        {
            var device = FindDevice(deviceName);
            return device.GetStatus();
        }

    }
}
