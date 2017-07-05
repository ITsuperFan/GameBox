/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

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