using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_PartsProc : MonoBehaviour
{
    HitEnemyParts hitEnemyParts;

    [SerializeField, Tooltip("狙ってる場所破棄オブジェクト")]
    public GameObject CenterLock;
    public GameObject LeftLock;
    public GameObject RightLock;

    public int HC_Count,HL_Count,HR_Count;
    public int FlagNo;

    void Start()
    {
        FlagNo = 0;
        hitEnemyParts = gameObject.GetComponent<HitEnemyParts>();
    }

    void Update()
    {
        HC_Count = CenterLock.GetComponent<HitEnemyParts>().HitCount;
        HL_Count = LeftLock.GetComponent<HitEnemyParts>().HitCount;
        HR_Count = RightLock.GetComponent<HitEnemyParts>().HitCount;

        CheckHitCount();
    }

    void CheckHitCount()
    {
        if (HC_Count == 10)
        {
            FlagNo = 1;
            HC_Count = 10;
        }
        else
        { FlagNo = 0; }


        if (HL_Count == 10)
        {
            FlagNo = 2;
            HL_Count = 10;
        }
        else
        { FlagNo = 0; }

        if (HR_Count == 10)
        {
            FlagNo = 3;
            HR_Count = 10;
        }
        else
        { FlagNo = 0; }

        if(HC_Count == 10 && HR_Count == 10
          && HL_Count == 10)
        {
            FlagNo = 4;
        }

    }
}
