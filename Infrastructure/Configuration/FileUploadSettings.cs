namespace stack_overflow.Infrastructure.Configuration;

public class FileUploadSettings
{
    public string UploadPath { get; set; } =  string.Empty;
    public int MaxFileSizeMB { get; set; } = 10;
    public string[] AllowedExtensions { get; set; } =  Array.Empty<string>();
}