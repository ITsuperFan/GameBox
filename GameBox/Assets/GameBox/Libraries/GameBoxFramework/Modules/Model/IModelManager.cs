/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;

namespace GameBoxFramework.Model
{
    /// <summary>
    /// 数据模型管家接口
    /// </summary>
    public interface IModelManager 
	{
        /// <summary>
        /// 数据模型数量
        /// </summary>
        int ModelCount { get; }
        /// <summary>
        /// 所有模块的名字
        /// </summary>
        string[] ModelNames { get; }
        /// <summary>
        /// 获取数据模型模型
        /// </summary>
        /// <typeparam name="T">BaseModel派生类</typeparam>
        T GetModel<T>()where T:BaseModel;
        /// <summary>
        /// 销毁数据模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void RemoveModel<T>() where T : BaseModel;
        /// <summary>
        /// 获取数据模型模型
        /// </summary>
        /// <typeparam name="T">BaseModel派生类</typeparam>
        BaseModel GetModel(Type t_ModelType);
        /// <summary>
        /// 销毁数据模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void RemoveModel(Type t_ModelType);
        /// <summary>
        /// 判断是否是有效的模型类
        /// </summary>
        /// <param name="t_ModelType">模型Type类型</param>
        /// <returns></returns>
        bool IsModelValid(Type t_ModelType);
        /// <summary>
        /// 是否存在这有效模型
        /// </summary>
        /// <param name="t_ModelFullName">模型类型的FullName</param>
        /// <returns>如果有返回真</returns>
        bool HasModel(string t_ModelFullName);
    }
}