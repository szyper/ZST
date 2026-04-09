using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesApp.Models
{
    internal class Radio
    {
        public bool IsOn { get; private set; }
        
        public Radio(bool isOn)
        {
            IsOn = isOn;
        }

        public void TurnOn()
        {
            if (!IsOn)
            {
                Console.WriteLine("Włączam radio...");
                IsOn = true;
            } else
            {
                Console.WriteLine("Radio jest włączone");
            }
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                Console.WriteLine("Wyłączam radio...");
                IsOn = false;
            } else
            {
                Console.WriteLine("Radio jest wyłączone");
            }
             
        }

        public void ShowRadioInfo()
        {
            Console.WriteLine(IsOn ? "Radio jest włączone" : "Radio jest wyłączone");
        }
    }
}