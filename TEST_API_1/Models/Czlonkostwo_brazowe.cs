using System;
namespace TEST_API_1
{
	public class Czlonkostwo_brazowe : Czlonkostwo
	{
		public Czlonkostwo_brazowe(Czlonkostwo czlonkostwo)
		{
            this.znizka = 0.05;
            this.vip_access = false;
            this.uzytkownik = czlonkostwo.Uzytkownik;
		}

        public override object get_details()
        {
            return new
            {
                typ = "Brazowe",
                znizka = this.znizka,
                vip_access = this.vip_access
            };
        }

        public override bool sprawdz_uprawnienie()
        {
            if (this.uzytkownik.przelatane_kilometry >= Czlonkostwo.brazowe_min && this.uzytkownik.przelatane_kilometry < Czlonkostwo.srebrne_min) {
                return true;
            } else if(this.uzytkownik.przelatane_kilometry < Czlonkostwo.brazowe_min)
            {
                this.uzytkownik.czlonkostwo = new Czlonkostwo_brak(this);
                
            } else if(this.uzytkownik.przelatane_kilometry >= Czlonkostwo.srebrne_min)
            {
                this.uzytkownik.czlonkostwo = new Czlonkostwo_srebrne(this);
            }
            return this.uzytkownik.czlonkostwo.sprawdz_uprawnienie();
        }
    }
}

