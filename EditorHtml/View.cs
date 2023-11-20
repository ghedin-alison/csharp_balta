using System.Text.RegularExpressions;

namespace EditorHtml;

public class View
{
    public static void Show(string text)
    {
        Background.SetBackground();
        Console.WriteLine("VIEW MODE");
        Console.WriteLine("---------");
        Replace(text);
        Console.WriteLine("---------");
        Console.ReadKey();
        Menu.Show();
    }

    public static void Replace(string text)
    {
        var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
        var words = text.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (strong.IsMatch(words[i]))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(
                        words[i].Substring(
                            words[i].IndexOf('>') + 1,
                            ((words[i].LastIndexOf('<') - 1) - words[i].IndexOf('>'))
                            )
                    );
                Console.Write(" ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(words[i]);
                Console.Write(" ");
            }
        }
    }
}