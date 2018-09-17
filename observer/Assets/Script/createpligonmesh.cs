using UnityEngine;
using System.Collections;

public class createpligonmesh : MonoBehaviour {
    private Mesh mesh;
	private Light light;
    // Use this for initialization
    void Start()
    {
        light = GetComponent<Light>();
        mesh = new Mesh();
        Vector3[] newVertices = new Vector3[5];
        Vector2[] newUV = new Vector2[5];
        int[] newTriangles = new int[2 * 3];

        // 頂点座標の指定.
        newVertices[0] = new Vector3(0f, 0.0f, 0f);
        newVertices[1] = new Vector3(light.spotAngle * light.range / 50, -0.1f, light.range * 1.25f);
        newVertices[2] = new Vector3(light.spotAngle * -light.range / 50, -0.1f, light.range * 1.25f);
        newVertices[3] = new Vector3(light.spotAngle * light.range / 50, 0.1f, light.range * 1.25f);
        newVertices[4] = new Vector3(light.spotAngle * -light.range / 50, 0.1f, light.range * 1.25f);

        // UVの指定 (頂点数と同じ数を指定すること).
        newUV[0] = new Vector2(0.0f, 0.0f);
        newUV[1] = new Vector2(0.0f, 1.0f);
        newUV[2] = new Vector2(1.0f, 1.0f);
        newUV[1] = new Vector2(0.0f, -1.0f);
        newUV[2] = new Vector2(-1.0f, -1.0f);

        // 三角形ごとの頂点インデックスを指定.
        newTriangles[0] = 2;
        newTriangles[1] = 1;
        newTriangles[2] = 0;
        newTriangles[3] = 0;
        newTriangles[4] = 3;
        newTriangles[5] = 2;

        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        GetComponent<MeshFilter>().sharedMesh = mesh;
        GetComponent<MeshFilter>().sharedMesh.name = "myMesh";
   }
   
   // Update is called once per frame
   void Update () {

       transform.Rotate(new Vector3(0, 0, 60) * Time.deltaTime);
   }
}