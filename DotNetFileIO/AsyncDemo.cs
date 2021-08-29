using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetFileIO
{
    class AsyncDemo
    {
        static void Main(string[] args)
        {
            //fire bullet and wait for damage values
            Console.WriteLine("Bullet fired");
            DamageDone();
            Console.WriteLine("Bullet fired");
            DamageDone();
            Console.WriteLine("Bullet fired");
            DamageDone();


            Console.ReadLine();
        }
        static int CalculateDamage()
        {
            //calculate damage value 
            Thread.Sleep(2000);
            return 100;
        }

        public static async void DamageDone()
        {
            int damageValue = await Task.Run(() => CalculateDamage());
            Console.WriteLine(damageValue);
        }
    }
    
}
