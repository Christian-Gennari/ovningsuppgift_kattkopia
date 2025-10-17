class Program
{
    static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Användning:");
            Console.WriteLine("  -h, --help       Visa denna hjälptext.");
            Console.WriteLine("  -v, --version    Visa programversion.");
            Console.WriteLine("  <fil1> [fil2 ...]  Visa innehållet i angivna filer.");
            return 0;
        }

        switch (args[0])
        {
            case "-h":
            case "--help":
                Console.WriteLine("Visar denna hjälptext.");
                return 0;

            case "-v":
            case "--version":
                Console.WriteLine("Version 1.0.0");
                return 0;
            default:
                PrintFileContent(args);
                break;
        }
        return 0;
    }

    static int PrintFileContent(string[] args)
    {
        var errorFiles = new List<string>();
        foreach (string arg in args)
        {
            if (File.Exists(arg))
            {
                string content = File.ReadAllText(arg);
                Console.WriteLine($"CONTENT OF {arg}:\n{content}");
            }
            else
            {
                errorFiles.Add(arg);
            }
            System.Console.WriteLine("----------------------------------------");
        }
        if (errorFiles.Count > 0)
        {
            Console.WriteLine("Följande filer kunde inte hittas:");
            foreach (var file in errorFiles)
            {
                Console.WriteLine(file);
            }
            return 1;
        }

        return 0;
    }
}
