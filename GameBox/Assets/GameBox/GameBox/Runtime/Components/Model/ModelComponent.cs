/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;
using GameBoxFramework;
using GameBoxFramework.Model;
using UnityEngine;

namespace GameBox.Runtime.Component
{
    /// <summary>
    /// 数据模型组件
    /// </summary>
    [AddComponentMenu("GameBox/Model")]
    public sealed class ModelComponent : BaseGameBoxComponent
    {
        /// <summary>
        /// 数据模型接口
        /// </summary>
        private IModelManager m_IModelManager=null;

        /// <summary>
        /// 数据模型数量
        /// </summary>
        public int ModelCount { get { return null == m_IModelManager ? 0 : m_IModelManager.ModelCount; } }

        /// <summary>
        /// 所有模块的名字
        /// </summary>
        public string[] ModelNames { get { return null==m_IModelManager?null:m_IModelManager.ModelNames; } }

        /// <summary>
        /// 销毁数据模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void DestroyModel<T>() where T : BaseModel
        {
            m_IModelManager.RemoveModel<T>();
        }
        /// <summary>
        /// 销毁数据模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void DestroyModel(Type t_ModelType)
        {
            m_IModelManager.RemoveModel(t_ModelType);
        }
        /// <summary>
        /// 获取数据模型模型
        /// </summary>
        /// <typeparam name="T">BaseModel派生类</typeparam>
        public T GetModel<T>() where T : BaseModel
        {
           return  m_IModelManager.GetModel<T>();
        }
        /// <summary>
        /// 获取数据模型模型
        /// </summary>
        /// <typeparam name="T">BaseModel派生类</typeparam>
        public BaseModel GetModel(Type t_ModelType)
        {
            return m_IModelManager.GetModel(t_ModelType);
        }
        /// <summary>
        /// 判断模型是否是有效的
        /// </summary>
        /// <param name="t_ModelType">模型的Type类型</param>
        /// <returns></returns>
        public bool IsModelValid(Type t_ModelType)
        {
            return m_IModelManager.IsModelValid(t_ModelType);
        }
        /// <summary>
        /// 是否存在这有效模型
        /// </summary>
        /// <param name="t_ModelFullName">模型类型的FullName</param>
        /// <returns>如果有返回真</returns>
        public bool HasModel(string t_ModelFullName)
        {
            return m_IModelManager.HasModel(t_ModelFullName);
        }

        protected override void Awake()
        {
            base.Awake();
            m_IModelManager = GameBox.App.Driver.GetModule<IModelManager>();
            if (m_IModelManager == null)
            {
                throw new GameBoxFrameworkException("IModelManager是无效的.");
            }
        }








    }
}