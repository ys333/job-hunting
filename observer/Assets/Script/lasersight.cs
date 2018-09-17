using UnityEngine;
using System.Collections;

public class lasersight : MonoBehaviour
{
    public LineRenderer lineRenderer = null;
    void Start()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
        if (null != lineRenderer)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetVertexCount(2); // 点の数
        }
    }

    void Update()
    {
        RaycastHit hit;
        // 正規化して方向ベクトルを求める
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit))
        {

                if (null != lineRenderer)
            {
                //Instantiate(lineRenderer, hit.point, Quaternion.identity);
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);
            }
        }
    }
}