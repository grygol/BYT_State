using System;
namespace TEST_API_1
{
    public class Czlonkostwo_srebrne : Czlonkostwo
    {
        public bool plus { get; set; }

        public Czlonkostwo_srebrne(Czlonkostwo czlonkostwo)
        {
            this.znizka = 0.10;
            this.vip_access = false;
            this.uzytkownik = czlonkostwo.Uzytkownik;
        }

        public override object get_details()
        {
            return new
            {
                typ = "Srebrne",
                znizka = this.znizka,
                vip_access = this.vip_access,
                plus = this.plus
            };
        }

        public void podnies_stopien()
        {
            this.vip_access = true;
        }

        public override bool sprawdz_uprawnienie()
        {
            if (this.uzytkownik.przelatane_kilometry >= Czlonkostwo.srebrne_min && this.uzytkownik.przelatane_kilometry < Czlonkostwo.zlote_min)
            {
                return true;
            }
            else if (this.uzytkownik.przelatane_kilometry < Czlonkostwo.srebrne_min)
            {
                this.uzytkownik.czlonkostwo = new Czlonkostwo_brazowe(this);

            }
            else if (this.uzytkownik.przelatane_kilometry >= Czlonkostwo.zlote_min)
            {
                this.uzytkownik.czlonkostwo = new Czlonkostwo_zlote(this);
            }
            return this.uzytkownik.czlonkostwo.sprawdz_uprawnienie();
        }
    }
}

