namespace BootstrapLab.Models;

public enum Gender { Female, Male }

public class Pet
{
    public string Name { get; set; } = String.Empty;
    public string? Type { get; set; }
    public Gender Gender { get; set; }
    public bool IsNeutered { get; set; }
}
