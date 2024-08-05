using HEIC2PNG;

if (args.Length == 0 || args[1] == "help")
{
    Console.WriteLine(FileUtils.ReadLocalEmbeddedResource("banner.txt"));
}