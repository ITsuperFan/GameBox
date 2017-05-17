using System.Collections.Generic;

namespace GameBoxFramework.Utility
{
    public class ListHelper
    {
        public static List<T> Add<T>(List<T> t_TargetList,T t_Target)
        {
            if (t_TargetList.Contains(t_Target)) return t_TargetList;

            for (int i = 0; i < t_TargetList.Count; i++)
            {
                if (null==t_TargetList[i])
                {
                    t_TargetList[i] = t_Target;
                    return t_TargetList;
                }
            }
            t_TargetList.Add(t_Target);

            return t_TargetList;
        }


        public static List<T> Remove<T>(List<T> t_TargetList, T t_Target)
        {
            if (t_TargetList.Contains(t_Target)) t_TargetList.Remove(t_Target);
            return t_TargetList;
        }

    }
}
