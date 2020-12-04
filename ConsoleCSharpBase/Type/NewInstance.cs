using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCSharpBase
{
    public class NewInstance
    {
        public NewInstance()
        {
            Example();
        }

        private void Example()
        {
            var t = GetInstance2("ConsoleCSharpBase.ActRes");

            var t1 = Assembly.GetExecutingAssembly().CreateInstance("ConsoleCSharpBase.ActRes");

            //var t2 = typeof(t).GetMethod("EX1_1");


        }
        public object GetInstance(string strFullyQualifiedName)
        {
            Type t = Type.GetType(strFullyQualifiedName);
            return Activator.CreateInstance(t);
        }

        public object GetInstance2(string strFullyQualifiedName)
        {
            Type type = Type.GetType(strFullyQualifiedName);
            if (type != null)
                return Activator.CreateInstance(type);

            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = asm.GetType(strFullyQualifiedName);
                if (type != null)
                    return Activator.CreateInstance(type);
            }
            return null;
        }

    }
}
