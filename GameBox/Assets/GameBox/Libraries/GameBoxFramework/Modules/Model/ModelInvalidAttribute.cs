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
    /// 无效模型标记
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class ModelInvalidAttribute : BaseAttribute
    {

        public ModelInvalidAttribute() { }

    }
}