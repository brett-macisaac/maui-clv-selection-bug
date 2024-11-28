using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace colview_bug_tester.Classes
{
    public class StringXaml
    {
        public string Value { get; set; }

        public StringXaml(string pValue) { Value = pValue; }

        public override string ToString()
        {
            return Value;
        }
    }
}
