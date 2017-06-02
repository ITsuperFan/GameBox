/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

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
            m_MeshFilter = gameObject.AddComponent<MeshFilter>();
            m_MeshRendere = gameObject.AddComponent<MeshRenderer>();



           var Vecs =  PipeRenderHelper.ArcVertex3(Vector2.zero,150f,new Vector2(-150f, 0),new Vector2(150f, 0),100);

            for (int i = 0; i < Vecs.Length; i++)
            {
                GameObject go = GameObject.CreatePrimitive( PrimitiveType.Cube );
                go.name = i.ToString();
                go.transform.position = new Vector3(Vecs[i].x,Vecs[i].y,0);
            }

            var Vecs1 = PipeRenderHelper.ArcVertex3(Vector2.zero, 100f, new Vector2(-100f, 0), new Vector2(100f, 0), 100);

            for (int i = 0; i < Vecs1.Length; i++)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.name = i.ToString();
                go.transform.position = new Vector3(Vecs1[i].x, Vecs1[i].y, 0);
            }


            m_Mesh = m_MeshFilter.mesh;
            m_Mesh.vertices = GameBoxFramework.Utility.ArrayHelper.MergeArray<Vector3>(Vecs,0,Vecs.Length,Vecs1,0,Vecs1.Length);
            m_UV = new Vector2[m_Mesh.vertexCount];
            m_Mesh.uv = m_UV;
            m_TriangleArray = new int[(Vecs.Length+Vecs1.Length - 2)*3];

            int t_Index=0;
            
            for (int i = 0; i < m_Mesh.vertexCount; i++)
            {
                if (i < (m_Mesh.vertexCount / 2 - 1)) //如果在第一层
                {
                    m_TriangleArray[t_Index++] = i;
                    m_TriangleArray[t_Index++] = m_Mesh.vertexCount / 2 + i+1;
                    m_TriangleArray[t_Index++] = m_Mesh.vertexCount / 2 + i;
                }
                else if (i > m_Mesh.vertexCount / 2) //如果在第二层
                {
                    m_TriangleArray[t_Index++] = i;
                    m_TriangleArray[t_Index++] = i-m_Mesh.vertexCount / 2 -1 ;
                    m_TriangleArray[t_Index++] = i-m_Mesh.vertexCount / 2;
                }
            }

        }

        private void Update()
        {
            m_Mesh.triangles = m_TriangleArray;
            m_Mesh.RecalculateNormals();


            Material t_Material = new Material(Shader.Find(@"Diffuse"));

            t_Material.mainTexture = m_Texture;

            m_MeshRendere.materials = new Material[] { t_Material };



            //------------------计算模块


            R2 = (Mathf.Pow(B / 2, 2) / 2 + Mathf.Pow(h1, 2) / 2 - (B / 2) * R1)  / (h1 - R1);


            //------------------计算模块


        }

    }
}