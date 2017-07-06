/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

namespace GameBoxFramework.Utility
{
    public class ArrayHelper
    {
        private ArrayHelper() { }


        public static T[] SliceArray<T>(T[] t_Array, int t_StartIndex, int t_EndIndex)
        {
            if (0 > (t_EndIndex - t_StartIndex)) return null; //输入长度不对，创建数组会出错
            T[] t_NewArray = new T[t_EndIndex- t_StartIndex];
            if (null != t_Array)
            {
                if (t_Array.Length > t_StartIndex && t_Array.Length >= t_EndIndex)
                {
                    for (int i = 0; i < t_NewArray.Length; i++)
                    {
                        t_NewArray[i] = t_Array[ t_StartIndex>= t_EndIndex ? t_EndIndex: t_StartIndex++];
                    }
                    return t_NewArray;
                }
                else
                {
                    //数组输入的长度不对，已经超越了原有的长度
                    throw new GameBoxFrameworkException("数组输入的长度不对，已经超越了原有的长度!");
                }

            }
            else
            {
                //数组为空
                throw new GameBoxFrameworkException("数组为空!");

            }
        }

        public static T[] MergeArray<T>(T[] t_FirstArray, int t_FirstArrayStartIndex, int t_FirstArrayEndIndex, T[] t_SecondArray, int t_SecondArrayStartIndex, int t_SecondArrayEndIndex)
        {
            if (t_FirstArrayStartIndex >= t_FirstArrayEndIndex) return null;
            else if (t_SecondArrayStartIndex >= t_SecondArrayEndIndex) return null;
            else if (null==t_FirstArray) return null;
            else if (null==t_SecondArray) return null;

            T[] t_NewArray = new T[(t_FirstArrayEndIndex- t_FirstArrayStartIndex)+(t_SecondArrayEndIndex-t_SecondArrayStartIndex)];
            for (int i = 0; i < t_NewArray.Length; i++)
            {
                if (t_FirstArrayStartIndex < t_FirstArrayEndIndex)
                    t_NewArray[i] = t_FirstArray[t_FirstArrayStartIndex++];
                else if (t_SecondArrayStartIndex<t_SecondArrayEndIndex)
                    t_NewArray[i] = t_SecondArray[t_SecondArrayStartIndex++];
            }
            return t_NewArray;

        }


        public static T[] MergeArray<T>(params T[][] t_Params)
        {
            int t_TLength = 0;
            for (int i = 0; i < t_Params.Length; i++)
            {
                t_TLength += t_Params[i].Length;
            }
            T[] t_TargetArray =new T[t_TLength];
            int t_Index = 0;
            for (int i = 0; i < t_Params.Length; i++)
            {
                for (int j = 0; j < t_Params[i].Length; j++)
                {
                    t_TargetArray[t_Index++] = t_Params[i][j];
                }
            }
            return t_TargetArray;
        }


        public static T[] Copy<T>(T[] t_Target)
        {
            if (null== t_Target)
            {
                return null;
            }
            T[] t_NewTarget = new T[t_Target.Length];
            for (int i = 0; i < t_Target.Length; i++)
            {
                t_NewTarget[i] = t_Target[i];
            }
            return t_NewTarget;
        }


    }

}
