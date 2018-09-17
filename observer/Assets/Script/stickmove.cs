using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
	public class stickmove : MonoBehaviour {
		public GameObject stick;
        public RectTransform stick2;
        Joystick joy;
		int push = 1;
		RectTransform rect;
		// Use this for initialization
		void Start () {
			rect = stick.GetComponent<RectTransform> ();
			joy = stick.GetComponent<Joystick> ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		public void buttonpush(){
			switch (push) {
			case 0:
				push = 1;
				rect.localPosition = new Vector3 (0, rect.localPosition.y, 0);
                stick2.localPosition = new Vector3(0, rect.localPosition.y, 0);
                break;
			case 1:
				push = 2;
				rect.localPosition =new Vector3(300,rect.localPosition.y,0);
                stick2.localPosition = new Vector3(300, rect.localPosition.y, 0);
                break;
			case 2:
				push = 0;
				rect.localPosition =new Vector3(-300,rect.localPosition.y,0);
                stick2.localPosition = new Vector3(-300, rect.localPosition.y, 0);
                break;
			}
			joy.m_StartPos = rect.transform.position;
		}
	}
}
