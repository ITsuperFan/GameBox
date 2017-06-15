/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using GameBoxFramework;

namespace GameBox.Runtime.Component
{
    /// <summary>
    /// HTTP事件参数
    /// </summary>
    public sealed class HttpEventArgs : BaseEventArgs 
	{
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_HttpRequestData">HTTP请求数据</param>
        /// <param name="t_HttpResponseData">HTTP响应数据</param>
        public HttpEventArgs(HttpRequstType t_HttpRequstType,HttpRequestData t_HttpRequestData, HttpResponseData t_HttpResponseData)
        {
            HttpRequstType = t_HttpRequstType;
            HttpRequestData  = t_HttpRequestData;
            HttpResponseData = t_HttpResponseData;
        }
        public HttpRequstType HttpRequstType { get; private set; }

        /// <summary>
        /// HTTP请求数据
        /// </summary>
        public HttpRequestData HttpRequestData { get; private set; }
        /// <summary>
        /// HTTP响应数据
        /// </summary>
        public HttpResponseData HttpResponseData { get; private set; }


    }
}