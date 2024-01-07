using Balta.ContentContext;
using Balta.ContentContext.Enums;

var articles = new List<Article>();
articles.Add(new Article("Artigo sobre OOP", "orientacao-objetos"));
articles.Add(new Article("Artigo sobre C#", "csharp"));
articles.Add(new Article("Artigo sobre .NET", "dotnet"));

foreach(var article in articles){
    Console.WriteLine("#");
    Console.WriteLine($"Id: {
        article.Id
    }");
    Console.WriteLine($"Title: {
        article.Title
    }");
    Console.WriteLine($"Url: {
        article.Url
    }");
}

var courseOOP = new Course("Fundamentos OOP", "fundamentos-oop");
var courseCsharp = new Course("Fundamentos Csharp", "fundamentos-csharp");
var courseAspnet = new Course("Fundamentos ASPNet", "fundamentos-aspnet");


var courses = new List<Course>();
courses.Add(courseOOP);
courses.Add(courseCsharp);
courses.Add(courseAspnet);

foreach (var course in courses)
{
    Console.WriteLine(course.Title);
}

var careerDotnet = new Career("Iniciante .NET", "iniciante-dotnet");



var careers = new List<Career>();
var careerItem2 = new CareerItem(2, "Aprenda .NET", "descrição qualquer", null);
var careerItem = new CareerItem(1, "Comece por aqui", "", courseCsharp);
var careerItem3 = new CareerItem(3, "Aprenda AspNet", "Introdução ao AspNet", courseAspnet);
careerDotnet.Items.Add(careerItem2);
careerDotnet.Items.Add(careerItem);
careerDotnet.Items.Add(careerItem3);
careers.Add(careerDotnet);

foreach (var career in careers)
{       
    Console.WriteLine($"Carrer title:{career.Title}");
    foreach (var item in career.Items.OrderByDescending(x => x.Order))
    {
        Console.WriteLine($"{item.Order} - {
            item.Title
        }");
        Console.WriteLine(item.Course?.Title);
        Console.WriteLine(item.Course?.Level);
        foreach (var notification in item.Notifications)
        {
            Console.WriteLine($"{notification.Property} - {notification.Message}");
        }
    }
}
