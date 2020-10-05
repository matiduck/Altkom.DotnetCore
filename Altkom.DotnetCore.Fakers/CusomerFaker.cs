using Altkom.DotnetCore.Models;
using Bogus;
using System;

namespace Altkom.DotnetCore.Fakers
{
    public class CusomerFaker : Faker<Customer>
    {
        public CusomerFaker()
        {
            RuleFor(p => p.Id, f => f.Random.Guid());
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.2f));
        }
    }
}
