using ConsoleTaskManager;

var tm = new TaskManager();

while (true)
{
    Console.WriteLine("\n 1 - All processes");
    Console.WriteLine(" 2 - Process by id");
    Console.WriteLine(" 3 - Threads info");
    Console.WriteLine(" 4 - Modules info");
    Console.WriteLine(" 5 - Start process");
    Console.WriteLine(" 6 - Kill process");
    Console.WriteLine(" 0 - Exit");

    Console.Write("\n >>> ");
    string? input = Console.ReadLine();

    switch (input)
    {
        case "1":
            tm.ShowAllProcesses();
            break;
        case "2":
            tm.ShowProcessById();
            break;
        case "3":
            tm.ShowThreads();
            break;
        case "4":
            tm.ShowModules();
            break;
        case "5":
            tm.StartProcess();
            break;
        case "6":
            tm.ShowAllProcesses();
            break;
        case "0":
            Environment.Exit(0);
            break;
    }

    Console.Write("\n Press any key to continue");
    Console.ReadKey();
    Console.Clear();
}