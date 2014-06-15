using System;
using System.Collections.Generic;
using AnotherSpecflow.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AnotherSpecflow.Transforms
{
    [Binding]
    public class CustomTransforms
    {
        [StepArgumentTransformation(@"(\d+) days ago")]
        public DateTime DaysAgoTransform(int daysAgo)
        {
            return DateTime.Today.AddDays(-daysAgo);
        }

        [StepArgumentTransformation]
        public IEnumerable<User> UserTransform(Table table)
        {
            return table.CreateSet<User>();
        }
    }
}
