namespace MoorCodeSofia.Domain;

public class UserTask
{
    public Guid Id { get; set; }
    public string User { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}