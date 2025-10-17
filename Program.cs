// See https://aka.ms/new-console-template for more information
class Program
{
    static int Main(string[] args)
    {
        switch (args.Length)
        {
            case 0:
                Console.WriteLine("Användning:");
                Console.WriteLine("  -h, --help       Visa denna hjälptext.");
                Console.WriteLine("  -v, --version    Visa programversion.");
                Console.WriteLine("  <fil1> [fil2 ...]  Visa innehållet i angivna filer.");
                return 0;
                ;
            case 1:
                if (args[0] == "-h" || args[0] == "--help")
                {
                    Console.WriteLine("Visa denna hjälptext.");
                    return 0;
                }
                else if (args[0] == "-v" || args[0] == "--version")
                {
                    Console.WriteLine("Version 1.0.0");
                    return 0;
                }
                else
                {
                    PrintFileContent(args);
                }
                return 0;
            default:
                PrintFileContent(args);
                break;
        }

        static int PrintFileContent(string[] args)
        {
            foreach (string arg in args)
            {
                if (File.Exists(arg))
                {
                    string content = File.ReadAllText(arg);
                    Console.WriteLine($"Content of {arg}:\n{content}");
                }
                else
                {
                    Console.WriteLine($"File not found: {arg}");
                    return 1;
                }
            }

            return 0;
        }
        return 0;
    }
}
