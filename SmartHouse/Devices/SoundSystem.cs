using SmartHouse.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse.Devices
{
    public class SoundSystem : Device
    {
        private int volume;
        private bool isPlaying;

        public SoundSystem(string name, int volume = 50) : base(name)
        {
            if (volume < 0 || volume > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(volume), "Volume must be between 0 and 100.");
            }
            this.volume = volume;
            isPlaying = false;
        }

        public int Volume
        {
            get { return volume; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Volume must be between 0 and 100.");
                }
                volume = value;
            }
        }

        public bool IsPlaying
        {
            get { return isPlaying; }
        }

        public void Play()
        {
            if (!isOn) 
            {
                throw new InvalidOperationException("Cannot play if the device is turned off.");
            }
            isPlaying = true;
        }

        public void Pause()
        {
            if (!isOn) 
            {
                throw new InvalidOperationException("Cannot pause if the device is turned off.");
            }
            isPlaying = false;
        }

        public override string GetStatus()
        {
            if (!isOn) // Use the public property IsOn
            {
                return $"{base.GetStatus()} Volume: Unknown, Status: Unknown";
            }
            string playingStatus = isPlaying ? "Playing" : "Paused"; 
            return $"{base.GetStatus()} Volume: {volume}, Status: {playingStatus}";
        }
    }
}
