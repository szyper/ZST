using System;
using System.Collections.Generic;
using System.Text;

namespace _11_kompozycja.Models
{
    internal class Radio
    {
        public bool IsOn { get; private set; }
        public Radio(bool isOn)
        {
            IsOn = isOn;
        }

        public void ShowRadioInfo()
        {
            Console.WriteLine(IsOn ? "Radio jest włączone" : "Radio jest wyłączone");
        }
    }
}
