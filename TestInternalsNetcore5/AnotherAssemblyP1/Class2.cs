using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherAssemblyP1
{
    public class Class2
    {
        internal string GetNameInternal() => this.GetType().Assembly.GetName().FullName;
        public string GetName() => GetNameInternal();
        public string GetClass1Name() => $"inside-class2:{new Class1().GetNameInternal()}";
    }
}
