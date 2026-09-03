using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;

class ArduinoToWasd
{
    private static SerialPort _serialPort;

    [STAThread]
    static void Main(string[] args)
    {
        Console.WriteLine("=== ARDUINO JOYSTICK TO KEYBOARD ===");
        Console.WriteLine("Target Port: COM5"); // Change this if your Arduino is on COM4 or another port!

        _serialPort = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);

        try
        {
            _serialPort.Open();
            Console.WriteLine("Successfully connected!");
            Console.WriteLine("-> Click inside a Notepad file or game window to test.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nCONNECTION ERROR: " + ex.Message);
            Console.WriteLine("1. Double check that your Arduino is plugged in.");
            Console.WriteLine("2. Make sure the Serial Monitor in the Arduino IDE is CLOSED!");
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
            return;
        }

        // Continuous reading loop
        while (true)
        {
            try
            {
                if (_serialPort.IsOpen && _serialPort.BytesToRead > 0)
                {
                    string data = _serialPort.ReadLine().Trim();

                    Console.WriteLine("Joystick moved: " + data);

                    if (data == "UP")    { SendKeys.SendWait("w"); }
                    if (data == "DOWN")  { SendKeys.SendWait("s"); }
                    if (data == "LEFT")  { SendKeys.SendWait("a"); }
                    if (data == "RIGHT") { SendKeys.SendWait("d"); }
                    if (data == "RUp")   { SendKeys.SendWait("q"); }
                    if (data == "RDown") { SendKeys.SendWait("e"); }
                    if (data == "BTN") { SendKeys.SendWait("z"); }
                }
            }
            catch (TimeoutException) { }
            catch (Exception ex)
            {
                Console.WriteLine("Loop Error: " + ex.Message);
                break;
            }

            Thread.Sleep(10); // Keeps CPU usage low
        }

        Console.WriteLine("Program ended. Press Enter to close.");
        Console.ReadLine();
    }
}