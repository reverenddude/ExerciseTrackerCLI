namespace ExerciseTrackerUI.Models;

public class Exercise
{
    public int ExerciseId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public TimeSpan Duration { get; set; }
    public string? Comments { get; set; }
}

