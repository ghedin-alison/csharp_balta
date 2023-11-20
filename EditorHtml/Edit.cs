using System.Text;

namespace EditorHtml;

public class Edit
{
    public static void Show()
    {
        Background.SetBackground();
        Console.WriteLine("EDIT MODE");
        Console.WriteLine("---------");
        Start();
    }

    public static void Start()
    {
        var file = new StringBuilder();

        do
        {
            file.Append(Console.ReadLine());
            file.Append(Environment.NewLine);
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
        
        Console.WriteLine("-----------------------");
        Console.WriteLine(" Deseja Salvar o arquivo? (Y/N): ");
        char save = char.Parse(Console.ReadLine().ToUpper());
        Console.WriteLine(save);
        View.Show(file.ToString());
        
    }
}