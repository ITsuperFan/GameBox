/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

/*
        GET
        通过请求URI得到资源
        POST,
        用于添加新的内容
        PUT
        用于修改某个内容
        DELETE,
        删除某个内容
        CONNECT,
        用于代理进行传输，如使用SSL
        OPTIONS
        询问可以执行哪些方法
        PATCH,
        部分文档更改
        PROPFIND, (wedav)
        查看属性
        PROPPATCH, (wedav)
        设置属性
        MKCOL, (wedav)
        创建集合（文件夹）
        COPY, (wedav)
        拷贝
        MOVE, (wedav)
        移动
        LOCK, (wedav)
        加锁
        UNLOCK (wedav)
        解锁
        TRACE
        用于远程诊断服务器
        HEAD
        类似于GET, 但是不返回body信息，用于检查对象是否存在，以及得到对象的元数据
 */


using GameBoxFramework;

namespace GameBox.Runtime.Component
{

    /// <summary>
    /// HTTP客户端接口
    /// </summary>
    public interface IHttpClient 
	{
        #region HTTP协议
        #region 常用接口
        void Get(HttpRequestData t_HttpRequestData, EventHandler t_HttpHandler);
        void Post(HttpRequestData t_HttpRequestData, EventHandler t_HttpHandler);
        #endregion

        #region 不常用接口
        void PUT(HttpRequestData t_HttpRequestData, EventHandler t_HttpHandler);
        void HEAD(HttpRequestData t_HttpRequestData, EventHandler t_HttpHandler);
        void DELETE(HttpRequestData t_HttpRequestData, EventHandler t_HttpHandler);
        void CONNECT(HttpRequestData t_HttpRequestData, EventHandler t_HttpHandler);
        void OPTIONS(HttpRequestData t_HttpRequestData, EventHandler t_HttpHandler);
        void PATCH(HttpRequestData t_HttpRequestData, EventHandler t_HttpHandler);
        void PROPFIND(HttpRequestData t_HttpRequestData, EventHandler t_HttpHandler);
        void PROPPATCH(HttpRequestData t_HttpRequestData, EventHandler t_HttpHandler);
        void MKCOL(HttpRequestData t_HttpRequestData, EventHandler t_HttpHandler);
        void COPY(HttpRequestData t_HttpRequestData, EventHandler t_HttpHandler);
        void MOVE(HttpRequestData t_HttpRequestData, EventHandler t_HttpHandler);
        void LOCK(HttpRequestData t_HttpRequestData, EventHandler t_HttpHandler);
        void UNLOCK(HttpRequestData t_HttpRequestData, EventHandler t_HttpHandler);
        void TRACE(HttpRequestData t_HttpRequestData, EventHandler t_HttpHandler);
        #endregion
        #endregion

        #region HTTPS协议

        #endregion
    }












}