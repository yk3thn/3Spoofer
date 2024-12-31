using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using _3Spoofer;
using Microsoft.Win32;

namespace _3Spoofer
{
    internal class Tools
    {
        public static void CheckVolumeID()
        {
            string mainDrive = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 3);
            string volumeIdPath = Path.Combine(mainDrive, "VolumeId.exe");

            if (!File.Exists(volumeIdPath))
            {
                DownloadAndExtractVolumeId(mainDrive);
                DriveInfo[] drives = DriveInfo.GetDrives();

                for (int ctr = 0; ctr < drives.Length; ctr++)
                {

                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();

                    process.StandardInput.WriteLine("cd C:/");
                    process.StandardInput.Flush();
                    process.StandardInput.WriteLine("start Volumeid.exe");
                    process.StandardInput.Flush();



                    process.StandardInput.WriteLine("vol id " + mainDrive.Substring(0, 2));
                    process.StandardInput.Flush();


                    process.StandardInput.Close();
                    Console.WriteLine(process.StandardOutput.ReadToEnd());
                    process.WaitForExit();
                }
            }
            else
            {
                DriveInfo[] drives = DriveInfo.GetDrives();

                for (int ctr = 0; ctr < drives.Length; ctr++)
                {

                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    //process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.Start();

                    process.StandardInput.WriteLine("cd C:/");
                    process.StandardInput.Flush();
                    process.StandardInput.WriteLine("start Volumeid.exe");
                    process.StandardInput.Flush();



                    process.StandardInput.WriteLine("vol id " + mainDrive.Substring(0, 2));
                    process.StandardInput.Flush();


                    process.StandardInput.Close();
                    Console.WriteLine(process.StandardOutput.ReadToEnd());
                    process.WaitForExit();
                }
            }
        }
        public static void SpoofVolumeID()
        {
            string mainDrive = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 3);
            string volumeIdPath = Path.Combine(mainDrive, "VolumeId.exe");

            if (!File.Exists(volumeIdPath))
            {
                DownloadAndExtractVolumeId(mainDrive);
            }
            else
            {
                DriveInfo[] drives = DriveInfo.GetDrives();

                for (int ctr = 0; ctr < drives.Length; ctr++)
                {

                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.Start();

                    process.StandardInput.WriteLine("cd C:/");
                    process.StandardInput.Flush();
                    process.StandardInput.WriteLine("start Volumeid.exe");
                    process.StandardInput.Flush();


                    process.StandardInput.WriteLine("volumeid " + drives[ctr].Name.Substring(0, 2) + " " + randomString(4) + "-" + randomString(4));
                    process.StandardInput.Flush();


                    process.StandardInput.Close();
                    Console.WriteLine(process.StandardOutput.ReadToEnd());
                    process.WaitForExit();
                }
            }
        }

        private static Random random = new Random();
        public static string randomString(int length)
        {
            const string chars = "ABCDEF0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        static void DownloadAndExtractVolumeId(string mainDrive)
        {
            string downloadUrl = "https://download.sysinternals.com/files/VolumeId.zip";
            string zipFilePath = Path.Combine(mainDrive, "VolumeId.zip");

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(downloadUrl, zipFilePath);
                }

                ZipFile.ExtractToDirectory(zipFilePath, mainDrive);

                // Clean up: Delete the zip file after extraction
                File.Delete(zipFilePath);
            }
            catch (WebException webEx)
            {
                Console.WriteLine($"WebException: {webEx.Message}");
                if (webEx.Response != null)
                {
                    using (var reader = new System.IO.StreamReader(webEx.Response.GetResponseStream()))
                    {
                        string responseText = reader.ReadToEnd();
                        Console.WriteLine("Response: " + responseText);
                    }
                }
            }
            catch (UnauthorizedAccessException unAuthEx)
            {
                Console.WriteLine($"UnauthorizedAccessException: {unAuthEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during download or extraction: {ex.Message}");
            }
        }

        private static string SIDCleaner = WindowsIdentity.GetCurrent().User.Value;
        public static void CleanTraces()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.StandardInput.WriteLine("taskkill /f /im UnrealCEFSubProcess.exe");
            process.StandardInput.WriteLine("taskkill /f /im CEFProcess.exe");
            process.StandardInput.WriteLine("taskkill /f /im EasyAntiCheat.exe");
            process.StandardInput.WriteLine("taskkill /f /im BEService.exe");
            process.StandardInput.WriteLine("taskkill /f /im BEServices.exe");
            process.StandardInput.WriteLine("taskkill /f /im BattleEye.exe");
            process.StandardInput.WriteLine("taskkill /f /im epicgameslauncher.exe");
            process.StandardInput.WriteLine("taskkill /f /im FortniteClient-Win64-Shipping_EAC.exe");
            process.StandardInput.WriteLine("taskkill /f /im FortniteClient-Win64-Shipping.exe");
            process.StandardInput.WriteLine("taskkill /f /im FortniteClient-Win64-Shipping_BE.exe");
            process.StandardInput.WriteLine("taskkill /f /im FortniteLauncher.exe");
            process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\Software\\Epic Games\" /f");
            process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Epic Games\" /f");
            process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\Software\\Epic Games\" /f");
            process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\com.epicgames.launcher\" /f");
            process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\EpicGames\" /f");
            process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Epic Games\" /f");
            process.StandardInput.WriteLine("reg delete \"HKEY_CLASSES_ROOT\\com.epicgames.launcher\" /f");
            process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\Software\\Epic Games\" /f");
            process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Classes\\com.epicgames.launcher\" /f");
            process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Epic Games\\Unreal Engine\\Hardware Survey\" /f");
            process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Epic Games\\Unreal Engine\\Identifiers\" /f");
            process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\com.epicgames.launcher\" /f");
            process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\EpicGames\" /f");
            process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\SOFTWARE\\EpicGames\" /f");
            process.StandardInput.WriteLine("reg delete \"HKEY_USERS\\" + SIDCleaner + "\\Software\\Epic Games\" /f");
            process.StandardInput.WriteLine("exit");
        }

        public static void SpoofInstallationID()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true))
            {
                if (key != null)
                {
                    string newInstallationID = Guid.NewGuid().ToString();
                    key.SetValue("InstallationID", newInstallationID);
                    key.Close();
                }
            }
        }

        public static void SpoofPCName()
        {
            string randomName = RandomId(8); // Generate a random PC name
            using RegistryKey computerName = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName", true);
            computerName.SetValue("ComputerName", randomName);
            computerName.SetValue("ActiveComputerName", randomName);
            computerName.SetValue("ComputerNamePhysicalDnsDomain", "");

            using RegistryKey activeComputerName = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName", true);
            activeComputerName.SetValue("ComputerName", randomName);
            activeComputerName.SetValue("ActiveComputerName", randomName);
            activeComputerName.SetValue("ComputerNamePhysicalDnsDomain", "");

            using RegistryKey tcpipParams = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", true);
            tcpipParams.SetValue("Hostname", randomName);
            tcpipParams.SetValue("NV Hostname", randomName);

            using RegistryKey tcpipInterfaces = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\\Interfaces", true);
            foreach (string interfaceKey in tcpipInterfaces.GetSubKeyNames())
            {
                using RegistryKey interfaceSubKey = tcpipInterfaces.OpenSubKey(interfaceKey, true);
                interfaceSubKey.SetValue("Hostname", randomName);
                interfaceSubKey.SetValue("NV Hostname", randomName);
            }
        }
        public static string RandomId(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string result = "";
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result += chars[random.Next(chars.Length)];
            }

            return result;
        }

        public static void SpoofDisks()
        {
            using RegistryKey ScsiPorts = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\Scsi");
            foreach (string port in ScsiPorts.GetSubKeyNames())
            {
                using RegistryKey ScsiBuses = Registry.LocalMachine.OpenSubKey($"HARDWARE\\DEVICEMAP\\Scsi\\{port}");
                foreach (string bus in ScsiBuses.GetSubKeyNames())
                {
                    using RegistryKey ScsuiBus = Registry.LocalMachine.OpenSubKey($"HARDWARE\\DEVICEMAP\\Scsi\\{port}\\{bus}\\Target Id 0\\Logical Unit Id 0", true);
                    if (ScsuiBus != null)
                    {
                        if (ScsuiBus.GetValue("DeviceType").ToString() == "DiskPeripheral")
                        {
                            string identifier = RandomId(14);
                            string serialNumber = RandomId(14);

                            ScsuiBus.SetValue("DeviceIdentifierPage", Encoding.UTF8.GetBytes(serialNumber));
                            ScsuiBus.SetValue("Identifier", identifier);
                            ScsuiBus.SetValue("InquiryData", Encoding.UTF8.GetBytes(identifier));
                            ScsuiBus.SetValue("SerialNumber", serialNumber);
                        }
                    }
                }
            }

            using RegistryKey DiskPeripherals = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\MultifunctionAdapter\\0\\DiskController\\0\\DiskPeripheral");
            foreach (string disk in DiskPeripherals.GetSubKeyNames())
            {
                using RegistryKey DiskPeripheral = Registry.LocalMachine.OpenSubKey($"HARDWARE\\DESCRIPTION\\System\\MultifunctionAdapter\\0\\DiskController\\0\\DiskPeripheral\\{disk}", true);
                DiskPeripheral.SetValue("Identifier", $"{RandomId(8)}-{RandomId(8)}-A");
            }
        }
        public static void SpoofGUIDs()
        {
            using RegistryKey HardwareGUID = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", true);
            HardwareGUID.SetValue("HwProfileGuid", $"{{{Guid.NewGuid()}}}");

            using RegistryKey MachineGUID = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", true);
            MachineGUID.SetValue("MachineGuid", Guid.NewGuid().ToString());

            using RegistryKey MachineId = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\SQMClient", true);
            MachineId.SetValue("MachineId", $"{{{Guid.NewGuid()}}}");

            using RegistryKey SystemInfo = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", true);

            Random rnd = new Random();
            int day = rnd.Next(1, 31);
            string dayStr = "";
            if (day < 10) dayStr = $"0{day}";
            else dayStr = day.ToString();

            int month = rnd.Next(1, 13);
            string monthStr = "";
            if (month < 10) monthStr = $"0{month}";
            else monthStr = month.ToString();

            SystemInfo.SetValue("BIOSReleaseDate", $"{dayStr}/{monthStr}/{rnd.Next(2000, 2023)}");
            SystemInfo.SetValue("BIOSVersion", RandomId(10));
            SystemInfo.SetValue("ComputerHardwareId", $"{{{Guid.NewGuid()}}}");
            SystemInfo.SetValue("ComputerHardwareIds", $"{{{Guid.NewGuid()}}}\n{{{Guid.NewGuid()}}}\n{{{Guid.NewGuid()}}}\n");
            SystemInfo.SetValue("SystemManufacturer", RandomId(15));
            SystemInfo.SetValue("SystemProductName", RandomId(6));

            using RegistryKey Update = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate", true);
            Update.SetValue("SusClientId", Guid.NewGuid().ToString());
            Update.SetValue("SusClientIdValidation", Encoding.UTF8.GetBytes(RandomId(25)));
        }

        public static void UbisoftCache()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string ubisoftPath = Path.Combine("Ubisoft Game Launcher", "cache");
            string ubisoftLogsPath = Path.Combine("Ubisoft Game Launcher", "logs");
            string ubisoftSavegamesPath = Path.Combine("Ubisoft Game Launcher", "savegames");
            string ubisoftSpoolPath = Path.Combine("Ubisoft Game Launcher", "spool");

            DirectoryInfo di = new DirectoryInfo(Path.Combine("C:", "Program Files (x86)", "Ubisoft", ubisoftPath));
            DirectoryInfo di2 = new DirectoryInfo(Path.Combine("C:", "Program Files (x86)", "Ubisoft", ubisoftLogsPath));
            DirectoryInfo di3 = new DirectoryInfo(Path.Combine("C:", "Program Files (x86)", "Ubisoft", ubisoftSavegamesPath));
            DirectoryInfo di4 = new DirectoryInfo(Path.Combine(appDataPath, "Ubisoft Game Launcher", ubisoftSpoolPath));

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
            foreach (FileInfo file in di2.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di2.GetDirectories())
            {
                dir.Delete(true);
            }
            foreach (FileInfo file in di3.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di3.GetDirectories())
            {
                dir.Delete(true);
            }
            foreach (FileInfo file in di4.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di4.GetDirectories())
            {
                dir.Delete(true);
            }
        }
        public static void DeleteValorantCache()
        {
            string valorantPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\VALORANT\\saved";

            if (Directory.Exists(valorantPath))
            {
                DirectoryInfo di = new DirectoryInfo(valorantPath);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
        }

        public static bool SpoofMAC()

        {
            bool err = false;

            using RegistryKey NetworkAdapters = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e972-e325-11ce-bfc1-08002be10318}");
            foreach (string adapter in NetworkAdapters.GetSubKeyNames())
            {
                if (adapter != "Properties")
                {
                    try
                    {
                        using RegistryKey NetworkAdapter = Registry.LocalMachine.OpenSubKey($"SYSTEM\\CurrentControlSet\\Control\\Class\\{{4d36e972-e325-11ce-bfc1-08002be10318}}\\{adapter}", true);
                        if (NetworkAdapter.GetValue("BusType") != null)
                        {
                            NetworkAdapter.SetValue("NetworkAddress", RandomMac());
                            string adapterId = NetworkAdapter.GetValue("NetCfgInstanceId").ToString();
                            Enable_LocalAreaConection(adapterId, false);
                            Enable_LocalAreaConection(adapterId, true);

                        }
                    }
                    catch (System.Security.SecurityException ex)
                    {
                        Console.WriteLine("\n[X] Start the spoofer in admin mode to spoof your MAC address!");
                        err = true;
                        break;
                    }
                }
            }

            return err;
        }
        public static string RandomMac()
        {
            string chars = "ABCDEF0123456789";
            string windows = "26AE";
            string result = "";
            Random random = new Random();

            result += chars[random.Next(chars.Length)];
            result += windows[random.Next(windows.Length)];

            for (int i = 0; i < 5; i++)
            {
                result += "-";
                result += chars[random.Next(chars.Length)];
                result += chars[random.Next(chars.Length)];

            }

            return result;
        }
        public static void Enable_LocalAreaConection(string adapterId, bool enable = true)
        {
            string interfaceName = "Ethernet";
            foreach (NetworkInterface i in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (i.Id == adapterId)
                {
                    interfaceName = i.Name;
                    break;
                }
            }

            string control;
            if (enable)
                control = "enable";
            else
                control = "disable";

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("netsh", $"interface set interface \"{interfaceName}\" {control}");
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();
            p.WaitForExit();
        }

        public static void ClearSteamCache()
        {
            string steamPath = GetSteamPath();
            if (!string.IsNullOrEmpty(steamPath))
            {
                string cachePath = Path.Combine(steamPath, "appcache");
                if (Directory.Exists(cachePath))
                {
                    try
                    {
                        Directory.Delete(cachePath, true);
                        Directory.CreateDirectory(cachePath);
                        Console.WriteLine("Steam cache cleared successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error clearing Steam cache: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Steam cache folder not found.");
                }
            }
            else
            {
                Console.WriteLine("Steam installation path not found.");
            }
        }

        public static void ClearNetworkCache()
        {
            try
            {
                // Clear DNS Cache
                ExecuteCommand("ipconfig /flushdns", "Flushed DNS resolver cache.");

                // Clear ARP Cache
                ExecuteCommand("arp -d *", "Cleared ARP cache.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing network cache: {ex.Message}");
            }
        }

        static void ExecuteCommand(string command, string successMessage)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/c {command}";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    Console.WriteLine(successMessage);
                    Console.WriteLine(output);
                }
                else
                {
                    throw new Exception(error);
                }
            }
        }

        static string GetSteamPath()
        {
            const string steamRegistryKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam";
            const string installPathValue = "InstallPath";

            return Registry.GetValue(steamRegistryKey, installPathValue, null) as string;
        }

        public static void SpoofSMBIOSSerialNumber()
        {
            try
            {
                RegistryKey smbiosData = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\BIOS", true);

                if (smbiosData != null)
                {
                    string serialNumber = RandomId(10);
                    smbiosData.SetValue("SystemSerialNumber", serialNumber);
                    smbiosData.Close();
                }
                else
                {
                    Console.WriteLine("\n[X] Cant find the SMBIOS");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n[X] Start the spoofer with administrator");
            }
        }

        public static void SpoofGPU()
        {
            string keyName = @"SYSTEM\CurrentControlSet\Enum\PCI\VEN_10DE&DEV_0DE1&SUBSYS_37621462&REV_A1";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, true))
            {
                if (key != null)
                {
                    string newHardwareID = "PCIVEN_8086&DEV_1234&SUBSYS_5678ABCD&REV_01";
                    string oldHardwareID = key.GetValue("HardwareID") as string;

                    key.SetValue("HardwareID", newHardwareID);
                    key.SetValue("CompatibleIDs", new string[] { newHardwareID });
                    key.SetValue("Driver", "pci.sys");
                    key.SetValue("ConfigFlags", 0x00000000, RegistryValueKind.DWord);
                    key.SetValue("ClassGUID", "{4d36e968-e325-11ce-bfc1-08002be10318}");
                    key.SetValue("Class", "Display");

                    key.Close();
                }
            }
        }
        public static void SpoofEFIVariableId()
        {
            try
            {
                RegistryKey efiVariables = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Nsi\\{eb004a03-9b1a-11d4-9123-0050047759bc}\\26", true);
                if (efiVariables != null)
                {
                    string efiVariableId = Guid.NewGuid().ToString();
                    efiVariables.SetValue("VariableId", efiVariableId);
                    efiVariables.Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n[X] Start the spoofer in admin mode to spoof your MAC address!");
            }
        }

        public static void DisplaySystemData()
        {
            Console.WriteLine("System Data:");
            Console.WriteLine("------------------------------------------------");

            try
            {
                // Display HWID
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true))
                {
                    string installationID = key.GetValue("InstallationID") as string;
                    Console.WriteLine("HWID:              " + installationID);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving HWID: " + ex.Message);
            }

            try
            {
                // Display GUIDs
                using (RegistryKey machineGuidKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography"))
                {
                    string machineGuid = machineGuidKey.GetValue("MachineGuid") as string;
                    Console.WriteLine("Machine GUID:      " + machineGuid);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving Machine GUID: " + ex.Message);
            }

            try
            {
                // Display MAC ID
                foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
                {
                    PhysicalAddress physicalAddress = networkInterface.GetPhysicalAddress();
                    Console.WriteLine("MAC ID (" + networkInterface.Name + "):     " + physicalAddress.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving MAC ID: " + ex.Message);
            }

            try
            {
                // Display Installation ID
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true))
                {
                    string installationID = key.GetValue("InstallationID") as string;
                    Console.WriteLine("Installation ID:    " + installationID);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving Installation ID: " + ex.Message);
            }

            try
            {
                // Display PC Name
                using (RegistryKey computerName = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName"))
                {
                    string pcName = computerName.GetValue("ComputerName") as string;
                    Console.WriteLine("PC Name:           " + pcName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving PC Name: " + ex.Message);
            }

            try
            {
                using (RegistryKey gpuKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\PCI\VEN_10DE&DEV_0DE1&SUBSYS_37621462&REV_A1"))
                {
                    if (gpuKey != null)
                    {
                        object hardwareIDValue = gpuKey.GetValue("HardwareID");

                        if (hardwareIDValue is string hardwareID)
                        {
                            Console.WriteLine("GPU ID: " + hardwareID);
                        }
                        else if (hardwareIDValue is string[] hardwareIDArray)
                        {
                            Console.WriteLine("GPU IDs:");
                            foreach (string id in hardwareIDArray)
                            {
                                Console.WriteLine("  " + id);
                            }
                        }
                        else
                        {
                            Console.WriteLine("HardwareID not found or in unexpected format.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Registry key not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving GPU ID: " + ex.Message);
            }


            try
            {
                // Display CPU Information
                string cpuInfo = string.Empty;
                using (StreamReader reader = new StreamReader(@"C:\proc\cpuinfo"))
                {
                    cpuInfo = reader.ReadToEnd();
                }
                Console.WriteLine("CPU Information:   " + cpuInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving CPU Information: " + ex.Message);
            }

            try
            {
                // Display Memory Information
                using (StreamReader reader = new StreamReader("/proc/meminfo"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine("Memory Information: " + line);
                    }
                }
            }
            catch (Exception ex)

            {
                Console.WriteLine("Error retrieving Memory Information: " + ex.Message);
            }
        }
    }
}
