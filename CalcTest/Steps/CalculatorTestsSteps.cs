using CalcTest.Views;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CalcTest.Steps
{
    [Binding]
    public class CalculatorTestsSteps
    {
        CalcView calc;

        [Given(@"calculator app is initialized")]
        public void GivenCalculatorAppIsInitialized()
        {
            AppInit.StartApp();
            calc = new CalcView();
        }

        [When(@"The (.*) number typed at the calculator")]
        public void WhenTheNumberTypedAtTheCalculator(double operand)
        {
            string num = operand.ToString();
            char[] number = num.ToCharArray();
            foreach (var item in number)
            {
                calc.TapOnButton(item.ToString());
            }
        }

        [When(@"I tap on substract button")]
        public void WhenITapOnSubstractButton()
        {
            calc.TapOnMinus();
        }

        [Then(@"I see (.*) number and substract operand at the input field")]
        public void ThenISeeNumberAndSubstractOperandAtTheInputField(double operand)
        {
            string newOperand = operand.ToString().Replace(".", ",");
            Assert.AreEqual("0" + newOperand + "-", calc.CalcViewText);
        }

        [Then(@"I see (.*) and (.*) numbers separated by substract operand")]
        public void ThenISeeAndNumbersSeparatedBySubstractOperand(double first, double second)
        {
            string firstNumber = first.ToString().Replace(".", ",");
            string secondNumber = second.ToString().Replace(".", ",");
            string expected = "0" + firstNumber + " - " + secondNumber;
            Assert.AreEqual(expected, calc.CalcViewText);
        }

        [When(@"I tap on equal button")]
        public void WhenITapOnEqualButton()
        {
            calc.TapOnEqual();
        }

        [Then(@"I see the (.*) of operation at the input field")]
        public void ThenISeeTheOfOperationAtTheInputField(double result)
        {
            Assert.AreEqual(result.ToString(), calc.CalcViewText);
        }



        // DIVISION
        [When(@"I tap on division button")]
        public void WhenITapOnDivisionButton()
        {
            calc.TapOnDivide();
        }

        [Then(@"I see (.*) and (.*) numbers separated by division operand")]
        public void ThenISeeAndNumbersSeparatedByDivisionOperand(double first, double second)
        {
            string firstNumber = first.ToString().Replace(".", ",");
            string secondNumber = second.ToString().Replace(".", ",");
            string expected = "0" + firstNumber + " / " + secondNumber;
            Assert.AreEqual(expected, calc.CalcViewText);
        }

        // DIvision on "0"
        [Then(@"I see informational error message")]
        public void ThenISeeInformationalErrorMessage()
        {
            Assert.AreEqual("Wrong input!", calc.CalcViewText);
        }


    }
}
