using System;
using System.Collections.Generic;
using AwokeKnowing.GnuplotCSharp;

namespace Zadanie_2_7 {
    class Program {
        static void Main(string[] args) {
            
            // ziarno generatora jest określane na podstawie zegaru systemowego w momencie utworzenia obiektu klasy
            Random random = new Random();
            
            // budujemy talie
            List<Karta> talia = new List<Karta>();
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
    }
    
    public enum Karta {
        Trefl,
        Pik,
        Karo,
        Kier
    }
    
}
