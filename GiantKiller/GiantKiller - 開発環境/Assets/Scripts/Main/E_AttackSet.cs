using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_AttackSet : MonoBehaviour
{
    public int Setvalue;
    public bool EndAttack;
    public int AttackSetCount;

    FadeSystem fadeSystem;

    HitEnemyHP hitEnemyHP;
    EnemyAttack enemyAttack;
    PreOpeProc preOpeProc;

    void Start()
    {
        Setvalue = 0;
        AttackSetCount = 0;

        fadeSystem = gameObject.GetComponent<FadeSystem>();

        hitEnemyHP = gameObject.GetComponent<HitEnemyHP>();
        enemyAttack = gameObject.GetComponent<EnemyAttack>();
        preOpeProc = gameObject.GetComponent<PreOpeProc>();

    }

    void Update()
    {
        if(FadeSystem.GameMode == 1)
        {
            if (FadeSystem.BDead == 0)
            {
                if (0 == AttackSetCount)
                {
                    Setvalue = Random.Range(1, 3);  //1か2の攻撃の判断を行う.
                }
                AttackSetCount++;
            }
        }
    }
}
