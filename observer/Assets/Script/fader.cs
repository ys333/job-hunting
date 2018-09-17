using UnityEngine;
using System.Collections;

public class fader : MonoBehaviour {


    [SerializeField]
    Material m_Material;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, m_Material);
    }
}
