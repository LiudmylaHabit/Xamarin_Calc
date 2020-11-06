using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcTest.Views;
using NUnit.Framework;

namespace CalcTest
{
    public class TestCalculator
    {
        CalcView calc = new CalcView();
        [SetUp]
        public void BeforeEveryTestOpenApplication()
        {
            AppInit.StartApp();
        }


        [Test(Description = "Checking reaction on zero division")]
        public void DivisionOnZero()
        {
            calc.TapOnFour().TapOnThree().TapOnButton("0")
                .TapOnButton("/").TapOnButton("0").TapOnEqual();
            Assert.AreEqual("Wrong input!", calc.CalcViewText);
        }

        [TestCase(2, "9.99999998E+17")]
        [TestCase(3, "9.99999997E+26")]
        [TestCase(4, "9.99999996E+35")]
        [TestCase(5, "9.99999995E+44")]
        [TestCase(6, "9.99999994E+53")]
        [TestCase(10, "9.9999999E+89")]
        public void WorkWithBigNumbers(int count, string result)
        {
            for (int i = 0; i < count; i++)
            {
                calc.TapOnNine().TapOnNine().TapOnNine().
                    TapOnNine().TapOnNine().TapOnNine()
                    .TapOnNine().TapOnNine().TapOnNine();
                if (i != (count - 1)) calc.TapOnButton("*");
            }
            calc.TapOnEqual();
            Assert.AreEqual(result, calc.CalcViewText);
        }
    }
}
