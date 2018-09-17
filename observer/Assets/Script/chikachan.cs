using UnityEngine;
using System.Collections;

public class chikachan : MonoBehaviour {
    private float nextTime;
    public float interval = 1.0f;	// 点滅周期
    Light pointlight;
    public float rda;
    public float rdb;
    // Use this for initialization
    void Start()
    {
        
        nextTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime * Random.Range(rda, rdb))
        {
            gameObject.GetComponent<Light>().enabled = !gameObject.GetComponent<Light>().enabled;
            nextTime += interval;
        }
    }
}
