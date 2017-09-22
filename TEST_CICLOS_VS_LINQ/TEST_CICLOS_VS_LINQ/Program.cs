using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TEST_CICLOS_VS_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            //String mac = Check("192.168.1.161");

            time.Stop();
            var tiempo = time.Elapsed;

            time.Reset();

            List<TipoTest> listaTest = new List<TipoTest>();

            for (int i = 0; i <= 200; i++)
            {
                TipoTest t = new TipoTest();
                t.Nombre = "aa" + i;
                t.Numero = i;
                listaTest.Add(t);
            }
            time.Start();

            var a = (from l in listaTest
                     where l.Numero == 199
                     select l);

            time.Stop();
            Console.WriteLine("Tiempo de demora con Linq = " + time.Elapsed);
            time.Reset();
            time.Start();


            TipoTest b;

            for (int i = 0; i <= 199; i++)
            {
                if (listaTest.ElementAt(i).Numero == 199)
                {
                    b = listaTest[i];
                    break;
                }
            }
            time.Stop();

            Console.WriteLine("Tiempo de demora con for = " + time.Elapsed);

            time.Reset();
            time.Start();

            foreach (TipoTest ti in listaTest)
            {
                if (ti.Numero == 199)
                {
                    b = ti;
                    break;
                }
            }

            time.Stop();
            Console.WriteLine("Tiempo de demora con foreach = " + time.Elapsed);
            Console.ReadKey();
        }

        public class TipoTest
        {
            private String nombre;

            public String Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }
            private int numero;

            public int Numero
            {
                get { return numero; }
                set { numero = value; }
            }
        }
    }
}
