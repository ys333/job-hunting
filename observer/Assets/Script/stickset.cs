using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;
public class stickset : MonoBehaviour {
	public RectTransform joystick;
    public RectTransform stickunder;
	public Camera main;
	Vector2 position;
    public int sticklimit;
	bool push=false;
    public bool ok = true;
	Touch touch;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
        if (Screen.orientation == ScreenOrientation.Portrait)
        {
		    if (Input.GetMouseButtonDown(0)&&ok) {
		    //クリックし始め
			    //position=Camera.main.ScreenToWorldPoint(Input.mousePosition);
                stickunder.position = Input.mousePosition;
			    joystick.position=Input.mousePosition;
			    position = Input.mousePosition;
			    //stick.CreateVirtualAxes ();
			    //stick.UpdateVirtualAxes(Input.mousePosition);
                Debug.Log("joystick"+joystick.localPosition);
			    Debug.Log("mouse"+Input.mousePosition);
			    if (0 == 0)
				    push = true;
		    }
		    if(Input.GetMouseButton(0)&&push){
                joystick.position = new Vector2(Mathf.Clamp(Input.mousePosition.x, position.x + sticklimit * -1, position.x + sticklimit),
                                                Mathf.Clamp(Input.mousePosition.y, position.y + sticklimit * -1, position.y + sticklimit));
                Vector2 move = position - new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                CrossPlatformInputManager.SetAxis("Horizontal",(move.x*-1)/30);
                CrossPlatformInputManager.SetAxis("Vertical", (move.y*-1)/30);
		    }
		    if (Input.GetMouseButtonUp(0)){
		    //指を離す
                ok = true;
			    push=false;
                CrossPlatformInputManager.SetAxis("Horizontal", 0);
                CrossPlatformInputManager.SetAxis("Vertical", 0);
			    joystick.localPosition=new Vector3(1000,1000,1000);
                stickunder.localPosition = new Vector3(1000, 1000, 1000);
		    }
        }
        else {
            ok = true;
            push = false;
            CrossPlatformInputManager.SetAxis("Horizontal", 0);
            CrossPlatformInputManager.SetAxis("Vertical", 0);
            joystick.localPosition = new Vector3(1000, 1000, 1000);
            stickunder.localPosition = new Vector3(1000, 1000, 1000);
        }
    }
}