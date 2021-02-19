using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickControll : MonoBehaviour
{
    public static int Attack;
    public static int HP;

    public int Attack_in, HP_in, Max_in;
    static int Max;     //総合ポイント数.

    int MaxNo;
    void Start()
    {
        Max = Random.Range(3,6);
        MaxNo = Max;
        Attack = HP = 0;
        Attack_in = HP_in = Max_in = 0;
    }

    void Update()
    {
        Attack_in = Attack;
        HP_in = HP;
        Max_in = Max;

        Adjustment();
    }
    void Adjustment()
    {   //ポイントの上限下限調整.

        if (HP <= 0)
        { HP = 0; }
        if (Attack <= 0)
        { Attack = 0; }

        if (MaxNo < HP)
        { HP = MaxNo; }
        if (MaxNo < Attack)
        { Attack = MaxNo; }

        if (MaxNo <= Max)
        { Max = MaxNo; }
        if (Max <= 0)
        { Max = 0; }
    }
    public void AttackCountPlus()
    {
        if (0 < Max)
        {
            Attack++;
            Max--;
        }
    }

    public void AttackCountMinus()
    {
        if (0 <= Max)
        {
            if (Attack != 0)
            { Max++; }
            Attack--;
            if (Attack < -1)
            { Attack = 0; }
        }
    }

    public void HPCountPlus()
    {
        if (0 < Max)
        {
            HP++;
            Max--;
        }
    }

    public void HPCountMinus()
    {
        if (0 <= Max)
        {
            if (HP != 0)
            { Max++; }
            HP--;
            if (HP < -1)
            { HP = 0; }
        }
    }
    public static int GetHPSkill()
    {
        return HP;
    }

    public static int GetAtkSkill()
    {
        return Attack;
    }
}
