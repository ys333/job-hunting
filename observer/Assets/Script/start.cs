using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    public Sprite snaarashi;
    private Color originalColor;
    float a, b;
    float time;
    bool Fadeout = true;
    float z;
    public AudioSource se;
    bool seplay = false;

    public void Buttonpush()
    {
        if (Fadeout)
        {
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToLandscapeLeft = false;
            StartCoroutine("FadeOut");
            Fadeout = false;
        }


    }
    IEnumerator FadeOut()
    {
        AsyncOperation async = Application.LoadLevelAsync("stage1");//シーンのロード
        async.allowSceneActivation = false;//だがまだシーンの移動はしない
        iTween.MoveTo(gameObject, iTween.Hash("x", Screen.width / 2,  "y", Screen.height / 2, "time", 4.0f));
        yield return new WaitForSeconds(1.7f);
        iTween.ScaleTo(gameObject, iTween.Hash("x", 3, "y", 4, "time", 6.0f));
        Image img = transform.transform.FindChild("titleImage").gameObject.GetComponent<Image>();
        img.sprite = snaarashi;
        if (!seplay)
        {
            se.Play();
            seplay = true;
        }
        for (float i = 0; i <= 3 ;)
        {
            if(z == 180){
                z = 0;
            }
            else
            {
                z = 180;
            }

            img.transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));
            yield return new WaitForSeconds(0.05f);
            i += 0.05f;
        }
        async.allowSceneActivation = true;
    }
}

