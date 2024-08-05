using HEIC2PNG;
using ImageMagick;

if (args.Length == 0 || args[0] == "help")
{
    PrintHelp();
    return;
}

var inputFile = args[0];
var outputFolder = args.Length == 2 ? args[1] : null;


string filePath = Path.Combine(AppContext.BaseDirectory, inputFile);
if (File.Exists(filePath))
{
    ConvertFile(filePath);
} else if (Directory.Exists(filePath))
{
    foreach (var file in Directory.GetFiles(filePath))
    {
        if(!file.EndsWith(".HEIC")) continue;
        ConvertFile(file);
    }
}
else
{
    Console.WriteLine("Error: File or Directory not found. Please check the path or refer to the help page.");
}

return;

void PrintHelp()
{
    Console.WriteLine(FileUtils.ReadLocalEmbeddedResource("help.txt"));
}

void ConvertFile(string inputFilePath)
{
    var outputFilePath = $"{inputFilePath}.png";
    try
    {
        using (MagickImage image = new MagickImage(inputFilePath))
        {
            image.Format = MagickFormat.Png;
            image.Write(outputFilePath);

            Console.WriteLine($"Successfully converted {Path.GetFileName($"{inputFilePath}")} to {Path.GetFileName(outputFilePath)}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}