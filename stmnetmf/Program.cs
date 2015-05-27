using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace stmnetmf
{
    public class Program
    {
        static readonly OutputPort RedPort = new OutputPort(DiscoveryF4.RedLedPin, false);
        static readonly OutputPort BluePort = new OutputPort(DiscoveryF4.BlueLedPin, false);
        static readonly OutputPort OrangePort = new OutputPort(DiscoveryF4.OrangeLedPin, false);
        static readonly OutputPort GreenPort = new OutputPort(DiscoveryF4.GreenLedPin, false);
        private static long _counter;

        public static void Main()
        {
            InterruptPort buttonInterruptPort = new InterruptPort(DiscoveryF4.UserButton, true, Port.ResistorMode.PullDown,
                Port.InterruptMode.InterruptEdgeHigh);
            buttonInterruptPort.OnInterrupt += buttonInterruptPort_OnInterrupt;
            buttonInterruptPort.EnableInterrupt();
            Thread.Sleep(Timeout.Infinite);
        }

        static void buttonInterruptPort_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            switch (_counter % 4)
            {
                case 0:
                    RedPort.Write(true);
                    BluePort.Write(false);
                    OrangePort.Write(false);
                    GreenPort.Write(false);
                    break;
                case 1:
                    RedPort.Write(false);
                    BluePort.Write(true);
                    OrangePort.Write(false);
                    GreenPort.Write(false);
                    break;
                case 2:
                    RedPort.Write(false);
                    BluePort.Write(false);
                    OrangePort.Write(false);
                    GreenPort.Write(true);
                    break;
                case 3:
                    RedPort.Write(false);
                    BluePort.Write(false);
                    OrangePort.Write(true);
                    GreenPort.Write(false);
                    break;
            }
            ++_counter;
        }
    }
}
