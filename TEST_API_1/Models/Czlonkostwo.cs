using System;
namespace TEST_API_1
{
	public abstract class Czlonkostwo
	{
		protected Uzytkownik uzytkownik;
		protected double znizka;
        protected Boolean vip_access;

		protected static double brazowe_min { get; set; } = 20000;
        protected static double srebrne_min { get; set; } = 50000;
        protected static double zlote_min { get; set; } = 70000;

		public virtual double wylicz_znizke(double cena)
		{
			Console.WriteLine("Znizka basic");
			if (sprawdz_uprawnienie())
			{
				return cena * (1.0 - znizka);
			}
			else return cena;
		}

		public Uzytkownik Uzytkownik
		{
			get { return uzytkownik; }
			set { uzytkownik = value; }
		}

		public abstract bool sprawdz_uprawnienie();
		public abstract Object get_details();
    }
}

