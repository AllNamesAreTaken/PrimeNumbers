using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList primes = new ArrayList();
            ArrayList[] primeFactors;

            int lim = System.Convert.ToInt32(Console.In.ReadLine());
            primeFactors = new ArrayList[lim];

            primeFactors[0] = new ArrayList();
            primeFactors[0].Add(1);

            for (int i = 1; i < lim; i++)
            {
                primeFactors[i] = new ArrayList();
                primeFactors[i].Add(i + 1);

                bool isPrime = true;

                for(int j = 0; j < primes.Count; j++)
                {
                    if((i+1)%(int)primes[j] == 0)
                    {
                        isPrime = false;
                        int k = i + 1;
                        while (k % (int)primes[j] == 0)
                        {
                            primeFactors[i].Add(primes[j]);
                            k = k / (int)primes[j];
                        }
                    }
                }

                if(isPrime)
                {
                    primes.Add(i + 1);
                    primeFactors[i].Add(i + 1);
                }
            }

            string output = "Primes: ";

            foreach(int a in primes)
            {
                output += a + " ";
            }

            output += "\r\nNumbers and Factors\r\n";

            foreach(ArrayList a in primeFactors)
            {
                int spacing = (int)a[0];
                while(spacing < 1000)
                {
                    output += " ";
                    spacing = spacing * 10;
                }
                output += "   " + a[0] + " : ";

                for(int i = 1; i < a.Count; i++)
                {
                    output += a[i] + " ";
                }

                output += "\r\n";
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter("test.txt", false))
            {
                file.Write(output);
            }

            Console.Out.Write(output);
            Console.In.ReadLine();
        }
    }
}
