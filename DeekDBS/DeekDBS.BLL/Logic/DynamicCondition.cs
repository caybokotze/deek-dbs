using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DeekDBS.BLL.Logic
{
    public static class DynamicReflectiveConditions
    {
        public static bool Evalaute(string compare, string to)
        {
            if (compare.Equals(to))
                return true;

            return false;
        }

        public static bool Evaluate(string argument)
        {
            string source =
                @"
namespace Compare
{   
    public class Comparison
    {
        public bool Evaluator()
        {   
            if("+argument+@")
            {
                return true;
            }
            return false;
        }
    }
}";

            Dictionary<string, string> providerOptions = 
                new Dictionary<string, string>
            {
                {"CompilerVersion", "v3.5" }
            };

            CSharpCodeProvider provider = 
                new CSharpCodeProvider(providerOptions);

            var compilerParams = new CompilerParameters
            {
                GenerateInMemory = true,
                GenerateExecutable = false
            };

            CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, source);

            if(results.Errors.Count != 0)
            {
                throw new Exception("Err, something went horribly wrong.");
            }

            object o = results.CompiledAssembly.CreateInstance("Compare.Comparison");
            MethodInfo mi = o.GetType().GetMethod("Evaluator");
            mi.Invoke(o, null);

            return false;
        }
    }
}
