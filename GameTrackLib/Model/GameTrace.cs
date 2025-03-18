namespace GameTrackLib.Model;

public class GameTrace
{
    public int Id { get; set; }
    public string ProcessName { get; set; }
    public string DisplayName { get; set; }
    public TimeSpan Time { get; set; }
}