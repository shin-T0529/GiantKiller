using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreOpeProc : MonoBehaviour
{
    //攻撃場所の設定.
    public GameObject PreOpePanel11;
    public GameObject PreOpePanel12;
    public GameObject PreOpePanel13;

    public int SetAttackPlaneNo;
    private int AttackCount;
    public int value;
    public bool AttackStart;
    public bool AtkEnd;

    FadeSystem fadeSystem;

    ColorChange colorChange;
    HitEnemyHP hitEnemyHP;
    E_AttackSet e_AttackSet;

    void Start()
    {
        AtkEnd = false;
        AttackStart = false;
        SetAttackPlaneNo = 0;
        AttackCount = 0;
        value = 0;

        fadeSystem = gameObject.GetComponent<FadeSystem>();

        colorChange = gameObject.GetComponent<ColorChange>();
        hitEnemyHP = gameObject.GetComponent<HitEnemyHP>();
        e_AttackSet = gameObject.GetComponent<E_AttackSet>();

    }

    // Update is called once per frame
    void Update()
    {
        if (FadeSystem.BDead == 0)
        {
            if(e_AttackSet.Setvalue == 2)
            {
                AttackCount++;
                if (401 < AttackCount)
                {
                    //AtkEnd = true;
                    e_AttackSet.AttackSetCount = 0;
                    AttackCount = 0;
                    SetAttackPlaneNo = 0;
                }
                else if (400 < AttackCount)
                {
                    AttackStart = true;
                }
                else if (152 < AttackCount)
                {
                    SetAttackPlaneNo = value;
                }
                else if (150 < AttackCount)
                {
                    value = Random.Range(1, 7);
                    AttackCount = 203;
                }
                SwitchPreSetPos();
            }
            else
            {
                SetAttackPlaneNo = 0;
                AttackCount = 0;
                value = 0;
                SwitchPreSetPos();
            }
        }


    }

    void SwitchPreSetPos()
    {
        //対応番号の箇所に降らせる時の予備動作.
        //ここでは攻撃動作の処理はない.
        switch (SetAttackPlaneNo)
        {
            case 0:
                PreOpePanel11.SetActive(false);
                PreOpePanel12.SetActive(false);
                PreOpePanel13.SetActive(false);
                break;
            case 1:
                PreOpePanel11.SetActive(true);
                break;
            case 2:
                PreOpePanel12.SetActive(true);
                break;
            case 3:
                PreOpePanel13.SetActive(true);
                break;

            default:
                break;
        }
    }
}
