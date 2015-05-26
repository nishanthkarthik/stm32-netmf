using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace stmnetmf
{
    public class Program
    {
        public static void Main()
        {
            Thread greenThread = new Thread(BlinkThread.GreenLed);
            Thread redThread = new Thread(BlinkThread.RedLed);
            Thread blueThread = new Thread(BlinkThread.BlueLed);
            Thread orangeThread = new Thread(BlinkThread.OrangeLed);
            greenThread.Start();
            redThread.Start();
            blueThread.Start();
            orangeThread.Start();
        }
    }

    public class BlinkThread
    {
        static readonly OutputPort GreenOutputPort = new OutputPort(Pins.GpioPinD12, true);
        static readonly OutputPort RedOutputPort = new OutputPort(Pins.GpioPinD14, true);
        static readonly OutputPort BlueOutputPort = new OutputPort(Pins.GpioPinD15, true);
        static readonly OutputPort OrangeOutputPort = new OutputPort(Pins.GpioPinD13, true);

        public static void GreenLed()
        {
            while (true)
            {
                GreenOutputPort.Write(true);
                Thread.Sleep(2000);
                GreenOutputPort.Write(false);
                Thread.Sleep(2000);
            }
        }

        public static void BlueLed()
        {
            while (true)
            {
                BlueOutputPort.Write(true);
                Thread.Sleep(1000);
                BlueOutputPort.Write(false);
                Thread.Sleep(1000);
            }

        }

        public static void RedLed()
        {
            while (true)
            {
                RedOutputPort.Write(true);
                Thread.Sleep(500);
                RedOutputPort.Write(false);
                Thread.Sleep(500);
            }

        }

        public static void OrangeLed()
        {
            while (true)
            {
                OrangeOutputPort.Write(true);
                Thread.Sleep(250);
                OrangeOutputPort.Write(false);
                Thread.Sleep(250);
            }
        }
    }
}
