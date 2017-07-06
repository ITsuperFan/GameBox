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
    /// 抽象基础模型类
    /// </summary>
	public abstract class BaseModel :IComparable<BaseModel>
    {

        /// <summary>
        /// 模块的权值
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// 比较接口
        /// </summary>
        /// <param name="other">其他的模块</param>
        /// <returns>比较后的结果</returns>
        public int CompareTo(BaseModel other)
        {
            return this.Weight - other.Weight; //自身的权重 - 需要进行比较的权重  
        }


        /// <summary>
        /// 被初始化时的事件
        /// </summary>
        public virtual void OnInit() { }
        /// <summary>
        /// 被启动时的事件
        /// </summary>
        public virtual void OnStart() { }
        /// <summary>
        /// 被轮训时的事件
        /// </summary>
        public virtual void OnUpdate() { }
        /// <summary>
        /// 被停止时的事件
        /// </summary>
        public virtual void OnStop() { }
        /// <summary>
        /// 被销毁时的事件
        /// </summary>
        public virtual void OnDestroy() { }

    }
}