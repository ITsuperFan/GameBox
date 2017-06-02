/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

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
        public static Vector2[] ArcVertex2(Vector2 o,float r,Vector2 s,Vector2 e,int vertexNumber)
        {
            if (vertexNumber <= 2)
            {
                throw new System.Exception("顶点数至少为3");
            }
            float t_SEDistance = Mathf.Abs(s.x-e.x);
            float t_MeanDistance = t_SEDistance / (vertexNumber - 1);
            Vector2[] t_Vertex2 = new Vector2[vertexNumber];
            t_Vertex2[0] = s;
            for (int i = 1; i < vertexNumber-1; i++)
            {
                t_Vertex2[i] = CircleArcPoint(o,r,s.x+t_MeanDistance*i);

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
            Vector2[] t_Target = ArcVertex2(o,r,s,e,vertexNumber);
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

        
    }
}