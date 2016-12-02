using System;
namespace WindowsFormsApplication1
{
	public class Register
	{
		private int campo1, campo2, campo3, campo4, campo5, campo6;

		public Register(int c1, int c2, int c3, int c4, int c5, int c6)
		{
			campo1 = c1;
			campo2 = c2;
			campo3 = c3;
			campo4 = c4;
			campo5 = c5;
			campo6 = c6;
		}

		public int getCampo1()
		{
			return campo1;
		}

		public override string ToString()
		{
			return string.Format("{0}, {1}, {2}, {3}, {4}, {5}", campo1.ToString(), campo2.ToString(), campo3.ToString(), campo4.ToString(), campo5.ToString(), campo6.ToString());
		}
	}
}
