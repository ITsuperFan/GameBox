/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

namespace GameBox.Extension
{
    /// <summary>
    /// GameBoxComponent扩展
    /// </summary>
    public static class GameBoxComponentExtension
    {
        /// <summary>
        /// 查找BaseGameBoxComponents数组中的指定条件的组件
        /// </summary>
        /// <typeparam name="T">GameBox组件类型</typeparam>
        /// <param name="t_BaseGameBoxComponents">BaseGameBoxComponents数组</param>
        /// <param name="t_Handler">指定条件的委托</param>
        /// <returns>BaseGameBoxComponents数组中满足条件委托的BaseGameBoxComponent</returns>
        public static T Find<T>(this T[] t_BaseGameBoxComponents, System.Func<T, bool> t_Handler) where T : BaseGameBoxComponent
        {
            for (int i = 0; i < t_BaseGameBoxComponents.Length; i++)
            {
                if (t_Handler(t_BaseGameBoxComponents[i]))
                {
                    return t_BaseGameBoxComponents[i];
                }
            }
            return null;
        }


    }


}