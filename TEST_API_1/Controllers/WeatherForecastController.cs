using Microsoft.AspNetCore.Mvc;

namespace TEST_API_1.Controllers;

[ApiController]
[Route("/")]
public class WeatherForecastController : ControllerBase
{
    private static readonly Uzytkownik[] Uzytkownicy = new[]
    {
        new Uzytkownik("Ap #454-4882 Duis Ave", DateTime.Now, "cras.vulputate@aol.net", new String[]{"1-456-837-3866"}, 1000), //brak
        new Uzytkownik("P.O. Box 513, 169 Interdum Av.", DateTime.Now, "eu.neque@protonmail.net", new String[]{"(550) 740-1448"}, 30000), //braz
        new Uzytkownik("952-3851 Dictum Street", DateTime.Now, "sit.amet@yahoo.edu", new String[]{"1-347-846-1083"}, 60000), //srebro
        new Uzytkownik("Ap #881-5198 Mauris Avenue", DateTime.Now, "quam@icloud.edu", new String[]{"1-391-739-4611"},80000) //zloto
    };


    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Uzytkownik> Get()
    {
        //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //{
        //    Date = DateTime.Now.AddDays(index),
        //    TemperatureC = Random.Shared.Next(-20, 55),
        //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //})
        //.ToArray();
        Console.WriteLine(Uzytkownicy[0].adres);


        return Uzytkownicy.Select(e => new Uzytkownik
        {
            adres = e.adres,
            data_rejestracji = e.data_rejestracji,
            email = e.email,
            przelatane_kilometry = e.przelatane_kilometry,
            telefony = e.telefony,
            typ_czlonkostwa = e.czlonkostwo.ToString(),
            bilety = e.bilety
        }).ToList();
    }

    [HttpGet("{idUzytkownik}")]
    public IActionResult GetCzlonkostwo(int idUzytkownik)
    {
        if(idUzytkownik > Uzytkownicy.Length-1 || idUzytkownik < 0)
        {
            return NotFound("Nie ma użytkownika o podanym ID!");
        }
        Uzytkownik uzytkownik = Uzytkownicy[idUzytkownik];
        Czlonkostwo czlonkostwo = uzytkownik.czlonkostwo;

        return Ok(czlonkostwo.get_details());
    }

    [HttpPost]
    public IActionResult BuyTicket(int idUzytkownik, double Cena, int NumerMiejsca)
    {
        if (idUzytkownik > Uzytkownicy.Length - 1 || idUzytkownik < 0)
        {
            return NotFound("Nie ma użytkownika o podanym ID!");
        }

        Uzytkownik uzytkownik = Uzytkownicy[idUzytkownik];
        double finalna_cena = uzytkownik.czlonkostwo.wylicz_znizke(Cena);
        Bilet bilet = new Bilet(finalna_cena, NumerMiejsca);
        uzytkownik.bilety.Add(bilet);

        return Ok(bilet);
    }
}

