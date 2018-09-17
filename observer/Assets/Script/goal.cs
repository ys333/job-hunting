using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour {
    public GameObject mayoibi;
    public GameObject[] obj;
    public Image[] image;
    GameObject player;
    public RawImage damage;
    public GameObject maincamera;
    public Texture sunaarasi;
    public Text sankyu;
    // Use this for initialization
    AudioSource[] bgm;

    void Start()
    {
        bgm = gameObject.GetComponents<AudioSource>();
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.tag);
        if (col.gameObject.tag == "Player")
        {
            Screen.autorotateToLandscapeRight = true;
            Screen.autorotateToLandscapeLeft = true;
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i].SetActive(false);
            }
            for (int i = 0; i < image.Length; i++)
            {
                image[i].enabled=false;
            }
            player = col.gameObject;
            maincamera.GetComponent<jairon>().enabled = false;
            player.GetComponent<Camerakirikae>().enabled = false;
            player.GetComponent<PLstatus>().HP = 100;
            player.GetComponent<PLstatus>().enabled = false;
            StartCoroutine("finish");
        }

    }
    public IEnumerator finish()
    {
        yield return new WaitForSeconds(1f);
        iTween.RotateTo(maincamera, iTween.Hash("y", -90, "islocal", true, "time", 2f));
        yield return new WaitForSeconds(4f);
        mayoibi.SetActive(true);
        mayoibi.transform.LookAt(player.transform);
        iTween.RotateTo(maincamera, iTween.Hash("y", 20, "islocal", true, "time", 1.4f));
        damage.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.1f);
        damage.texture = sunaarasi;
        bgm[0].Play();
        StartCoroutine("suna");
        yield return new WaitForSeconds(2f);
        sankyu.enabled = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("title");
    }
    IEnumerator suna()
    {
        bool a = true;
        int z = 0;
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

            damage.transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));
            yield return new WaitForSeconds(0.05f);
        }
    }
}
