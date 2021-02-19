using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitColorChange : MonoBehaviour
{
    public Material[] _material;           // 割り当てるマテリアル.
    private bool HitFlag;
    private int HitCount;
    // Start is called before the first frame update
    void Start()
    {
        HitFlag = false;
        HitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(HitFlag == true)
        {
            HitCount++;
            if(10 < HitCount)
            {
                gameObject.GetComponent<Renderer>().material = _material[1];
                HitCount = 0;
                HitFlag = false;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Bullet"))
        {
            HitFlag = true;
            gameObject.GetComponent<Renderer>().material = _material[0];
        }
    }

}
