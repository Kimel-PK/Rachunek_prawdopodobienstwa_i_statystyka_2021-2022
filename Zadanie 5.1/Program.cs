// stałe
const double E = 2.71828182846;
const int ILOŚĆ_DANYCH = 100000;
const int LAMBDA = 4;

// dane zapisane jako pary liczb
Tuple<int, double>[] x_y = new Tuple<int, double>[ILOŚĆ_DANYCH];

Random losuj = new Random();

for(int i = 0; i < ILOŚĆ_DANYCH; i++) {
	
	int k = Oblicz_k(LAMBDA, losuj.NextDouble());
	
	Tuple<int, double> para = new Tuple<int, double> (k, Rozklad_Poissona(k, LAMBDA));
	x_y[i] = para;
}

Sortuj(x_y);
Zapisz(x_y, "dane.txt");

// Metody

int Oblicz_k(int lambda, double wylosowana) {
	
	int k = 0;
	double q = Math.Pow(E, -lambda);
	double p = q;
	double s = q;

	while(wylosowana > s) {
		k = k+1;
		p = p * ((double)lambda / (double)k);
		s = s+p;
	}

	return k;
}

double Rozklad_Poissona(int k, int lambda) {
	
	double exp = Math.Pow(E, -lambda);
	double mian = 1;
	double licznik;

	if (k == 0)
		return 0;

	licznik = Math.Pow(lambda, k) * exp;
	
	for(int i = 1; i <= k; i++) {
		mian = mian * i;
	}

	return (licznik / mian);
}

void Zapisz(Tuple<int, double>[] x_y, string doc_name) {
	
	StreamWriter writer = File.CreateText("wyjscie.txt");
	
	for(int i = 0; i < ILOŚĆ_DANYCH; i++) {
		writer.WriteLine (x_y[i].Item1 + " " + x_y[i].Item2);
	}
	
	writer.Close ();
}

void Sortuj(Tuple<int, double> [] x_y) {
	
	for (int i = 0; i < ILOŚĆ_DANYCH; i++) {
		
		for (int j = 0; j < ILOŚĆ_DANYCH - i - 1; j++) {
			
			if (x_y[j].Item1 > x_y[j + 1].Item1) {
				
				Tuple<int, double> temp = x_y[j + 1];
				x_y[j + 1] = x_y[j];
				x_y[j] = temp;
			}
		}
	}
}