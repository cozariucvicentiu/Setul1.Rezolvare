using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Setul1Rezolvare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scrieti numarul problemei pe care doriti sa o folositi:");
            int Problema = int.Parse(Console.ReadLine());
            switch (Problema)

            {
                case 1 : PB1(); break;
                case 2 : PB2(); break;
                case 3 : PB3(); break;
                case 4 : PB4(); break;
                case 5 : PB5(); break;
                case 6 : PB6(); break;
                case 7 : PB7(); break;
                case 8 : PB8(); break;
                case 9 : PB9(); break;
                case 10: PB10();break;
                case 11: PB11();break;
                case 12: PB12();break;
                case 13: PB13();break;
                case 14: PB14();break;
                case 15: PB15();break;
                case 16: PB16();break;
                case 17: PB17();break;
                case 18: PB18();break;
                case 19: PB19();break;
                case 20: PB20();break;
                case 21: PB21();break;
                default: PB22();break;
            }
        }

     

        private static void PB21()
        {
            //21.	Ghiciti un numar intre 1 si 1024 prin intrebari de forma "numarul este mai mare sau egal decat x?". 
            int ls = 0;
            int ld = 1025;
            int mid = (ls + ld) / 2;
            while (ls < ld)
            {
                Console.WriteLine($"Este numarul mai mare sau egal decat {mid}?");
                string statement = Console.ReadLine();
                if (statement == "da")
                {
                    ls = mid;
                    mid = (ls + ld) / 2;
                }
                else if (statement == "nu")
                {
                    ld = mid;
                    mid = (ls + ld) / 2;
                }
                else if (statement == "egal")
                    break;
                if (mid % 2 != 0)
                    break;
            }
            Console.WriteLine($"Numarul tau este {mid}");
            Console.ReadKey();
        }

        private static void PB20()
        {
            //Afisati fractia m/n in format zecimal, cu perioada intre paranteze (daca e cazul). Exemplu: 13/30 = 0.4(3).
            Console.WriteLine("Introduceti nr n:");
            int m=int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti nr m:");
            int n=int.Parse(Console.ReadLine());
            int parteInt, parteFract;
            parteInt = m / n; 
            parteFract = m % n;
            Console.Write($"Numarul va arata asa: {parteInt},");
            int cifra, rest;
            List<int> resturi = new List<int>();
            List<int> cifre = new List<int>();
            resturi.Add(parteFract);
            bool periodic = false;
            do
            {
                cifra = parteFract * 10 / n;
                cifre.Add(cifra);
                rest = parteFract * 10 % n;
                if (!resturi.Contains(rest))
                {
                    resturi.Add(rest);
                }
                else
                {
                    periodic = true;
                    break;
                }
                parteFract = rest;
            } while (rest != 0);

            if (!periodic)
            {
                foreach (var item in cifre)
                {
                    Console.Write(item);
                }
            }
            else
            {
                for (int i = 0; i < resturi.Count; i++)
                {
                    if (resturi[i] == rest)
                    {
                        Console.Write("(");
                    }
                    Console.Write(cifre[i]);
                }
                Console.WriteLine(").");
            }
            Console.ReadKey();
        }

        private static void PB19()
        {
            //Determinati daca un numar e format doar cu 2 cifre care se pot repeta.
            //De ex. 23222 sau 9009000 sunt astfel de numere, pe cand 593 si 4022 nu sunt. 
            Console.WriteLine("Introduceti numarul:");
            int n=int.Parse(Console.ReadLine());
            int aux = n;
            int w = 0;
            int g = n%10;
            n = n / 10;
            int f = 0;
            while(n>0)
            {
                if (n% 10 != g && w == 1 && n%10!=f)
                {
                    Console.WriteLine($"Numarul {aux} are mai mult de 2 cifre care se repeta.");
                    Console.ReadKey();
                    return;
                }
                    
                if (n % 10 != g && w==0) { f = n % 10;w++; }
                
                n = n / 10;
            }
            if(w==0)
            {
                Console.WriteLine($"Nr {aux} are doar o singura cifra care se repeta, si anume {g}.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine($"Nr {aux} are doar 2 cifre care se repeta.");
            Console.ReadKey();
        }

        private static void PB18()
        {
            //Afisati descompunerea in factori primi ai unui numar n.  De ex. pentru n = 1176 afisati 2^3 x 3^1 x 7^2.
            Console.WriteLine("Introduceti nr:");
            int n = int.Parse(Console.ReadLine());
            int d = 2;
            int w = 0;

            while (n > 1)
            {
                int p = 0;
                while (n % d == 0)
                {
                    ++p;
                    n /= d;
                }
                if (p > 0 && w==0)
                    Console.Write($"{d}^{p}+");
                if (p > 0 && w==1)
                    Console.Write($"{d}^{p}");

                ++d;
                if (n > 1 && d * d > n)
                {
                    d = n;
                    w = 1;
                }
            }
            Console.ReadKey();
;            
        }

        private static void PB17()
        {
            //Determianti cel mai mare divizor comun si cel mai mic multiplu comun a doua numere. Folositi algoritmul lui Euclid. 
            Console.WriteLine("Introduceti primul numar:");
            long a = long.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti al doilea numar:");
            long b = long.Parse(Console.ReadLine());
            long x = 0;
            long c = a;
            long d = b;
            while(a!= b)
            {
                if (a > b) { a = a - b; }
                if (a < b) { b = b - a; }
            }
            if (c == d) { x =c; }
            else { x = c * d; }
            Console.WriteLine($"CMMDC este {a}, iar CMMMC este {x}.");
            Console.ReadKey();
        }

        private static void PB16()
        {
            //Se dau 5 numere. Sa se afiseze in ordine crescatoare. (nu folositi tablouri)
            Console.WriteLine("Introduceti 5 numere cu spatiu intre ele:");
            string[] t = Console.ReadLine().Split(' ');
            long a = long.Parse(t[0]);
            long b = long.Parse(t[1]);
            long c = long.Parse(t[2]);
            long d = long.Parse(t[3]);
            long e = long.Parse(t[4]);
            long aux;

            if (a > b) { aux = a; a = b; b = aux; }
            if (a > c) { aux = a; a = c; c = aux; }
            if (a > d) { aux = a; a = d; d = aux; }
            if (a > e) { aux = a; a = e; e = aux; }
            if (b > c) { aux = b; b = c; c = aux; }
            if (b > d) { aux = b; b = d; d = aux; }
            if (b > e) { aux = b; b = e; e = aux; }
            if (c > d) { aux = c; c = d; d = aux; }
            if (c > e) { aux = c; c = e; e = aux; }
            if (d > e) { aux = d; d = e; e = aux; }

            Console.WriteLine($"Numerele in ordine crescatoare vor arata asa {a}, {b}, {c}, {d}, {e}.");
            Console.ReadKey();
        }

        private static void PB15()
        {
            //Se dau 3 numere. Sa se afiseze in ordine crescatoare. 
            Console.WriteLine("Introduceti 3 numere cu spatiu intre ele:");
            string[] t = Console.ReadLine().Split(' ');
            long a = int.Parse(t[0]);
            long b = int.Parse(t[1]);
            long c = int.Parse(t[2]);
            long min = a;
            if(b < min) { min = b; }
            if(c < min) { min = c; }
            long max = a;
            if(c > max) { max = c; }
            if(b > max) { max = b; }
            Console.WriteLine($"Numerele in ordine crescatoare sunt {min}, {a + b + c - max - min}, {max}.");
            Console.ReadKey();
        }

        private static void PB14()
        {
            //Determianti daca un numar n este palindrom.
            //(un numar este palindrom daca citit invers obtinem un numar egal cu el, de ex. 121 sau 12321. 
            Console.WriteLine("Introduceti numarul n:");
            long n = int.Parse(Console.ReadLine());
            long aux = n;
            long k = 0;
            while (n > 0)
            {
                k = k * 10 + n % 10;
                n = n / 10;
            }
            if(aux==k)
                Console.WriteLine($"Numarul {aux} este palindrom.");
            else
                Console.WriteLine($"Numarul {aux}  nu este palindrom.");
            Console.ReadKey();
        }

        private static void PB13()
        {
            //Determianti cati ani bisecti sunt intre anii y1 si y2.
            Console.WriteLine("Introduceti anul y1:");
            long y1=int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti anul y2:");
            long y2 = int.Parse(Console.ReadLine());
            int nr = 0;
            for(long i=y1+1;i<y2;i++)
            {
                if ((i % 400 == 0) || (i % 4 == 0 && i % 100 != 0))
                    nr++;
            }
            Console.WriteLine($"Intre anii {y1} si {y2} sunt {nr} ani bisecti.");
            Console.ReadKey();

        }

        private static void PB12()
        {
            //Determinati cate numere integi divizibile cu n se afla in intervalul [a, b]. 
            Console.WriteLine("Introduceti numarul n:");
            long n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti numarul a:");
            long a = long.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti numarul b:");
            long b = long.Parse(Console.ReadLine());
            int counter = 0;
            for(int i = 1; i <= n; i++)
                if(n%i==0 && a<=i && i<=b)
                    counter++;
            Console.WriteLine($"Exista {counter} numare intregi divizibile cu {n} in intervalul [{a},{b}].");
            Console.ReadKey();
        }

        private static void PB11()
        {
            //Afisati in ordine inversa cifrele unui numar n. 
            Console.WriteLine("Introduceti numarul n:");
            long n = int.Parse(Console.ReadLine());
            long aux = n;
            long k = 0;
            while(n>0)
            {
                k = k * 10 + n % 10;
                n=n/ 10;
            }
            Console.WriteLine($"Numarul {aux} in ordine inversa este {k}.");
            Console.ReadKey();
        }

        private static void PB22()
        {
            Console.WriteLine($"Numarul introdus nu corespunde nici unei probleme!");
            Console.ReadKey();
        }

        private static void PB10()
        {
            //Test de primalitate: determinati daca un numar n este prim.
            Console.WriteLine("Introduceti numarul n:");
            long n = int.Parse(Console.ReadLine());
            if(n == 0 || n==1)
            {
                Console.WriteLine($"Numarul {n} nu este prim.");
                Console.ReadKey();
                return;
            }
            for(int i=2;i<=Math.Sqrt(n);i++)
            {
                if(n%i==0)
                {
                    Console.WriteLine($"Numarul {n} nu este prim.");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine($"Numarul {n} este prim.");
            Console.ReadKey();
        }

        private static void PB9()
        {
            //Afisati toti divizorii numarului n. 
            Console.WriteLine("Introduceti numarul n:");
            long n = int.Parse(Console.ReadLine());
            for(int i=1;i<=n;i++)
            {
                if(n%i==0)
                {
                    Console.Write(i+" ");
                }
            }
            Console.ReadKey();
        }

        private static void PB8()
        {
            //(Swap restrictionat) Se dau doua variabile numerice a si b ale carori valori sunt date de intrare.
            //Se cere sa se inverseze valorile lor fara a folosi alte variabile suplimentare.  
            Console.WriteLine("Introduceti numarul a:");
            long a = long.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti numarul b:");
            long b = long.Parse(Console.ReadLine());
            a = a+b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"Acuma a are valorea {a}, iar b are valoarea {b}.");
            Console.ReadKey();
        }

        private static void PB7()
        {
            //(Swap) Se dau doua variabile numerice a si b ale carori valori sunt date de intrare. Se cere sa se inverseze valorile lor.
            Console.WriteLine("Introduceti numarul a:");
            long a = long.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti numarul b:");
            long b = long.Parse(Console.ReadLine());
            (a, b) = (b, a);
            Console.WriteLine($"Acuma a are valorea {a}, iar b are valoarea {b}.");
            Console.ReadKey();
        }

        private static void PB6()
        {
            //Detreminati daca trei numere pozitive a, b si c pot fi lungimile laturilor unui triunghi. 
            Console.WriteLine("Introduceti numarul a:");
            long a = long.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti numarul b:");
            long b = long.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti numarul c:");
            long c = long.Parse(Console.ReadLine());
            if (a + b > c && a + c > b && c + b > a)
            {
                Console.WriteLine("Da, ele pot fi lungimile unui triunghi.");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Nu, ele nu pot fi lungimile unui triunghi.");
                Console.ReadKey();
            }
            
        }

        private static void PB5()
        {
            //Extrageti si afisati a k-a cifra de la sfarsitul unui numar. Cifrele se numara de la dreapta la stanga.
            Console.WriteLine("Introduceti numarul n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti numarul k:");
            int k = int.Parse(Console.ReadLine());
            int aux = n;
            for(int i = 1; i < n; i++)
            {
                if(k==i)
                {
                    Console.WriteLine($"A {k}-a cifra din {aux} este {n % 10}");
                    Console.ReadKey();
                    return;
                }
                n = n / 10;
            }
            Console.WriteLine($"{k} depaseste numarul de cifre al lui {aux}.");
            Console.ReadKey();
        }

        private static void PB4()
        {
            //Detreminati daca un an y este an bisect. 
            int y = int.Parse(Console.ReadLine());
            if ((y % 400 == 0) || (y % 4 == 0 && y % 100 != 0))
            { Console.WriteLine(y + " este an bisect"); }
            else { Console.WriteLine(y + " nu este an bisect"); }
            Console.ReadKey();
        }

        private static void PB3()
        {
            //Determinati daca n se divide cu k, unde n si k sunt date de intrare. 
            Console.WriteLine("Introduceti numarul n:");
            double n = double.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti numarul k:");
            double k = double.Parse(Console.ReadLine());
            if(n > k && n%k==0)
            {
                Console.WriteLine($"Numaru {n} se divide cu {k}.");
                Console.ReadKey();
                return;
            }
            if(n<k && k%n==0)
            {
                Console.WriteLine($"Numarul {n} se divide cu {k}.");
                Console.ReadKey();
                return;
            }
            if(k==n)
            {
                Console.WriteLine($"Numarul {n} se divide cu {k}.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine($"Numarul {n} nu se divide cu {k}.");
            Console.ReadKey();

        }

        private static void PB2()
        {
            //Rezolvati ecuatia de gradul 2 cu o necunoscuta: ax^2 + bx + c = 0, unde a, b si c sunt date de intrare.
            //Tratati toate cazurile posibile. 
            Console.WriteLine("Introduceti numarul a:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti numarul b:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti numaruc c:");
            double c = double.Parse(Console.ReadLine());
            double D=b*b-4*a*c;
            if (D < 0) 
            { 
                Console.WriteLine("Ecuatia nu are radacini reale.");
                Console.ReadKey();
                return;
            }
            if(D==0)
            {
                double x = (-b)/ (4 * a);
                Console.WriteLine($"Ecuatia are o singura radacina, care este {x}.");
                Console.ReadKey();
                return;
            }
            if(D>0)
            {
                double x1=((-b)+Math.Sqrt(D))/ (4 * a);
                double x2=(-b-Math.Sqrt(D))/ (4 * a);
                Console.WriteLine($"Ecuatia are 2 radacini care sunt {x1} si {x2}.");
            }
            Console.ReadKey();
        }

        private static void PB1()
        {
            //Rezolvati ecuatia de gradul 1 cu o necunoscuta: ax+b = 0, unde a si b sunt date de intrare.
            Console.WriteLine("Introduceti numarul a:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti numarul b:");
            double b=double.Parse(Console.ReadLine());
            Console.WriteLine($"Numarul x este egal cu {(-b/a)}");
            Console.ReadKey();
        }
    }
}
