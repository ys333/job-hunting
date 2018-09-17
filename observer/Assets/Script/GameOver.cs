using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    RawImage image;
    public Texture sunaarasi;
    bool a = false;
    int z;
    int deadpatrun;
    public GameObject onicol;
    public GameObject onicol2;
    Camerakirikae camerakirikae;
    // Use this for initialization
    void Start()
    {
        image = GameObject.Find("RawImage").GetComponent<RawImage>();
        StartCoroutine("dead");
    }
    IEnumerator dead()
    {
        GetComponent<Camerakirikae>().Playermode = true;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToPortraitUpsideDown = false;
        image.texture = sunaarasi;
        a = true;
        StartCoroutine("suna");
        yield return new WaitForSeconds(4f);
        Application.LoadLevel("gameover");
    }
    IEnumerator suna()
    {
        while (a)
        {
            if (z == 180)
            {
                z = 0;
            }
            else
            {
                z = 180;
            }
            image.transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));
            yield return new WaitForSeconds(0.05f);
        }
        SceneManager.LoadScene("gameover");
    }
}
