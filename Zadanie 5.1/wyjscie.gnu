binwidth=1
bin(x,width)=width*floor(x/width)

plot 'wyjscie.txt' using (bin($1,binwidth)):(1.0) smooth freq with boxes t 'Rozklad Poissona dla lambda = 4'

pause -1