using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material[] _material;           // 割り当てるマテリアル.
    public bool AttackFlag;
    private int AttackCount;
    // Start is called before the first frame update
    void Start()
    {
        AttackFlag = false;
        AttackCount = 0;
        //PreOpePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ColorChangePreOpre();
    }

    void ColorChangePreOpre()
    {
        AttackCount++;
        if (AttackCount < 10)
        {
            gameObject.GetComponent<Renderer>().material = _material[0];
        }
        else if (AttackCount < 11 && AttackCount < 20)
        {
            gameObject.GetComponent<Renderer>().material = _material[1];
        }
        else if (20 < AttackCount)
        {
            AttackCount = 0;
        }


    }
    void OnTriggerEnter(Collider collider)
    {
    }
}
