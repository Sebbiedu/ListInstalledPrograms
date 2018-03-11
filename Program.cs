using System;
using System.IO;
using Microsoft.Win32;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string regKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey uninstallKey = Registry.LocalMachine.OpenSubKey(regKey))
            {
                try
                {
                    StreamWriter sw = new StreamWriter("C:\\registry_64.csv");
                    if (uninstallKey != null)
                    {
                        string[] productKeys = uninstallKey.GetSubKeyNames();
                        foreach (var keyName in productKeys)
                        {
                            string[] valueNames = uninstallKey.OpenSubKey(keyName).GetValueNames();

                            string displayName = "noValue", displayVersion = "noValue", installLocation = "noValue";

                            foreach (var valueName in valueNames )
                            {
                                switch (valueName)
                                {
                                    case "DisplayName":
                                        displayName = uninstallKey.OpenSubKey(keyName).GetValue(valueName).ToString();
                                        break;
                                    case "DisplayVersion":
                                        displayVersion = uninstallKey.OpenSubKey(keyName).GetValue(valueName).ToString();
                                        break;
                                    case "InstallLocation":
                                        installLocation = uninstallKey.OpenSubKey(keyName).GetValue(valueName).ToString();
                                        break;
                                }
                                
                            }
                            sw.WriteLine(String.Format("{0};{1};{2}", displayName, displayVersion, installLocation));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Successfully Finished");
                }
            }

            regKey = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey uninstallKey = Registry.LocalMachine.OpenSubKey(regKey))
            {
                try
                {
                    StreamWriter sw = new StreamWriter("C:\\registry_32.csv");
                    if (uninstallKey != null)
                    {
                        string[] productKeys = uninstallKey.GetSubKeyNames();
                        foreach (var keyName in productKeys)
                        {
                            string[] valueNames = uninstallKey.OpenSubKey(keyName).GetValueNames();

                            string displayName = "noValue", displayVersion = "noValue", installLocation = "noValue";

                            foreach (var valueName in valueNames)
                            {
                                switch (valueName)
                                {
                                    case "DisplayName":
                                        displayName = uninstallKey.OpenSubKey(keyName).GetValue(valueName).ToString();
                                        break;
                                    case "DisplayVersion":
                                        displayVersion = uninstallKey.OpenSubKey(keyName).GetValue(valueName).ToString();
                                        break;
                                    case "InstallLocation":
                                        installLocation = uninstallKey.OpenSubKey(keyName).GetValue(valueName).ToString();
                                        break;
                                }

                            }
                            sw.WriteLine(String.Format("{0};{1};{2}", displayName, displayVersion, installLocation));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Successfully Finished");
                }
            }

        }
    }
}
