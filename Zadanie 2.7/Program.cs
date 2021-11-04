/*

	Program napisany w języku C#
	Aby uruchomić program należy:
	posiadać zainstalowane środowisko .NET
	otworzyć cmd lub powershell i w folderze projektu wpisać polecenie "dotnet run"

	Odpowiedź do podpunktu 3)
	
	uruchomiłem program 20 razy i zapisałem wyniki
	istnieje strasznie duża rozbieżność pomiedzy liczbą losowań aby uzyskać przybliżenie
	dużo razy zdarza się także że liczba losowań jest tak duża że program wydaje się nie odpowiadać
	po 20 uruchomieniach taka sytuacja zdarzyła się 1 raz
	średnia ilość losowań w 20 próbach potrzebnych do uzyskania wyniku 41,35% z dokładnością 0,1% to 448 losowań

*/

using System;
using System.Collections.Generic;

namespace Zadanie_2_7 {
	class Program {
		static void Main(string[] args) {
			
			double zdarzeniaSprzyjające = 0;
			double oczekiwanyWynik = 0.4135;
			int ileLosowań = 0;
			
			// 1)
			// ziarno generatora jest określane na podstawie zegaru systemowego w momencie utworzenia obiektu klasy
			Random random = new Random();
			
			ZestawKart zestawKart = new ZestawKart();
			
			// 2)
			// symulujemy pojedyncze losowanie
			zestawKart.Losuj();
			ileLosowań++;
			if (zestawKart.CzyZawieraTrefl()) {
				Console.WriteLine("W pojedynczym losowaniu zestaw zawierał Trefla");
			} else {
				Console.WriteLine("W pojedynczym losowaniu zestaw nie zawierał Trefla");
				zdarzeniaSprzyjające++;
			}
			
			// 3)
			// powtarzamy losowanie tak długo aż osiągniemy przybliżony wynik
			for (; Math.Abs (oczekiwanyWynik - (zdarzeniaSprzyjające / (double)ileLosowań)) > 0.001; ileLosowań++) {
				
				zestawKart.Losuj();
				if (!zestawKart.CzyZawieraTrefl()) {
					zdarzeniaSprzyjające++;
				}
				
			}
			
			Console.WriteLine ("Przybliżony wynik osiągnięto po " + ileLosowań + " losowaniach");
			
		}
	}
	
	class ZestawKart {
		
		List<Karta> talia;
		Karta[] wylosowaneKarty;
		
		public ZestawKart () {
			
			// budujemy talie
			talia = new List<Karta>();
		
			for (int i = 0; i < 13; i++) {
				talia.Add(Karta.Trefl);
			}
			for (int i = 0; i < 13; i++) {
				talia.Add(Karta.Pik);
			}
			for (int i = 0; i < 13; i++) {
				talia.Add(Karta.Karo);
			}
			for (int i = 0; i < 13; i++) {
				talia.Add(Karta.Kier);
			}
			
		}
		
		public void Losuj () {
			
			int[] wylosowaneLiczby = new int[3];
			Random random = new Random();
			
			for (int i = 0; i < 3;) {
				
				int losowa = random.Next(1, talia.Count + 1);
				if (losowa != wylosowaneLiczby[0] || losowa != wylosowaneLiczby[1]) {
					wylosowaneLiczby[i] = losowa - 1;
					i++;
				}
				
			}
			
			wylosowaneKarty = new Karta[] {talia[wylosowaneLiczby[0]], talia[wylosowaneLiczby[1]], talia[wylosowaneLiczby[2]]};
			
		}
	
		public bool CzyZawieraTrefl () {
			
			if (wylosowaneKarty[0] == Karta.Trefl || wylosowaneKarty[1] == Karta.Trefl || wylosowaneKarty[2] == Karta.Trefl)
				return true;
			else
				return false;
			
		}
		
	}
	
	public enum Karta {
		Trefl,
		Pik,
		Karo,
		Kier
	}
	
}
