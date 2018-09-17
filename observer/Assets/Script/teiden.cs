using UnityEngine;
using System.Collections;

public class teiden : MonoBehaviour
{
    GameObject target;
    public Camera activecamera;
    public float cameracode = 0;
    public GameObject obj2;
    Ray ray;
    public GameObject[] lightobj;
    public bool test;
    jairon jaoron;
    setumei Setumei;
    bool teidenbool = true;
    public GameObject BAKETU;
    Camerakirikae camerakirikae;
    public GameObject NEWBAKETU;
    public GameObject MIZU;
    public GameObject[] obj;
    public Transform moveposition;
    public GameObject player;
    public Light ligatgrean;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (teidenbool)
        {
            if (GetComponent<Camera>().enabled)
            {
                teidenbool = false;
                player.transform.position = moveposition.position;
                ligatgrean.enabled = false;
                //初めて自分がタッチされたとき
                //カメラの向aきによりカメラモードの変更を可能にする
                Screen.autorotateToLandscapeRight = true;
                Screen.autorotateToLandscapeLeft = true;
                StartCoroutine("teidensaseru");
            }
        }
    }
    public IEnumerator teidensaseru()
    {
        for (int i = 0; i < lightobj.Length; i++)
        {
            lightobj[i].SetActive(false);
        }
        teidenbool = false;
        yield return new WaitForSeconds(1f);
        iTween.RotateTo(BAKETU, iTween.Hash("x", -80, "islocal", true, "time", 0.1f));
        iTween.MoveBy(BAKETU, iTween.Hash("z", -0.03, "islocal", true, "time", 0.1f));
        NEWBAKETU.SetActive(true);
        MIZU.SetActive(false);
        yield return new WaitForSeconds(1f);
        for (int i = 0;i<obj.Length;i++)
        {
            obj[i].SetActive(true);
        }
    }
}
