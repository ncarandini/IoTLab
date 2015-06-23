using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BilnkingLeds.WUA
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool gpioAvailable;
        GpioController gpio;
        GpioPin pin;

        public MainPage()
        {
            this.InitializeComponent();
            InitGpio();
        }

        private void InitGpio()
        {
            gpioAvailable = false;
            gpio = GpioController.GetDefault();
            if (gpio != null)
            {
                pin = gpio.OpenPin(5);
                if (pin != null)
                {
                    pin.Write(GpioPinValue.Low);
                    pin.SetDriveMode(GpioPinDriveMode.Output);
                    gpioAvailable = true;
                }
            }
        }

        private void toggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (toggleSwitch.IsOn)
            {
                AccendiLed();
            }
            else
            {
                SpengiLed();
            }
        }

        private void AccendiLed()
        {
            if (gpioAvailable)
            {
                pin.Write(GpioPinValue.High);
            }
        }

        private void SpengiLed()
        {
            if (gpioAvailable)
            {
                pin.Write(GpioPinValue.Low);
            }
        }

    }
}
