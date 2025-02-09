using System;
using SmartHouse.Devices;
using SmartHouse.Services;

namespace SmartHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize logger
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Logs", "device_logs.txt");
            Logger logger = new Logger(logFilePath);


            // Initialize device manager
            DeviceManager deviceManager = new DeviceManager(logger);

            // Create devices
            Thermostat thermostat = new Thermostat("Living Room Thermostat", 22);
            SmartLock smartLock = new SmartLock("Main Door Lock");
            SoundSystem soundSystem = new SoundSystem("Living Room Sound System", 50);
            Switch lightSwitch = new Switch("Living Room Light Switch");

            // Add devices to the manager
            deviceManager.AddDevice(thermostat);
            deviceManager.AddDevice(smartLock);
            deviceManager.AddDevice(soundSystem);
            deviceManager.AddDevice(lightSwitch);

            // Turn on devices
            thermostat.SetDesiredTemperature(22);
            thermostat.TurnOn();
            smartLock.TurnOn();
            soundSystem.TurnOn();
            lightSwitch.TurnOn();

            // Log device statuses
            Console.WriteLine(deviceManager.ListDevices());

            // Interact with devices
            smartLock.SetPassword("securePassword");
            smartLock.Unlock("securePassword");
            Console.WriteLine(smartLock.GetStatus());

            soundSystem.Play();
            Console.WriteLine(soundSystem.GetStatus());

            // Change thermostat temperature
            thermostat.SetDesiredTemperature(25);
            Console.WriteLine(thermostat.GetStatus());

            // Turn off devices
            lightSwitch.TurnOff();
            soundSystem.Pause();
            smartLock.Lock("securePassword");
            thermostat.TurnOff();

            // Log final statuses
            Console.WriteLine(deviceManager.ListDevices());

            // Clean up
            deviceManager.ClearDevices();
        }
    }
}