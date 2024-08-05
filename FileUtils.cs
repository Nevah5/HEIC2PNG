using System.Reflection;

namespace HEIC2PNG;

public class FileUtils
{
    private const string Namespace = "HEIC2PNG";

    public static string ReadLocalEmbeddedResource(string fileName)
    {
        return ReadEmbeddedResource($"{Namespace}.{fileName}");
    }
    
    // ReSharper disable once MemberCanBePrivate.Global
    public static string ReadEmbeddedResource(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null) throw new FileNotFoundException("The embedded resource was not found", resourceName);
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}