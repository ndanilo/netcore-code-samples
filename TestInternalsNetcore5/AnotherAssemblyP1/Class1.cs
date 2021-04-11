using System;

namespace AnotherAssemblyP1
{
    public class Class1
    {
        internal string GetNameInternal() => this.GetType().Assembly.GetName().FullName;
        public string GetName() => $"public-name:{GetNameInternal()}";
    }
}
