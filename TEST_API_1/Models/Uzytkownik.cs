using System;
namespace TEST_API_1
{
	public class Uzytkownik
	{
		public String adres { get; set; }
        public DateTime data_rejestracji { get; set; }
        public String email { get; set; }
        public double przelatane_kilometry { get; set; }
		public String[] telefony { get; set; }
        public Czlonkostwo czlonkostwo { get; set; }
		public String typ_czlonkostwa { get; set; }
		public List<Bilet> bilety { get; set; }

		public Uzytkownik()
		{

		}

        public Uzytkownik(string adres, DateTime data_rejestracji, string email, string[] telefony)
        {
            this.adres = adres;
            this.data_rejestracji = data_rejestracji;
            this.email = email;
            this.telefony = telefony;
			this.przelatane_kilometry = new Random().Next(100000);
			this.czlonkostwo = new Czlonkostwo_brak(this);
            this.bilety = new List<Bilet>();

			this.czlonkostwo.sprawdz_uprawnienie();
        }

        public Uzytkownik(string adres, DateTime data_rejestracji, string email, string[] telefony, double przelatane_kilometry)
        {
            this.adres = adres;
            this.data_rejestracji = data_rejestracji;
            this.email = email;
            this.telefony = telefony;
            this.przelatane_kilometry = przelatane_kilometry;
            this.czlonkostwo = new Czlonkostwo_brak(this);
            this.bilety = new List<Bilet>();

            this.czlonkostwo.sprawdz_uprawnienie();
        }


        public Boolean zaloguj()
		{
			return true;
		}
	}
}

