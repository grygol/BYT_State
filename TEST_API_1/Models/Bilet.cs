using System;
namespace TEST_API_1
{
	public class Bilet
	{
		private static int wykupioneBilety = 0;

		public double Cena { get; set; }
		public DateTime DataZakupu { get; set; }
		public int IdBiletu { get; set; }
		public int NumerMiejsca { get; set; }
		//public Uzytkownik Uzytkownik { get; set; }

		public Bilet(double Cena, int NumerMiejsca)
		{
			this.Cena = Cena;
			this.DataZakupu = DateTime.Now;
			this.IdBiletu = ++wykupioneBilety;
			this.NumerMiejsca = NumerMiejsca;
		}

		public Bilet() { }
	}
}

