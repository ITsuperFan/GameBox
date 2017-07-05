/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using GameBoxFramework.Utility;
using System;

namespace GameBoxFramework.Model
{
    /// <summary>
    /// 数据模型模块类
    /// </summary>
    internal sealed class ModelManager : BaseModule, IModelManager
    {

        /// <summary>
        /// 模型层类管理数据结构
        /// </summary>
        private readonly ModelSLinkedList ModelIListDataStructure = new ModelSLinkedList();
        /// <summary>
        /// 数据模型数量
        /// </summary>
        public int ModelCount
        {
            get
            {
                return ModelIListDataStructure.NodeCount;
            }
        }
        /// <summary>
        /// 所有模块的名字
        /// </summary>
        public string[] ModelNames { get { return TypeHelper.GetTypeFullNames<BaseModel>(); } }
        /// <summary>
        /// 获取数据模型模型
        /// </summary>
        /// <typeparam name="T">BaseModel派生类</typeparam>
        public T GetModel<T>()where T:BaseModel
        {
           return GetModel(typeof(T)) as T;
        }
        /// <summary>
        /// 获取数据模型模型
        /// </summary>
        /// <typeparam name="T">BaseModel派生类</typeparam>
        public BaseModel GetModel(Type t_ModelType)
        {
            var t_Models = ModelIListDataStructure.ToArray();
            var t_Length = t_Models.Length;
            for (int i = 0; i < t_Length; i++)
            {
                if (t_Models[i].GetType() == t_ModelType)
                {
                    return t_Models[i];
                }
            }
            var t_TargetModel = Activator.CreateInstance(t_ModelType) as BaseModel;
            t_TargetModel.OnInit(); //初始化
            t_TargetModel.OnStart();//启动
            ModelIListDataStructure.AddNode(t_TargetModel);
            return t_TargetModel;


        }
        /// <summary>
        /// 销毁数据模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void DestroyModel<T>() where T : BaseModel
        {
            DestroyModel(typeof(T));
        }
        /// <summary>
        /// 销毁数据模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void DestroyModel(Type t_ModelType)
        {
            ModelIListDataStructure.RemoveNode(model=>model.GetType()==t_ModelType);
        }

        #region 模块生命周期
        protected internal override void OnInit(IModuleManager t_IModuleManager)
        {
            var t_TypeFullNames = TypeHelper.GetTypeFullNames<BaseModel>();
            for (int i = 0; i < t_TypeFullNames.Length; i++)
            {
                var t_TargetModel = Activator.CreateInstance(Type.GetType(t_TypeFullNames[i])) as BaseModel;
                if(null!= t_TargetModel)
                ModelIListDataStructure.AddNode(t_TargetModel);
            }

            var t_Models = ModelIListDataStructure.ToArray();
            var t_Length = t_Models.Length;
            for (int i = 0; i < t_Length; i++)
            {
                   t_Models[i].OnInit();
            }

        }
        protected internal override void OnStart(IModuleManager t_IModuleManager)
        {
            var t_Models = ModelIListDataStructure.ToArray();
            var t_Length = t_Models.Length;
            for (int i = 0; i < t_Length; i++)
            {
                t_Models[i].OnStart();
            }
        }
        protected internal override void OnUpdate(IModuleManager t_IModuleManager)
        {
            var t_Models = ModelIListDataStructure.ToArray();
            var t_Length = t_Models.Length;
            for (int i = 0; i < t_Length; i++)
            {
                t_Models[i].OnUpdate();
            }
        }
        protected internal override void OnStop(IModuleManager t_IModuleManager)
        {
            var t_Models = ModelIListDataStructure.ToArray();
            var t_Length = t_Models.Length;
            for (int i = 0; i < t_Length; i++)
            {
                t_Models[i].OnStop();
            }
        }
        protected internal override void OnDestroy(IModuleManager t_IModuleManager)
        {
            var t_Models = ModelIListDataStructure.ToArray();
            var t_Length = t_Models.Length;
            for (int i = 0; i < t_Length; i++)
            {
                t_Models[i].OnStop();
            }
            ModelIListDataStructure.Clear();
        }
        #endregion

    }
}