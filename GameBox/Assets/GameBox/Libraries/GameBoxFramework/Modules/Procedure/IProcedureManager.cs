/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using System;

namespace GameBoxFramework.Procedure
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
        /// 启动的第一个流程
        /// </summary>
        BaseProcedure BootProcedure { get; set; }

        /// <summary>
        /// 获取所有的流程
        /// </summary>
        BaseProcedure[] Procedures { get; }

        /// <summary>
        /// 添加流程
        /// </summary>
        /// <typeparam name="T">流程类型</typeparam>
        void AddProcedure<T>() where T : BaseProcedure;

        /// <summary>
        /// 添加流程
        /// </summary>
        /// <param name="t_ProcedureType">流程的Type类型</param>
        void AddProcedure(Type t_ProcedureType);

        /// <summary>
        /// 获取流程
        /// </summary>
        /// <typeparam name="T">流程类型</typeparam>
        /// <returns>流程实例</returns>
        T GetProcedure<T>() where T : BaseProcedure;

        /// <summary>
        /// 获取流程
        /// </summary>
        /// <param name="t_ProcedureType">流程的Type类型</param>
        /// <returns></returns>
        BaseProcedure GetProcedure(Type t_ProcedureType);

        /// <summary>
        /// 移除流程
        /// </summary>
        /// <typeparam name="T">流程类型</typeparam>
        void RemoveProcedure<T>() where T : BaseProcedure;


    }
}