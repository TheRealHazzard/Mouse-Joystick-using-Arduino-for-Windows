using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
namespace Serial_Mouse_Thumbstick
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Developed by Firman Jamal";
            SerialPort port = new SerialPort();
            port.PortName = "COM6";
            port.BaudRate = 9600;
            port.Open();
            int x, y, button;
            do
            {
                string message = port.ReadLine();
                string[] newData = message.Split(',');
                //Console.WriteLine(newData[2]);
                //Console.WriteLine("X COORDINATE : " + newData[0] + " Y COORDINATE : " +newData[1]+" BUTTON : " +newData[2]);
                x = Convert.ToInt32(newData[0]);
                y = Convert.ToInt32(newData[1]);
                
                button = Convert.ToInt32(newData[2]);
                if (button == 1)               {
                    mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
                }
                else
                {
                    mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                }
                Cursor.Position = new System.Drawing.Point(x, y);
                Console.WriteLine("X: " + Cursor.Position.X + " Y: " + Cursor.Position.Y + " Button : " + button);
                
            } while (true);
        }
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
            private const int MOUSEEVENTF_LEFTDOWN = 0x02;
            private const int MOUSEEVENTF_LEFTUP = 0x04;
            private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
            private const int MOUSEEVENTF_RIGHTUP = 0x10;
    }
}