using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace şifrelemeuyg
{
    internal class Program
    {
        
        static char boşlukv2 = '/';
        static char[] alfabe =
            {'a','b','c', 'ç', 'd', 'e', 'f',
            'g', 'ğ', 'h', 'ı', 'i',
            'j', 'k', 'l', 'm', 'n',
            'o', 'ö', 'p', 'r', 's',
            'ş', 't', 'u', 'ü', 'v', 'y', 'z'};
        
        static int kod = 5;
        static void Main(string[] args)
        {
            Console.WriteLine("şifre oluştur(1)\nşifre çöz(2)\nburaya geri dönmek için 44 yazın");
            int ekran = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
             if (ekran == 0)
            {
                Console.WriteLine("şifre oluştur(1)\nşifre çöz(2)");
                ekran = Convert.ToInt32(Console.ReadLine());
            }
            
            if (ekran == 1)
            {
            while (true)
             {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nŞifre Oluşturucu");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("(29 dan büyük olmayacak şekilde)anahtarı belirleyin: ");
                        kod = Convert.ToInt32(Console.ReadLine());
                        if (kod == 44)
                        {
                            ekran = 0;
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                    string mesaj = Console.ReadLine();
                    if (mesaj== "44" )
                    {
                        ekran = 0;
                            break;
                    }   
                    char[] şifre = şifreleme(mesaj,kod);
                    Console.WriteLine("\nşifreniz:");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine(şifre);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("------------------");
             }

            }
            if (ekran == 2)
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nŞifre Çözücü");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("(29 dan büyük olmayacak şekilde)anahtarı girin: ");
                        kod = Convert.ToInt32(Console.ReadLine());
                        if (kod == 44)
                        {
                            ekran = 0;
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                    string kriptikmesaj = Console.ReadLine();
                        if (kriptikmesaj == "44" )
                        {
                            ekran = 0;
                            break;
                        }
                        char[] çözülmüşmesaj = şifreçözücü(kriptikmesaj,kod);
                    Console.WriteLine("\nmesaj:");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine(çözülmüşmesaj);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("------------------");
                }

            }
            }
           


        }
        static char[] şifreleme(string mesaj,int kod)
        {
           
            int a = 0; 
            char[] liste = mesaj.ToCharArray();   
            foreach (var harf in liste)
            {
                for (int i = 0; i < alfabe.GetUpperBound(0)+1; i++)
                {
                    
                    if (harf == alfabe[i])
                    {
                        if (alfabe.GetUpperBound(0)+1-kod <= i )
                        {
                            liste[a] = alfabe[(i+kod)-29];
                        }
                        else
                        {
                            liste[a] = alfabe[i + kod];
                        }
                        
                       
                        
                    }
                    else if (harf == ' ')
                    {
                        liste[a] = boşlukv2;
                    }
                }
                a++;
            }
            return liste;
        }

        static char[] şifreçözücü(string kriptikmesaj, int kod)
        {
            char[] şifre = kriptikmesaj.ToCharArray();
            int a = 0;
            foreach (var harf in şifre)
            {
                for (int i = 0; i < alfabe.GetUpperBound(0)+1; i++)
                {
                    if (harf == alfabe[i])
                    {
                        if (kod > i)
                        {
                            şifre[a] = alfabe[(i - kod) + 29];
                        }
                        else
                        {
                            şifre[a] = alfabe[i - kod];
                        }
                        
                    }
                    else if (harf == boşlukv2)
                    {
                        şifre[a] = ' ';
                    }
                }
                a++;
            }
            return şifre;
        }

    }
}
