/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


namespace GameBoxFramework.Runtime.Procedure
{
    /// <summary>
    /// 流程模块接口
    /// </summary>
	public interface IProcedureManager 
	{
        /// <summary>
        /// 当前的流程
        /// </summary>
        BaseProcedure CurrentProcedure { get; }

        /// <summary>
        /// 获取所有的流程
        /// </summary>
        BaseProcedure[] Procedures { get; }


        /// <summary>
        /// 设置第一个启动的流程
        /// </summary>
        /// <param name="t_BaseProcedure">流程实例</param>
        void SetBootProcedure<T>() where T: BaseProcedure;

        /// <summary>
        /// 添加流程
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void AddProcedure<T>() where T : BaseProcedure;

        void RemoveProcedure<T>() where T : BaseProcedure;
	}
}