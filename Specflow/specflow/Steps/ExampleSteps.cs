using System;
using System.Collections.Generic;
using System.Linq;
using AnotherSpecflow.Models;
using NUnit.Framework;
using Specflow.Context;
using TechTalk.SpecFlow;

namespace Specflow.Steps
{
    [Binding]
    public class ExampleSteps
    {
        private readonly SharedContext _sharedContext;
        private List<User> _users;

        public ExampleSteps(SharedContext sharedContext)
        {
            _sharedContext = sharedContext;
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int value)
        {
            _sharedContext.Sum += value;
        }

        [When(@"I press add")]
        [Scope(Scenario = "Add two numbers")]
        public void WhenIPressAdd()
        {
            Console.WriteLine("Add button pressed (ExampleSteps)");
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int value)
        {
            Assert.That(_sharedContext.Sum, Is.EqualTo(value));
        }

        [Given(@"I have a number of users in a group")]
        public void GivenIHaveANumberOfUsersInAGroup(IEnumerable<User> users)
        {
            _users = users.ToList();
        }

        [Given(@"I have a number of users in a group dynamic")]
        public void GivenIHaveANumberOfUsersInAGroupDynamic(IEnumerable<dynamic> users)
        {
            var user = users.First();

            Console.WriteLine(user.FirstName);
        }

        [When(@"I delete a user")]
        public void WhenIDeleteAUser()
        {
            _users.RemoveAt(1);
        }

        [Then(@"I have one user in the group")]
        public void ThenIHaveOneUserInTheGroup()
        {
            Assert.That(_users.Count(), Is.EqualTo(1));
        }

    }
}
