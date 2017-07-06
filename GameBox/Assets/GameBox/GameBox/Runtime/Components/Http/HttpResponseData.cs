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
    /// HTTP响应数据
    /// </summary>
    public sealed class HttpResponseData
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_StatusCode">状态码</param>
        /// <param name="t_Data">返回的文本数据</param>
        public HttpResponseData(long t_StatusCode, bool t_IsError, string t_StringError  ,byte[] t_ByteData,string t_StringData, Dictionary<string, string> t_Headers)
        {
            StatusCode = t_StatusCode;
            IsError = t_IsError;
            StringError = t_StringError;
            ByteData = t_ByteData;
            StringData = t_StringData;
            Headers = t_Headers;
        }

        /// <summary>
        /// 请求数据是否有错误
        /// </summary>
        public bool IsError { get; private set; }

        public string StringError { get; private set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public long StatusCode { get; private set; }

        /// <summary>
        /// 服务器返回的二进制数据
        /// </summary>
        public byte[] ByteData { get; private set; }

        /// <summary>
        /// 服务器返回的文本数据
        /// </summary>
        public string StringData { get; private set; }

        /// <summary>
        /// 头部数据
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

    }


}