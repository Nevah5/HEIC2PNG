using HEIC2PNG;

if (args.Length == 0 || args[0] == "help")
{
    Console.WriteLine(FileUtils.ReadLocalEmbeddedResource("help.txt"));
}