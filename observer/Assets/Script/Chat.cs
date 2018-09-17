using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Chat : MonoBehaviour {

    //要素を追加するコンテント
    [SerializeField] RectTransform content;

    //生成する要素
    [SerializeField] RectTransform chatBack;

    [SerializeField] Text chatText;

    public string[] talk;
    public int currenttalk = 0;
    public stickset st;
    Image chatcolor;
    public Image haikei;
    public GameObject scroll;
    public jairon Jairon;
	public GameObject[] obj; 
    void Awake()
    {
        chatBack.gameObject.SetActive(false);
        haikei.enabled = false;
        scroll.SetActive(false);
    }

    void Start()
    {
        this.GetComponent<Canvas>().enabled = true;
        st.enabled = false;
        haikei.enabled = true;
        scroll.SetActive(true);
        chatcolor = chatBack.GetComponent<Image>();
        OnSubmit();
    }

   void Update()
    {
        
       if (Input.GetButtonDown("Fire1"))
        {
            if (currenttalk >= 9)
            {
                haikei.enabled = false;
                scroll.SetActive(false);
                st.enabled = true;
                this.GetComponent<Chat>().enabled = false;
                Jairon.enabled = true;
				for (int i = 0; i < obj.Length; i++) {
					obj [i].SetActive (false);
				}
            }
            else
            {
                OnSubmit();
            }
            
        }
      
    }
    
    public void OnSubmit()
    {
        switch (currenttalk)
        {
            case 0:
            case 2:
            case 3:
            case 5:
            case 7:
                chatcolor.color = new Color(1.0f, 1.0f, 1.0f);
                break;
            case 1:
            case 4:
            case 6:
            case 8:
                chatcolor.color = new Color(0.0f, 1.0f, 0.3f);
                break;

            default:
                
                break;


        }
        // 入力フィールドを元に複製元のデータを改変
        chatText.text = talk[currenttalk];
        currenttalk++;
       
        
        //content以下にchatBackを複製
        var element = GameObject.Instantiate<RectTransform>(chatBack);
        
        element.SetParent(content, false);
        element.SetAsLastSibling();
        element.gameObject.SetActive(true);
        
        
    }
}
