using System;
namespace TEST_API_1
{
    public class Czlonkostwo_zlote : Czlonkostwo
    {
        public double darmowy_kredyt { get; set; }
        public double wykorzystany_kredyt { get; set; }

        public Czlonkostwo_zlote(Czlonkostwo czlonkostwo)
        {
            this.znizka = 0.15;
            this.vip_access = true;
            this.uzytkownik = czlonkostwo.Uzytkownik;
            Console.WriteLine(czlonkostwo.GetType());
            this.darmowy_kredyt = 2000;
            this.wykorzystany_kredyt = 0;
        }

        public override object get_details()
        {
            return new
            {
                typ = "Zlote",
                znizka = this.znizka,
                vip_access = this.vip_access,
                darmowy_kredyt = this.darmowy_kredyt,
                wykorzystany_kredyt = this.wykorzystany_kredyt
            };
        }

        public override double wylicz_znizke(double cena)
        {
            Console.WriteLine("Złota zniżka");

            if (cena <= this.darmowy_kredyt)
            {
                Console.WriteLine("darmowy");
                this.wykorzystany_kredyt += cena;
                this.darmowy_kredyt -= cena;
                return 0;
            }
            else
            {
                Console.WriteLine("Obniżony");
                double po_znizce = cena - this.darmowy_kredyt;
                this.wykorzystany_kredyt += this.darmowy_kredyt;
                this.darmowy_kredyt = 0;
                return po_znizce * (1.0 - znizka);
            }   
        }

        public override bool sprawdz_uprawnienie()
        {
            if (this.uzytkownik.przelatane_kilometry >= Czlonkostwo.zlote_min)
            {
                return true;
            }
            else
            {
                this.uzytkownik.czlonkostwo = new Czlonkostwo_srebrne(this);
                return this.uzytkownik.czlonkostwo.sprawdz_uprawnienie();
            }
        }
    }
}

