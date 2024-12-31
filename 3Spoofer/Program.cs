using _3Spoofer;
using System.Diagnostics;
using System.Reflection;

namespace _3Spoofer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "3SPOOFER - Made By yk3thn";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("This application may need administrator permissions to work properly.");
            Thread.Sleep(2000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" _______  _______  _______  _______  _______  _______  _______  ______   \r\n|       ||       ||       ||       ||       ||       ||       ||    _ |  \r\n|___    ||  _____||    _  ||   _   ||   _   ||    ___||    ___||   | ||  \r\n ___|   || |_____ |   |_| ||  | |  ||  | |  ||   |___ |   |___ |   |_||_ \r\n|___    ||_____  ||    ___||  |_|  ||  |_|  ||    ___||    ___||    __  |\r\n ___|   | _____| ||   |    |       ||       ||   |    |   |___ |   |  | |\r\n|_______||_______||___|    |_______||_______||___|    |_______||___|  |_|");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Select an option:");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Display System Data");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Spoof VolumeID");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("3");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Clean Epic Games Traces");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("4");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Spoof InstallationID");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("5");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Spoof PC Name");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("6");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Spoof Disks");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("7");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Spoof Guids");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("8");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Clean Ubisoft Cache");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("9");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Clean Valorant Cache");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("10");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Spoof MAC");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("11");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Spoof GPU");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("12");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Spoof EFI Variable ID");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("13");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Spoof SMBIOS Serial Number");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("14");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Clean Steam Cache");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("15");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Clean Network Cache");
            Console.WriteLine("");
            Console.Write("Option: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string option = Console.ReadLine();
            if (option == "1")
            {
                Console.Clear();
                Title(); Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Tools.DisplaySystemData();
                
            }
            else if (option == "2")
            {
                Console.Clear();
                Title(); Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Tools.SpoofVolumeID();
            }
            else if (option == "3")
            {
                Console.Clear();
                Title(); Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear(); Tools.CleanTraces();
            }
            else if (option == "4")
            {
                Console.Clear();
                Title(); Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear(); Tools.SpoofInstallationID();
            }
            else if (option == "5")
            {
                Console.Clear();
                Title(); Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear(); Tools.SpoofPCName();
            }
            else if (option == "6")
            {
                Console.Clear();
                Title(); Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear(); Tools.SpoofDisks();
            }
            else if (option == "7")
            {
                Console.Clear();
                Title(); Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear(); Tools.SpoofGUIDs();
            }
            else if (option == "8")
            {
                Console.Clear();
                Title(); Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear(); Tools.UbisoftCache();
            }
            else if (option == "9")
            {
                Console.Clear();
                Title(); Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear(); Tools.DeleteValorantCache();
            }
            else if (option == "10")
            {
                Console.Clear();
                Title(); Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear(); Tools.SpoofMAC();
            }
            else if (option == "11")
            {
                Console.Clear();
                Title(); Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear(); Tools.SpoofGPU();
            }
            else if (option == "12")
            {
                Console.Clear();
                Title(); Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear(); Tools.SpoofEFIVariableId();
            }
            else if (option == "13")
            {
                Console.Clear();
                Title(); Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear(); Tools.SpoofSMBIOSSerialNumber();
            }
            else if (option == "14")
            {
                Console.Clear();
                Title(); Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear(); Tools.ClearSteamCache();
            }
            else if (option == "15")
            {
                Console.Clear();
                Title(); Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear(); Tools.ClearNetworkCache();
            }
            Console.ReadKey();
            Process.Start(Environment.CurrentDirectory + "/3Spoofer.exe");
        }

        static void Title()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" _______  _______  _______  _______  _______  _______  _______  ______   \r\n|       ||       ||       ||       ||       ||       ||       ||    _ |  \r\n|___    ||  _____||    _  ||   _   ||   _   ||    ___||    ___||   | ||  \r\n ___|   || |_____ |   |_| ||  | |  ||  | |  ||   |___ |   |___ |   |_||_ \r\n|___    ||_____  ||    ___||  |_|  ||  |_|  ||    ___||    ___||    __  |\r\n ___|   | _____| ||   |    |       ||       ||   |    |   |___ |   |  | |\r\n|_______||_______||___|    |_______||_______||___|    |_______||___|  |_|");
            Console.WriteLine("");
        }
    }
}
