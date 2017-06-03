/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework.Utility;
using UnityEngine;

namespace Alan
{
    public class PipeRenderHelper
    {

        /// <summary>
        /// 获取圆弧的顶点数
        /// </summary>
        /// <param name="R">圆的半径</param>
        /// <param name="A">弧形顺时针的第一个开始的点</param>
        /// <param name="B">弧形顺时针的第二个结束的点</param>
        /// <returns>顶点数组</returns>
        public static Vector2[] ArcVertex2(Vector2 o, float r, Vector2 s, Vector2 e, int vertexNumber)
        {
            if (vertexNumber <= 2)
            {
                throw new System.Exception("顶点数至少为3");
            }

            float t_SEDistance = Mathf.Abs(s.x - e.x);
            float t_MeanDistance = t_SEDistance / (vertexNumber - 1);
            Vector2[] t_Vertex2 = new Vector2[vertexNumber];
            t_Vertex2[0] = s;
            for (int i = 1; i < vertexNumber - 1; i++)
            {
                t_Vertex2[i] = CircleArcPoint(o, r, s.x + t_MeanDistance * i);

            }
            t_Vertex2[vertexNumber - 1] = e;
            return t_Vertex2;
        }

        /// <summary>
        /// 获取圆弧的顶点数
        /// </summary>
        /// <param name="R">圆的半径</param>
        /// <param name="A">弧形顺时针的第一个开始的点</param>
        /// <param name="B">弧形顺时针的第二个结束的点</param>
        /// <returns>顶点数组</returns>
        public static Vector3[] ArcVertex3(Vector2 o, float r, Vector2 s, Vector2 e, int vertexNumber)
        {
            Vector2[] t_Target = ArcVertex2(o, r, s, e, vertexNumber);
            Vector3[] t_Vertex3 = new Vector3[t_Target.Length];
            for (int i = 0; i < t_Target.Length; i++)
            {
                t_Vertex3[i] = t_Target[i];
            }
            return t_Vertex3;
        }

        /// <summary>
        /// 生成一个二维的圆
        /// </summary>
        /// <param name="o"></param>
        /// <param name="r"></param>
        /// <param name="vertexNumber"></param>
        /// <returns></returns>
        public static Vector2[] MakeVector2Circle(Vector2 o, float r, int vertexNumber)
        {
            var arcVertex = 2 * r / vertexNumber;
            Vector2[] v = new Vector2[vertexNumber];
            int t_Index = 0;

            for (int i = 0; i < vertexNumber / 2; i++)
            {
                v[t_Index++] = CircleArcPoint(o, r, (o.x + arcVertex));
            }
            for (int i = vertexNumber / 2; i < vertexNumber; i++)
            {
                var tt = CircleArcPoint(o, r, (o.x + arcVertex));
                v[t_Index++] = new Vector2(tt.x, -tt.y); ;
            }
            return v;
        }

        /// <summary>
        /// 生成一个三维的圆
        /// </summary>
        /// <param name="o"></param>
        /// <param name="r"></param>
        /// <param name="vertexNumber"></param>
        /// <returns></returns>
        public static Vector3[] MakeVector3Circle(Vector2 o, float r, int vertexNumber)
        {
            Vector2[] t_Target = MakeVector2Circle(o,r,vertexNumber);
            Vector3[] t_Vertex3 = new Vector3[t_Target.Length];
            for (int i = 0; i < t_Target.Length; i++)
            {
                t_Vertex3[i] = t_Target[i];
            }
            return t_Vertex3;
        }

        //public static Vector2[] AveArcVertex(Vector2 o, float r, Vector2 s, Vector2 e, int vertexNumber)
        //{
        //    if (vertexNumber <= 2)
        //    {
        //        throw new System.Exception("顶点数至少为3");
        //    }
        //    float t_Angle = Vector3.Angle(s-o,e-o);
        //    float t_MeanAngle = t_Angle / (vertexNumber - 1);
        //    Vector2[] t_Vertex = new Vector2[vertexNumber];
        //    t_Vertex[0] = s;
        //    for (int i = 1; i < vertexNumber - 1; i++)
        //    {
        //        float x = o.x + (s.x - o.x) * Mathf.Cos(t_MeanAngle) - (s.y - o.y) * Mathf.Sin(t_MeanAngle);
        //        float y = o.y + (s.x - o.x) * Mathf.Sin(t_MeanAngle) + (s.y - o.y) * Mathf.Cos(t_MeanAngle);
        //        t_Vertex[i] = new Vector2(x,y);
        //    }
        //    t_Vertex[vertexNumber - 1] = s;
        //    return t_Vertex;
        //}

        /// <summary>
        /// 通过x轴获取圆弧上的一个正y轴的坐标点
        /// </summary>
        /// <param name="o">圆心坐标</param>
        /// <param name="r">圆的半径</param>
        /// <param name="x">要求的圆弧上的点的x轴数值</param>
        /// <returns></returns>
        public static Vector2 CircleArcPoint(Vector2 o,float r,float x)
        {
            return new Vector2( x , (Mathf.Sqrt( Mathf.Pow(r, 2) - Mathf.Pow( (x - o.x) , 2 ) ) + o.y)); 
        }

        /// <summary>
        /// 由线生成深度面的顶点
        /// </summary>
        /// <param name="lineVertices">线的顶点</param>
        /// <param name="depth">深度</param>
        /// <returns></returns>
        public static Vector3[] DepthVertices(Vector3[] lineVertices,float depth)
        {
            var t_DepthVertices = new Vector3[lineVertices.Length];
            for (int i = 0; i < t_DepthVertices.Length; i++) 
            {
               t_DepthVertices[i] = lineVertices[i] + Vector3.forward * depth;
            }
            return t_DepthVertices;
        }

        /// <summary>
        /// 由面生成模型的顶点
        /// </summary>
        /// <param name="surfaceVertices"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3[] ModelVertices(Vector3[] surfaceVertices, float depth)
        {
            var t_ModelVertices = new Vector3[surfaceVertices.Length * 2];
            for (int i = 0; i < t_ModelVertices.Length; i++)
            {
                if (i < t_ModelVertices.Length / 2) //如果为前半部分那么直接赋值
                {
                    t_ModelVertices[i] = surfaceVertices[i];
                }
                else //如果为后半部分，那么加上深度值
                {
                    t_ModelVertices[i] = surfaceVertices[i- t_ModelVertices.Length / 2]  + Vector3.forward * depth;
                }
            }
            return t_ModelVertices;
        }

        /// <summary>
        /// 转换成自定义的模型顶点数组
        /// </summary>
        /// <param name="modelVertices"></param>
        /// <returns></returns>
        public static ModelVertex[] ToModelVertexArray(Vector3[] modelVertices)
        {
            ModelVertex[] t_ModelVertex = new ModelVertex[modelVertices.Length];
            for (int i = 0; i < modelVertices.Length; i++)
            {
                t_ModelVertex[i].vertexIndex = i; //索引
                t_ModelVertex[i].vertex = modelVertices[i]; //模型顶点
            }
            return t_ModelVertex;
        }

        /// <summary>
        /// 生成一段三角面
        /// </summary>
        /// <param name="modelVertex"></param>
        /// <returns></returns>
        public static int[] ModelTriangleSegment(ModelVertex[] modelVertex,bool isClockwise=false)
        {
            int[] t_TriangleArray = new int[(modelVertex.Length-2)*3];
            int t_Index = 0;
            for (int i = 0; i < modelVertex.Length; i++)
            {
                if (i < (modelVertex.Length / 2 - 1) ) //如果在第一层
                {
                    if (isClockwise) //顺时针
                    {
                        t_TriangleArray[t_Index++] = modelVertex[i].vertexIndex;
                        t_TriangleArray[t_Index++] = modelVertex[(modelVertex.Length / 2 + i)].vertexIndex;
                        t_TriangleArray[t_Index++] = modelVertex[(modelVertex.Length / 2 + i + 1)].vertexIndex;
                    }
                    else
                    {
                        t_TriangleArray[t_Index++] = modelVertex[i].vertexIndex;
                        t_TriangleArray[t_Index++] = modelVertex[(modelVertex.Length / 2 + i + 1)].vertexIndex;
                        t_TriangleArray[t_Index++] = modelVertex[(modelVertex.Length / 2 + i)].vertexIndex;
                    }

                }
                else if (i > modelVertex.Length / 2) //如果在第二层
                {
                    if (isClockwise)//顺时针
                    {
                        t_TriangleArray[t_Index++] = modelVertex[i].vertexIndex;
                        t_TriangleArray[t_Index++] = modelVertex[(i - modelVertex.Length / 2)].vertexIndex;
                        t_TriangleArray[t_Index++] = modelVertex[(i - modelVertex.Length / 2 - 1)].vertexIndex;
                    }
                    else
                    {
                        t_TriangleArray[t_Index++] = modelVertex[i].vertexIndex;
                        t_TriangleArray[t_Index++] = modelVertex[(i - modelVertex.Length / 2 - 1)].vertexIndex;
                        t_TriangleArray[t_Index++] = modelVertex[(i - modelVertex.Length / 2)].vertexIndex;
                    }

                }
            }
            return t_TriangleArray;
        }

        /// <summary>
        /// 切割模型顶点数组
        /// </summary>
        /// <param name="modelVertex"></param>
        /// <param name="segmentLength"></param>
        /// <param name="segment1"></param>
        /// <param name="segment2"></param>
        /// <returns></returns>
        public static ModelVertex[] SliceModelVertex(ModelVertex[] modelVertex,int segmentLength,int segment1 , int segment2)
        {
            segment1--;
            segment2--;
            var t_ModelVertexSliceArray1 = ArrayHelper.SliceArray<ModelVertex>(modelVertex, segmentLength * segment1, segmentLength * (segment1 + 1) );
            var t_ModelVertexSliceArray2 = ArrayHelper.SliceArray<ModelVertex>(modelVertex, segmentLength * segment2, segmentLength * (segment2 + 1) );
            return ArrayHelper.MergeArray<ModelVertex>(t_ModelVertexSliceArray1, t_ModelVertexSliceArray2);
        }

        /// <summary>
        /// 生成一个面
        /// </summary>
        /// <param name="modelVertices"></param>
        /// <param name="segmentLength"></param>
        /// <param name="segment1"></param>
        /// <param name="segment2"></param>
        /// <param name="isClockwise"></param>
        /// <returns></returns>
        public static int[] SurfaceTriangleSegment(Vector3[] modelVertices, int segmentLength, int segment1, int segment2, bool isClockwise = false)
        {
            ModelVertex[] modelVertex = ToModelVertexArray(modelVertices);
           return ModelTriangleSegment( SliceModelVertex(modelVertex, segmentLength,segment1,segment2),isClockwise);
        }

    }


    /// <summary>
    /// 模型顶点信息
    /// </summary>
    public struct ModelVertex
    {
        public ModelVertex(Vector3 vertex, int vertexIndex)
        {
            this.vertex = vertex;
            this.vertexIndex = vertexIndex;
        }

        /// <summary>
        /// 顶点位置信息
        /// </summary>
        public Vector3 vertex;

        /// <summary>
        /// 顶点对应在 Mesh.Vertex 里面的索引
        /// </summary>
        public int vertexIndex;

    }



}