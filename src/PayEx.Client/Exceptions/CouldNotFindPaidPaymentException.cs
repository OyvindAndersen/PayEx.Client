using System;
using PayEx.Client.Models.Vipps;

namespace PayEx.Client.Exceptions
{
    public class CouldNotFindPaidPaymentException : Exception
    {
        private static readonly string Description = "Could not paid payment for the given id";

        public ProblemsContainer Problems { get; }
        public string Id { get; }

        public CouldNotFindPaidPaymentException(string id, ProblemsContainer problems) : base(problems.ToString())
        {
            Problems = problems;
            Id = id;
        }

        public CouldNotFindPaidPaymentException(string id) : base(Description)
        {
            Problems = new ProblemsContainer(nameof(id), Description);
            Id = id;
        }

        public CouldNotFindPaidPaymentException(string id, string name, string desc) : this(id, new ProblemsContainer(name, desc))
        {
            
        }

        public CouldNotFindPaidPaymentException(Exception inner) : base(Description, inner)
        {
            Problems = new ProblemsContainer("Other", Description);
        }
    }
}