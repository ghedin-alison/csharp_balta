using Balta.NotificationContext;
using Balta.SharedContext;

namespace Balta.ContentContext;

public class CareerItem: Base
{
    public CareerItem(int order, string title, string description, Course course)
    {
        Order = order;
        Title = title;
        Description = description;
        Course = course;
        if (course == null)
        {
            AddNotification(new Notification("Course", "Curso Inválido!"));
        }
    }
    public int Order { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Course Course { get; set; }
}