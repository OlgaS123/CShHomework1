using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleTaskManager
{
    public class TaskManager
    {
        private IOrderedEnumerable<Process> GetAllProcesses()
        {
            return from p in Process.GetProcesses()
                        orderby p.ProcessName
                        select p;
        }
        private Process? GetProcessById()
        {
            Console.Write(" Enter PID: ");
            string? input = Console.ReadLine();
            try
            {
                int pid = int.Parse(input);
                return Process.GetProcessById(pid);
            }
            catch (Exception ex)
            {
                ShowEx(ex.Message);
            }
            return null;
        }

        private void PrintProcesses(IOrderedEnumerable<Process> processes)
        {
            Console.WriteLine("\n PID        | ProcessName\n------------+-----------------------------------------");
            foreach (var process in processes)
            {
                Console.WriteLine($" {process.Id,-10} | {process.ProcessName}");
            }
        }
        private void PrintProcesses(Process process)
        {
            Console.WriteLine("\n PID        | ProcessName\n------------+-----------------------------------------");
            Console.WriteLine($" {process.Id,-10} | {process.ProcessName}");
        }

        public void ShowAllProcesses()
        {
            IOrderedEnumerable<Process> processes = GetAllProcesses();
            PrintProcesses(processes);
        }

        public void ShowProcessById()
        {
            Process? process = GetProcessById();
            if (process != null) PrintProcesses(process);
        }

        public void ShowThreads()
        {
            Process? process = GetProcessById();
            if (process != null)
            {
                try
                {
                    Console.WriteLine("\n PID        | StartTime           | Priority \n------------+---------------------+-----------------------------");
                    foreach (ProcessThread thread in process.Threads)
                    {
                        Console.WriteLine($" {thread.Id,-10} | {thread.StartTime, -10} | {thread.PriorityLevel}");
                    }
                }
                catch (Exception ex)
                {
                    ShowEx(ex.Message);
                }
            }
        }

        public void ShowModules()
        {
            Process? process = GetProcessById();
            if (process != null)
            {
                try
                {
                    Console.WriteLine("\n Modules \n--------------------------------------------------------------");
                    foreach (ProcessModule module in process.Modules)
                    {
                        Console.WriteLine($" {module.ModuleName}");
                    }
                }
                catch (Exception ex)
                {
                    ShowEx(ex.Message);
                }
            }
        }

        public void StartProcess()
        {
            Console.Write("\n This option will open chrome.exe\n Paste URL to open: ");
            string? input = Console.ReadLine();
            Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", input);
        }

        public void KillProcess()
        {
            Process? process = GetProcessById();
            if (process != null)
            {
                try
                {
                    process.Kill();
                }
                catch (Exception ex)
                {
                    ShowEx(ex.Message);
                }
            }
        }


        private void ShowEx(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
