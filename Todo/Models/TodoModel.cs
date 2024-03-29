namespace Todo.Models;

public class TodoModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Done { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime FinishedAt { get; set; }
}