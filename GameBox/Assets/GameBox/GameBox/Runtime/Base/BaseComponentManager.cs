/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework;

namespace GameBox
{
	public abstract class BaseComponentManager 
	{

        /// <summary>
        /// 抽象数据结构类型
        /// </summary>
        protected readonly IListDataStructure<IComponent> IListDataStructure;

        /// <summary>
        /// 初始化数据结构类型的构造方法
        /// </summary>
        /// <param name="t_IListDataStructure"></param>
        public BaseComponentManager(IListDataStructure<IComponent> t_IListDataStructure)
        {
            IListDataStructure = t_IListDataStructure;
        }


    }

}