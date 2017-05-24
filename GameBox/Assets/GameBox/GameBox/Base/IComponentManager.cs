/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


namespace GameBox
{
	public interface IComponentManager
    {  
        /// <summary>
        /// 管理的模块数量
        /// </summary>
        int ComponentsCount { get; }

        /// <summary>
        /// 管理的所有模块的名字数组
        /// </summary>
        string[] ComponentNames { get; }

        /// <summary>
        /// 获取GameBox的组件
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件</returns>
        T GetComponent<T>()where T:BaseGameBoxComponent;

        /// <summary>
        /// 获取GameBox的组件数组
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件数组</returns>
        T[] GetComponents<T>() where T : BaseGameBoxComponent;

        /// <summary>
        /// 注册GameBox的组件
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件</returns>
        void RegisterComponent(BaseGameBoxComponent t_BaseGameBoxComponent);

        /// <summary>
        /// 销毁指定的所有GameBox的组件
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件</returns>
        void DestroyComponents<T>() where T : BaseGameBoxComponent;

        /// <summary>
        /// 销毁指定的GameBox的组件
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件</returns>
        void DestroyComponent(BaseGameBoxComponent t_BaseGameBoxComponent);
    }

}