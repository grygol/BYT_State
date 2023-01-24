using System;
namespace TEST_API_1
{
	public class Czlonkostwo_brak : Czlonkostwo
	{
		public Czlonkostwo_brak(Czlonkostwo czlonkostwo)
		{
            this.znizka = 0;
            this.vip_access = false;
            this.uzytkownik = czlonkostwo.Uzytkownik;
		}

        public override object get_details()
        {
            return new
            {
                typ = "Brak",
                znizka = this.znizka,
                vip_access = this.vip_access
            };
        }

        public Czlonkostwo_brak(Uzytkownik uzytkownik)
        {
            this.znizka = 0;
            this.vip_access = false;
            this.uzytkownik = uzytkownik;
        }

        public override bool sprawdz_uprawnienie()
        {
            if (this.uzytkownik.przelatane_kilometry < Czlonkostwo.brazowe_min)
            {
                return true;
            } else
            {
                this.uzytkownik.czlonkostwo = new Czlonkostwo_brazowe(this);
                return this.uzytkownik.czlonkostwo.sprawdz_uprawnienie();
            }
        }
    }
}

