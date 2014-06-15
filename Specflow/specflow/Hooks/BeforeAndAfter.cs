using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Specflow.Hooks
{
    [Binding]
    public class BeforeAndAfter
    {
        //Only Tag test
        [BeforeScenario("test")]
        public void BeforeScenario1()
        {
            Console.WriteLine("Before Scenario1 ({0})", ScenarioContext.Current.ScenarioInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario2()
        {
            Console.WriteLine("Before Scenario2 ({0})", ScenarioContext.Current.ScenarioInfo.Title);

            if (ScenarioContext.Current.ScenarioInfo.Tags.ToList().Contains("test"))
            {
                Console.WriteLine("Only Run for test tag ({0})", ScenarioContext.Current.ScenarioInfo.Title);
            }
        }

        [BeforeScenarioBlock]
        public void BeforeScenarioBlock()
        {
            //Console.WriteLine("Before Scenario ({0})", ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("After Scenario ({0})", ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenarioBlock]
        public void AfterScenarioBlock()
        {
            //Console.WriteLine("After Scenario ({0})", ScenarioContext.Current.ScenarioInfo.Title);
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            Console.WriteLine("Before Feature ({0})", FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("After Feature ({0})", FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeStep]
        public static void BeforeStep()
        {
            //Console.WriteLine("Before Step");
        }

        [AfterStep]
        public static void AfterStep()
        {
            //Console.WriteLine("After Step");
        }
    }
}
