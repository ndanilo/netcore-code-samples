using AnotherAssemblyP1;
using System;

namespace AnotherAssemblyP2
{
    public class P2Class1
    {
        internal string GetNameInternal() => this.GetType().Assembly.GetName().FullName;
        public string GetName() => GetNameInternal();
        public string GetClass1Name() => new Class1().GetName();
    }
}
