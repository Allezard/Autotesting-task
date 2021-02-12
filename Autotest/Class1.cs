using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace ProjectAddressbook
{
    public class UnitTest1
    {
        public void TestMethod1()
        {
            double firstDep = 1000;
            double bonus = 0.9;
            double totalBonus = firstDep + bonus;
            bool vipClien = false;

            if (firstDep > 1000 || vipClien)
            {
                _ = firstDep + bonus;
                Console.Out.Write("Вам начислен бонус в размере: " + totalBonus + "рублей.");
            }
            else
            {
                Console.Out.WriteLine("Для начисления бонуса сделайте депозит на сумму более " + firstDep + "рублей.");
            }
        }

    }
}
