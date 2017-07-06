/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using GameBoxFramework;
using System.Collections.Generic;

namespace GameBox.Runtime.Component
{
    /// <summary>
    /// HTTP提交的请求数据
    /// </summary>
    public sealed class HttpRequestData
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_URL">URL</param>
        public HttpRequestData(string t_URL)
        {
            URL = t_URL;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_URL">URL</param>
        /// <param name="t_Headers">头部数据</param>
        /// <param name="t_Form">表单数据</param>
        public HttpRequestData(string t_URL,Dictionary<string, string> t_Form) : this(t_URL)
        {         
            Form = t_Form;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_URL">URL</param>
        /// <param name="t_Headers">头部数据</param>
        /// <param name="t_Form">表单数据</param>
        public HttpRequestData(string t_URL, Dictionary<string, string> t_Headers, Dictionary<string, string> t_Form) :this(t_URL, t_Form)
        {
            Headers = t_Headers;
        }

        /// <summary>
        /// 请求的URL地址
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// 头部数据
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// 提交的表单
        /// </summary>
        public Dictionary<string, string> Form { get; set; }

    }



}

