using System.Globalization;

Console.Clear();
var data = new DateTime();

Console.WriteLine(data);

var dataAtual = DateTime.Now;

Console.WriteLine(dataAtual);

var dataCriada = new DateTime(2023, 12, 21);

Console.WriteLine(dataCriada);
Console.WriteLine(dataCriada.Year);
Console.WriteLine(dataCriada.Month);
Console.WriteLine(dataCriada.Day);
Console.WriteLine(dataCriada.DayOfWeek);
//Como day of the week é um enum, para retornar o valor, basta fazer o cast para int
Console.WriteLine((int)dataCriada.DayOfWeek);
Console.WriteLine(dataCriada.DayOfYear);


//Segunda parte
Console.Clear();

var dataf = DateTime.Now;

// 
var formatada  = String.Format("{0:dd/MM/yyyy hh:mm}", dataf);
Console.WriteLine(formatada);

//Quando precisar trabalhar com data no mongodb
var formMongo  = String.Format("{0:s}", dataf);
Console.WriteLine(formMongo);

//Terceira parte
//Calculo com Datas
Console.Clear();
var dataPadrao = DateTime.Now;

Console.WriteLine(dataPadrao.AddDays(12));
Console.WriteLine(dataPadrao.AddMonths(2));
Console.WriteLine(dataPadrao.AddYears(5));
Console.WriteLine(dataPadrao.AddHours(9));

//Quarta parte
//Comparando Datas
Console.Clear();
var dataInicial = DateTime.Now;
var dataFinal = DateTime.Now.AddMonths(1);

if(dataFinal >= dataInicial)
    Console.WriteLine("A data final é maior que a data inicial");

//Quinta parte
//Globalização
Console.Clear();

var pt = new CultureInfo("pt-BR");
var en = new CultureInfo("en-UK");
var de = new CultureInfo("de-DE");
var atual = CultureInfo.CurrentCulture;

Console.WriteLine(DateTime.Now.ToString("d", pt));
Console.WriteLine(DateTime.Now.ToString("D", pt));
Console.WriteLine(DateTime.Now.ToString("D", de));
Console.WriteLine(DateTime.Now.ToString("D", atual));


//Sexta parte
//Timezone
Console.Clear();

var utcDate = DateTime.UtcNow;
Console.WriteLine($"Hora global: {utcDate}");

Console.WriteLine($"Hora local: {
    utcDate.ToLocalTime()
}");

var timezoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");
Console.WriteLine(timezoneAustralia);

var hourAustralia = TimeZoneInfo.ConvertTimeFromUtc(utcDate, timezoneAustralia);
Console.WriteLine(hourAustralia);

var timezones = TimeZoneInfo.GetSystemTimeZones();

int countTimezones = 0;

foreach (var timezone in timezones)
{
    Console.WriteLine(timezone.Id);
    Console.WriteLine(timezone);
    Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(utcDate, timezone));
    countTimezones++;
    Console.WriteLine("-----------------");
}

Console.WriteLine($"Total de timezones: {
    countTimezones
}");

//Setima parte
//TimeSpan
Console.Clear();

var timeSpan = new TimeSpan();

Console.WriteLine(timeSpan);

var timeSpanHoraMinutoSegundo = new TimeSpan(5, 12, 8);
Console.WriteLine(timeSpanHoraMinutoSegundo);

var timeSpanHoraMinutoSegundoDois = new TimeSpan(9, 53, 59);

Console.WriteLine(timeSpanHoraMinutoSegundoDois - timeSpanHoraMinutoSegundo);



//Oitava parte
//TimeSpan
Console.Clear();

Console.WriteLine(DateTime.DaysInMonth(2024,2));
Console.WriteLine(DateTime.DaysInMonth(2025,2));

static bool IsWeekend(DayOfWeek today)
{
    return today == DayOfWeek.Saturday || today == DayOfWeek.Sunday;
}

Console.WriteLine(IsWeekend(DateTime.Now.DayOfWeek));