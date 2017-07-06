using System;
using GameBoxFramework;
/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace GameBox.Runtime.Component
{
    public sealed class HttpMonoClient : MonoBehaviour, IHttpClient
    {
        public void Get(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            StartCoroutine(GetYield(t_HttpRequestData, t_HttpHandler));
        }

        public void Post(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            StartCoroutine(PostYield(t_HttpRequestData, t_HttpHandler));
        }

        private IEnumerator PostYield(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {

            //添加表单数据
            WWWForm t_WWWForm = new WWWForm();
            foreach (var formItem in t_HttpRequestData.Form)
            {
                t_WWWForm.AddField(formItem.Key, formItem.Value);
            }


            using (UnityWebRequest www = UnityWebRequest.Post(t_HttpRequestData.URL, t_WWWForm))
            {

                //设置头部数据
                if (null != t_HttpRequestData.Headers)
                    foreach (var headerItem in t_HttpRequestData.Headers)
                    {
                        www.SetRequestHeader(headerItem.Key, headerItem.Value); 
                    }

                yield return www.Send();
                if (www.isError)
                {
                    if (null != t_HttpHandler)
                        t_HttpHandler(this, new HttpEventArgs( HttpRequstType.Post ,t_HttpRequestData,
                            new HttpResponseData(
                                        www.responseCode,
                                        www.isError,
                                        www.error,
                                        null,
                                        string.Empty,
                                        www.GetResponseHeaders()
                            )));
                }
                else
                {
                    if (null != t_HttpHandler)
                        t_HttpHandler(this, new HttpEventArgs(HttpRequstType.Post ,t_HttpRequestData,
                            new HttpResponseData(
                                        www.responseCode,
                                        www.isError,
                                        www.error,
                                        www.downloadHandler.data,
                                        www.downloadHandler.text,
                                        www.GetResponseHeaders()
                            )));
                }
            }
        }


        /// <summary>
        /// 协同提交GET数据并接受返回值
        /// </summary>
        private IEnumerator GetYield(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            using (UnityWebRequest www = UnityWebRequest.Get(t_HttpRequestData.URL))
            {
                yield return www.Send();

                if (www.isError)
                {
                    if(null!= t_HttpHandler)
                        t_HttpHandler(this,new HttpEventArgs(HttpRequstType.Get, t_HttpRequestData,
                            new HttpResponseData(
                                        www.responseCode,
                                        www.isError,
                                        www.error,
                                        null,
                                        string.Empty,
                                        www.GetResponseHeaders()
                            )));
                }
                else
                {
                    if (null != t_HttpHandler)
                        t_HttpHandler(this, new HttpEventArgs(HttpRequstType.Get, t_HttpRequestData,
                            new HttpResponseData(
                                        www.responseCode,
                                        www.isError,
                                        www.error,
                                        www.downloadHandler.data,
                                        www.downloadHandler.text,
                                        www.GetResponseHeaders()
                            )));
                }
            }

        }









        #region 不常用，有待实现
        public void CONNECT(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            throw new GameBoxFrameworkException("不常用，有待实的接口方法");
        }

        public void COPY(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            throw new GameBoxFrameworkException("不常用，有待实的接口方法");
        }

        public void DELETE(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            throw new GameBoxFrameworkException("不常用，有待实的接口方法");
        }

        public void HEAD(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            throw new GameBoxFrameworkException("不常用，有待实的接口方法");
        }

        public void LOCK(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            throw new GameBoxFrameworkException("不常用，有待实的接口方法");
        }

        public void MKCOL(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            throw new GameBoxFrameworkException("不常用，有待实的接口方法");
        }

        public void MOVE(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            throw new GameBoxFrameworkException("不常用，有待实的接口方法");
        }

        public void OPTIONS(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            throw new GameBoxFrameworkException("不常用，有待实的接口方法");
        }

        public void PATCH(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            throw new GameBoxFrameworkException("不常用，有待实的接口方法");
        }



        public void PROPFIND(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            throw new GameBoxFrameworkException("不常用，有待实的接口方法");
        }

        public void PROPPATCH(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            throw new GameBoxFrameworkException("不常用，有待实的接口方法");
        }

        public void PUT(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            throw new GameBoxFrameworkException("不常用，有待实的接口方法");
        }

        public void TRACE(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            throw new GameBoxFrameworkException("不常用，有待实的接口方法");
        }

        public void UNLOCK(HttpRequestData t_HttpRequestData, GameBoxFramework.EventHandler t_HttpHandler)
        {
            throw new GameBoxFrameworkException("不常用，有待实的接口方法");
        }
        #endregion


    }
}