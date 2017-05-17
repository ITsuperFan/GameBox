
namespace GameBoxFramework.Utility
{
	public class FactoryHelper 
	{

        public static T Create<T>(string t_ClassName, string t_ClassNameSpace) where T:class
        {
            return System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(t_ClassNameSpace + "." + t_ClassName) as T;

        }

        public static T Create<T>(string t_ClassFullName) where T : class
        {
            return System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(t_ClassFullName) as T;

        }


    }
}