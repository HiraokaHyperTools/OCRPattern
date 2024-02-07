using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRPattern.Tests.Utils
{
    internal class OnStated
    {
        public OnStated(string name, string state)
        {
            Name = name;
            State = state;
        }

        public OnStated Ensure(string expectedState, string newState)
        {
            if (expectedState != State)
            {
                throw new Exception($"Unexpected state of {Name}: {State} must be {expectedState}");
            }

            State = newState;

            return this;
        }

        public string Name { get; }
        public string State { get; private set; }
    }
}
