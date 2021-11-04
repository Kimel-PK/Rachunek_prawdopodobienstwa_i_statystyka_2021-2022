using System;
using System.Collections.Generic;
using AwokeKnowing.GnuplotCSharp;

namespace Zadanie_2_7 {
	class Program {
		static void Main(string[] args) {
			
			// 1)
			// ziarno generatora jest określane na podstawie zegaru systemowego w momencie utworzenia obiektu klasy
			Random random = new Random();
			
			ZestawKart zestawKart = new ZestawKart();
			
			// 2)
			// symulujemy pojedyncze losowanie
			zestawKart.Losuj();
			if (zestawKart.CzyZawieraTrefl())
				Console.WriteLine("W pojedynczym losowaniu zestaw zawierał Trefla");
			else
				Console.WriteLine("W pojedynczym losowaniu zestaw nie zawierał Trefla");
			
			double zdarzeniaSprzyjające = 0;
			double oczekiwanyWynik = 0.4135;
			int ileLosowań = 0;
			
			for (; Math.Abs (oczekiwanyWynik - (zdarzeniaSprzyjające / ileLosowań)) > 0.001; ileLosowań++) {
				
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
				
				int losowa = random.Next(0,talia.Count);
				if (losowa != wylosowaneLiczby[0] || losowa != wylosowaneLiczby[1]) {
					wylosowaneLiczby[i] = losowa;
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
