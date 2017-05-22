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
        protected readonly IMapDataStructure<string,BaseGameBoxComponent> IListDataStructure;

        /// <summary>
        /// 默认构造方法
        /// </summary>
        public BaseComponentManager():this()
        {

        }

        /// <summary>
        /// 初始化数据结构类型的构造方法
        /// </summary>
        /// <param name="t_IListDataStructure"></param>
        public BaseComponentManager(IMapDataStructure<string, BaseGameBoxComponent> t_IListDataStructure)
        {
            IListDataStructure = t_IListDataStructure;
        }

        /// <summary>
        /// 管理的模块数量
        /// </summary>
        public int ComponentsCount { get; protected set; }
        /// <summary>
        /// 管理的所有模块的名字数组
        /// </summary>
        public string[] ComponentNames { get; protected set; }

    }

}