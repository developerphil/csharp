using System;
using TechTalk.SpecFlow;

namespace AnotherSpecflow.Steps
{
    [Binding]
    public class CommonSteps
    {
        [Given(@"I last made a calculation (.* days ago)")]
        public void GivenILastMadeACalculationDaysAgo(DateTime lastCalculation)
        {
            Console.WriteLine("Date - {0}", lastCalculation.ToShortDateString());
        }
    }
}
