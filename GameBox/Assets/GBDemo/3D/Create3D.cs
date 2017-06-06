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

        public float h1;
        public float H;
        public float R1;
        public float B;
        public float R2;

        public Vector3 C;
        public Vector3 O1;




        public Vector3[] m_VertexArray;

        public int[] m_TriangleArray;

        public Vector2[] m_UV;

        public Texture m_Texture;

        private MeshFilter m_MeshFilter;
        private MeshRenderer m_MeshRendere;
        private Mesh m_Mesh;
        private void Awake()
        {
            var lineVecs1 = PipeRenderHelper.ArcVertex3(Vector2.zero, 150f, new Vector2(-150f, 0), new Vector2(150f, 0), 100); //大
            var lineVecs2 = PipeRenderHelper.ArcVertex3(Vector2.zero, 100f, new Vector2(-100f, 0), new Vector2(100f, 0), 100); //小

            for (int i = 0; i < lineVecs2.Length; i++)
            {
                Debug.Log(lineVecs2[i]);
            }

            var lineVecs3 = PipeRenderHelper.DepthVertices(lineVecs1, 100f); //大 内
            var lineVecs4= PipeRenderHelper.DepthVertices(lineVecs2, 100); //小 内


            var mergeVecs5 = ArrayHelper.MergeArray<Vector3>(lineVecs1,lineVecs2,lineVecs3,lineVecs4);


            m_MeshFilter = gameObject.AddComponent<MeshFilter>();
            m_MeshRendere = gameObject.AddComponent<MeshRenderer>();
            m_Mesh = m_MeshFilter.mesh;
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




        private void Update()
        {
           


            //------------------计算模块


            R2 = (Mathf.Pow(B / 2, 2) / 2 + Mathf.Pow(h1, 2) / 2 - (B / 2) * R1)  / (h1 - R1);


            //------------------计算模块


        }

    }
}