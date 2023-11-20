using System.Globalization;

Console.Clear();

//Moedas a primeira opção é decimal
decimal valor = 10.25689m;
Console.WriteLine(valor);

// var culture = CultureInfo.CreateSpecificCulture("en-US");
// var culture = CultureInfo.CreateSpecificCulture("es-ES");
var culture = CultureInfo.CreateSpecificCulture("pt-BR");
Console.WriteLine(valor.ToString(CultureInfo.CreateSpecificCulture("pt-BR")));
Console.WriteLine(valor.ToString("C", culture));

decimal perc = 0.152m;

Console.WriteLine(perc.ToString("P1", culture));

Console.WriteLine(Math.Round(valor).ToString("C", culture));
Console.WriteLine(Math.Floor(valor).ToString("C", culture));
Console.WriteLine(Math.Ceiling(valor).ToString("C", culture));
