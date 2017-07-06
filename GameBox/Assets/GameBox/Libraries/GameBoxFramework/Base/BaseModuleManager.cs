/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


namespace GameBoxFramework
{
    /// <summary>
    /// 获取模块管家
    /// </summary>
    public abstract class BaseModuleManager
    {
        /// <summary>
        /// 抽象数据结构类型
        /// </summary>
        protected readonly IListDataStructure<BaseModule> IListDataStructure;

        /// <summary>
        /// 初始化 IListDataStructure 接口的构造方法
        /// </summary>
        /// <param name="t_IListDataStructure"></param>
        public BaseModuleManager(IListDataStructure<BaseModule> t_IListDataStructure)
        {
            IListDataStructure = t_IListDataStructure;
        }


    }
}