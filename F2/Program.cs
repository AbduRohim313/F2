// See https://aka.ms/new-console-template for more information


public delegate void DriverChangedHandler();

internal class Program
{
    static List<DriveInfo> programDrivers;

    public static void Main(string[] args)
    {
        DriverChangedHandler Print;
        Print = PrintDrivers;
        PrintDrivers();
        Task.Run(async () =>
        {
            while (true)
            {
                if (programDrivers.Count != GetDrivers().Count)
                    Print.Invoke();
                await Task.Delay(1000);
            }
        });
        Console.ReadKey();
    }

    static List<DriveInfo> GetDrivers() => DriveInfo.GetDrives().ToList();

    static void DbLoader()
    {
        programDrivers = GetDrivers();
    }

    static void PrintDrivers()
    {
        Console.Clear();
        DbLoader();
        var flewkalar = programDrivers.FindAll(x => x.DriveType == DriveType.Removable);
        if (flewkalar.Count == 2)
        {
            var flewka1 = flewkalar[0];
            var flewka2 = flewkalar[1];


            foreach (var flewka in flewkalar)
            {
                Console.WriteLine(flewka);

                Papka1(flewka.ToString(), 0);
            }

            Console.WriteLine("Complate");
        }
    }

    static void Papka1(string path, int son)
    {
        var files = Directory.GetFiles(path);
        var directories = Directory.GetDirectories(path);
        var end = path.Split(@"\");
        var tab = "----";
        Console.WriteLine(end[path.Split(@"\").Length-1]);
        if (directories.Length == 0 & files.Length == 0)
        {
            Console.WriteLine("\tERROR");
            return;
        }
        foreach (var file in files)
        {
            for (int i = 0; i < son; i++)
            {
                Console.Write(tab);
            }
            Console.Write("|----");
            Console.WriteLine(Path.GetFileName(file));
        }

        foreach (var directory in directories)
        {
            if (directory.Contains("System Volume Information")) continue;
            
            for (int i = 0; i < son; i++)
            {
                Console.Write(tab);
            }Console.Write("|----");
            Papka1(directory, son + 1);
        }
    }
    static void Papka(string path)
    {
        var directories = Directory.GetDirectories(path);
        var files = Directory.GetFiles(path);
        if (directories.Length == 0 & files.Length == 0)
        {
            Console.WriteLine("\tbow");
            return;
        } //papka yoq        file yoq 

        if (directories.Length == 0 & files.Length != 0) //papka yoq                file bor
        {
            foreach (var file in files)
            {
                Console.WriteLine($"\t{Path.GetFileName(file)}");
            }
        }

        if (directories.Length != 0 & files.Length == 0) // papka bor               file yoq
        {
            foreach (var directory in directories)
            {
                if (directory.Contains("System Volume Information")) continue;
                Papka(directory);
            }
        }

        if (!string.IsNullOrEmpty(
                files.FirstOrDefault(x => x == @"F:\ARXIV\TUIT\1-kurs\pere_coding\F2.docx".ToString())))
        {
            Console.Beep();
            Thread.Sleep(5000);
        }
            if (directories.Length != 0 & files.Length != 0) // papka bor               file bor
            {
                foreach (var file in files)
                {
                    Console.WriteLine($"\t{Path.GetFileName(file)}");
                }

                foreach (var directory in directories)
                {
                    if (directory.Contains("System Volume Information")) continue;
                    Console.WriteLine(directory);
                    Papka(directory);
                }
            }

        //test commit
    }
}