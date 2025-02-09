using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Abstracts;
using SmartHouse.Services;

namespace SmartHouse.Devices
{
    public class SmartLock : Device
    {
        private bool isLocked;
        private PasswordHash passwordHash = null!;

        public SmartLock(string name) : base(name)
        {
            isLocked = true;
        }

        public bool IsLocked()
        {
            return isLocked;
        }

        public void SetPassword(string password, bool isChange = false)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty");
            }

            if (passwordHash != null && !isChange)
            {
                throw new ArgumentException("Password is already set");
            }

            passwordHash = new PasswordHash(password);
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            if (passwordHash == null)
            {
                throw new ArgumentException("Password hasn't been set yet");
            }

            if (!passwordHash.Verify(oldPassword))
            {
                throw new ArgumentException("Old password is incorrect");
            }

            SetPassword(newPassword, true);
        }

        public void Unlock(string enteredPassword)
        {
            if (!isOn)
            {
                throw new InvalidOperationException("Smart lock is turned off, cannot unlock");
            }
            if (isLocked)
            {
                if (passwordHash != null && passwordHash.Verify(enteredPassword))
                {
                    isLocked = false;
                }
                else
                {
                    throw new UnauthorizedAccessException("Password is incorrect");
                }
            }
        }

        public void Lock(string enteredPassword)
        {
            if (!isOn)
            {
                throw new InvalidOperationException("Smart lock is turned off, cannot unlock");
            }
            isLocked = true;
        }

        public override string GetStatus()
        {
            string lockStatus = !isOn ? "Unknown" : (isLocked ? "Locked" : "Unlocked");
            string setPasswordStatus = passwordHash != null ? "Password is set." : "Password is not set;";
            return $"{base.GetStatus()} Lock status: {lockStatus}, {setPasswordStatus}";
        }
    }
}