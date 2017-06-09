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


    public class Create3D : MonoBehaviour 
	{
        [HideInInspector]
        public float h1;
        [HideInInspector]
        public float H;
        [HideInInspector]
        public float R1;
        [HideInInspector]
        public float B;
        [HideInInspector]
        public float R2;

        [HideInInspector]
        public Vector3 C;
        [HideInInspector]
        public Vector3 O1;



        [HideInInspector]
        public Vector3[] m_VertexArray;
        [HideInInspector]
        public int[] m_TriangleArray;
        [HideInInspector]
        public Vector2[] m_UV;
        [HideInInspector]
        public Texture m_Texture;

        private MeshFilter m_MeshFilter;
        private MeshRenderer m_MeshRendere;
        private Mesh m_Mesh;

        public float m_R=100f;

        public float m_InsideHeight=50f;

        public float m_Depth=100f;


        private void Awake()
        {
            m_MeshFilter = gameObject.AddComponent<MeshFilter>();
            m_MeshRendere = gameObject.AddComponent<MeshRenderer>();
            m_Mesh = m_MeshFilter.mesh;
            
        }

        private void Update()
        {
            var lineVecs1 = PipeRenderHelper.ArcVertex3(Vector2.zero, m_R+ m_InsideHeight, new Vector2(-(m_R + m_InsideHeight), 0), new Vector2(m_R + m_InsideHeight, 0), 100); //大
            var lineVecs2 = PipeRenderHelper.ArcVertex3(Vector2.zero, m_R, new Vector2(-m_R, 0), new Vector2(m_R, 0), 100); //小
            var lineVecs3 = PipeRenderHelper.DepthVertices(lineVecs1, m_Depth); //大 内
            var lineVecs4= PipeRenderHelper.DepthVertices(lineVecs2, m_Depth); //小 内
            var mergeVecs5 = ArrayHelper.MergeArray<Vector3>(lineVecs1,lineVecs2,lineVecs3,lineVecs4);

            m_Mesh.vertices = mergeVecs5;
            m_UV = new Vector2[m_Mesh.vertexCount];
            m_Mesh.uv = m_UV;
            Material t_Material = new Material(Shader.Find(@"Diffuse"));
            t_Material.mainTexture = m_Texture;
            m_MeshRendere.materials = new Material[] { t_Material };

            int[] t_TriangleSegment1 = PipeRenderHelper.SurfaceTriangleSegment(m_Mesh.vertices, lineVecs1.Length,1,2,false);
            int[] t_TriangleSegment2 = PipeRenderHelper.SurfaceTriangleSegment(m_Mesh.vertices, lineVecs1.Length,1,3,true);
            int[] t_TriangleSegment3 = PipeRenderHelper.SurfaceTriangleSegment(m_Mesh.vertices, lineVecs1.Length,2,4,false);
            int[] t_TriangleSegment4 = PipeRenderHelper.SurfaceTriangleSegment(m_Mesh.vertices, lineVecs1.Length,3,4,true);
            m_TriangleArray = ArrayHelper.MergeArray<int>(t_TriangleSegment1, t_TriangleSegment2, t_TriangleSegment3, t_TriangleSegment4);
            m_Mesh.triangles = m_TriangleArray;
            m_Mesh.RecalculateNormals();


        }




        //private void Update()
        //{
           


        //    //------------------计算模块


        //    R2 = (Mathf.Pow(B / 2, 2) / 2 + Mathf.Pow(h1, 2) / 2 - (B / 2) * R1)  / (h1 - R1);


        //    //------------------计算模块


        //}

    }
}