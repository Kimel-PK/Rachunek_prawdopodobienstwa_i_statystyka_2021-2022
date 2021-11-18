using System;
using System.Globalization;
using System.IO;
using AwokeKnowing.GnuplotCSharp;

namespace Zadanie_3_3 {
	class Program {
		static void Main(string[] args) {
			
			// GnuPlot obsługuje tylko liczby przecinkowe z kropką
			CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
			
			Program program = new Program();
			
			// rozkład jednostajny dla 10^3 liczb
			double[] y1 = program.RozkładJednostajnyCiągły ((int)Math.Pow(10, 3), 0, 1);
			double[] x1 = program.ObróćFunkcje (y1);
			
			// zapisz dane do pliku, GnuPlot odczyta dane z tamtąd
			StreamWriter plik1 = new("histogram1.dat");
			for (int i = 0; i < x1.Length; i++) {
				plik1.WriteLine(x1[i]);
			}
			plik1.Close();
			
			// rozkład jednostajny dla 10^5 liczb
			double[] y2 = program.RozkładJednostajnyCiągły ((int)Math.Pow(10, 5), 0, 1);
			double[] x2 = program.ObróćFunkcje (y2);
			
			// zapisz dane do pliku, GnuPlot odczyta dane z tamtąd
			StreamWriter plik2 = new("histogram2.dat");
			for (int i = 0; i < x2.Length; i++) {
				plik2.WriteLine(x2[i]);
			}
			plik2.Close();
			
			// GnuPlot
			
			// 10^3
			GnuPlot.Set ("terminal png size 1280,720", "output 'histogram1.png'");
			
			GnuPlot.WriteLine ("bw=0.04");
			GnuPlot.WriteLine ("n=1000");
			GnuPlot.WriteLine ("bin(x,width)=width*int(x/width)");
			GnuPlot.WriteLine ("set xrange [-1:3]");
			GnuPlot.WriteLine ("set yrange [0:1]");
			GnuPlot.WriteLine ("set boxwidth bw");
			GnuPlot.WriteLine ("set style fill solid 0.5");
			GnuPlot.WriteLine ("plot 'histogram1.dat' using (bin($1,bw)):(1./(bw*n)) smooth frequency with boxes t 'Funkcja eksperymentalna', 'teoretyczna.dat' linecolor 'red' with lines t 'Funkcja teoretyczna'");
			
			// 10^5
			GnuPlot.Set ("terminal png size 1280,720", "output 'histogram2.png'");
			
			GnuPlot.WriteLine ("n=100000");
			GnuPlot.WriteLine ("bin(x,width)=width*int(x/width)");
			GnuPlot.WriteLine ("set xrange [-1:3]");
			GnuPlot.WriteLine ("set yrange [0:1]");
			GnuPlot.WriteLine ("set style fill solid 0.5");
			GnuPlot.WriteLine ("plot 'histogram2.dat' using (bin($1,bw)):(1./(bw*n)) smooth frequency with boxes t 'Funkcja eksperymentalna', 'teoretyczna.dat' linecolor 'red' with lines t 'Funkcja teoretyczna'");
			
		}
		
		double[] RozkładJednostajnyCiągły (int ilość, double początek, double koniec) {
			
			double[] rozkład = new double[ilość];
			Random losuj = new Random();
			
			for (int i = 0; i < ilość; i++) {
				rozkład[i] = losuj.NextDouble();
			}
			
			return rozkład;
			
		}
		
		double[] ObróćFunkcje (double[] ośY) {
			
			double[] ośX = new double[ośY.Length];
			
			for (int i = 0; i < ośY.Length; i++) {
				
				if (ośY[i] <= 1 / 6.0) {
					ośX[i] = Math.Sqrt(6 * ośY[i]) - 1;
				} else if (ośY[i] <= 5 / 6.0) {
					ośX[i] = 3 * ośY[i] - 0.5;
				} else {
					ośX[i] = 3 - Math.Sqrt (6 - 6 * ośY[i]);
				}
				
			}
			
			return ośX;
			
		}
		
	}
}
