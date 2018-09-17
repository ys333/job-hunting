using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetManager : MonoBehaviour {
    //[SerializeField]
    //private GameObject target;
    //[SerializeField]
    //private GameObject targetSet;

    private Manager tutManager;

    bool isHit;

    [SerializeField, Range(1, 2)]
    private int playerNum;

    [SerializeField]
    private int scorePoint;

    private Vector3 defRot;

    public enum TargetType
    {
        LINER,
        STOP
    }
    public TargetType type;

    TutorialPlayerData myPData;

    private void Start()
    {
        tutManager = GameObject.Find("Manager").GetComponent<Manager>();
        if (playerNum == 1)
        {
            myPData = tutManager.tutrialPlayer1;
        }
        else myPData = tutManager.tutrialPlayer2;

        defRot = transform.parent.localEulerAngles;

        switch (type)
        {
            case TargetType.LINER:
                Manager.Liner(transform);
                break;
            case TargetType.STOP:
                Manager.Stop();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(myPData.hitCount);
        if (myPData.hitCount >= 5) Invoke("ResetRotate",3f);
        //Debug.Log(transform.parent.name);
    }

    public void Rotate(){
        transform.parent.DOLocalRotate(new Vector3(defRot.x + 90, defRot.y, defRot.z), 0.5f);
    }

    public void ResetRotate(){
        Debug.Log("reset");
        isHit = false;
        transform.parent.DOLocalRotate(defRot, 0.5f);
        myPData.hitCount = 0;
    }

    //public void OnTriggerEnter(Collider col)
    //{
    //    if (isHit)
    //    {
    //        isHit = true;
    //        myPData.score += scorePoint;
    //        myPData.hitCount++;
    //        Rotate();
    //        tutManager.ScorePrint(myPData, playerNum);
    //    }
    //}

    public void HitBullet()
    {
        Debug.Log("HIT");
        if (!isHit)
        {
            isHit = true;
            myPData.score += scorePoint;
            myPData.hitCount++;
            Rotate();
            tutManager.ScorePrint(myPData, playerNum);
        }
    }

}
