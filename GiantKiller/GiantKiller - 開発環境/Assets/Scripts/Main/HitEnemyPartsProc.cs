using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemyPartsProc : MonoBehaviour
{
    private int HitCount;
    public bool CheckPos;
    public int FlagNo;
    void Start()
    {
        HitCount = 0;
        FlagNo = 0;
        CheckPos = false;
    }

    void Update()
    {
        if (HitCount == 10)
        {
            FlagNo = 1;
            HitCount = 0;
        }
        else
        { FlagNo = 0; }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Bullet"))
        {
            HitCount++;
        }
    }
}
