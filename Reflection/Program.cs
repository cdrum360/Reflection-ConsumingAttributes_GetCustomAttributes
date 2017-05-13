using System;

namespace Reflection
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class MyAttributeAttribute : Attribute
    {
        public string Description { get; set; }
        public string VersionNumber { get; set; }
        public string ReviewerId { get; set; }
        
        public MyAttributeAttribute(string desc, string ver)
        {
            Description = desc;
            VersionNumber = ver;
        }
    }
        
    [MyAttribute("Check it out", "3.1")]
    class MyClass { }   
  
    public class Program
    {
        static void Main()
        {
            Type t = typeof(MyClass);
            object[] attArr = t.GetCustomAttributes(false);
            foreach (Attribute a in attArr)
            {
                MyAttributeAttribute attr = a as MyAttributeAttribute;
                if (null != attr)
                {
                    Console.WriteLine("Description : {0}", attr.Description);
                    Console.WriteLine("Version Number : {0}", attr.VersionNumber);
                    Console.WriteLine("Reviewer ID : {0}", attr.ReviewerId);
                }
            }

            Console.ReadLine();
        }
     }

}

