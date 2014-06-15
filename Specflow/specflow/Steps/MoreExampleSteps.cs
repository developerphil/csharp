using System;
using Specflow.Context;
using TechTalk.SpecFlow;

namespace Specflow.Steps
{
    [Binding]
    public class MoreExampleSteps : TechTalk.SpecFlow.Steps
    {
        private readonly SharedContext _sharedContext;

        public MoreExampleSteps(SharedContext sharedContext)
        {
            _sharedContext = sharedContext;
        }

        //And Scope Restriction
        [Given(@"I add together numbers")]
        [Scope(Scenario = "Add numbers", Tag = "anothertest")]
        public void GivenIAddTogetherNumbers()
        {
            Given(string.Format("I have entered {0} into the calculator", 30));
            Given(string.Format("I have entered {0} into the calculator", 40));
            _sharedContext.Sum += 20;
        }

        //Or Scope Restriction
        [When(@"I press add")]
        [Scope(Scenario = "Add numbers")]
        [Scope(Tag = "anothertest")]
        public void WhenIPressAdd()
        {
            Console.WriteLine("Add button pressed (MoreExampleSteps)");
        }


    }
}
