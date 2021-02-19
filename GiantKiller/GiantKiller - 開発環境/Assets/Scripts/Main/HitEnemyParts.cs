using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemyParts : MonoBehaviour
{
    //その位置から攻撃できる部位と対応した場所を消すため.
    public GameObject PartsBreakDownPos;
    public int HitCount;
    void Start()
    {
        HitCount = 0;
    }

    void Update()
    {
        if (10 <= HitCount)
        {
            this.gameObject.SetActive(false);
            PartsBreakDownPos.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Bullet"))
        {
            HitCount++;
        }
    }

}
