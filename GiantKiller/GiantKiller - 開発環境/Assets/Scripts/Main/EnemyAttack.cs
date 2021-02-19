using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 ①：足場に対しての範囲攻撃.
 ②：自機座標への攻撃.
*/


public class EnemyAttack : MonoBehaviour
{

    public int Value;
    public int E_AttackCnt;
    [SerializeField, Tooltip("落下攻撃")]
    private GameObject E_Attack;
    [SerializeField, Tooltip("落下攻撃の予備動作")]
    private GameObject E_PreAttack;

    public GameObject Player;
    public bool E_AtkEnd;
    bool PanelCreate;
    FadeSystem fadeSystem;

    HitEnemyHP hitEnemyHP;
    E_AttackSet e_AttackSet;

    void Start()
    {
        Value = 0;
        E_AttackCnt = 0;

        fadeSystem = gameObject.GetComponent<FadeSystem>();

        hitEnemyHP = gameObject.GetComponent<HitEnemyHP>();
        e_AttackSet = gameObject.GetComponent<E_AttackSet>();
    }

    void Update()
    {
        if (FadeSystem.BDead == 0)
        {
            if (e_AttackSet.Setvalue == 1)
            {
                E_AttackCnt++;
                //敵の弱攻撃は自機の頭上から落ちてくるようにする.
                if (190 < E_AttackCnt)
                {
                    if (PanelCreate == false)
                    {
                        GameObject pre = Instantiate(E_PreAttack, new Vector3(
                        Player.transform.position.x,
                        Player.transform.position.y - 5.76f,
                        Player.transform.position.z),
                        Quaternion.identity);
                        PanelCreate = true;
                    }

                    if (200 < E_AttackCnt)
                    {
                        GameObject capsule = Instantiate(E_Attack, new Vector3(
                        Player.transform.position.x,
                        Player.transform.position.y + 50.0f,
                        Player.transform.position.z),
                        Quaternion.identity);
                        Rigidbody rid = capsule.GetComponent<Rigidbody>();
                        rid.AddForce(0, -2000, 0);
                        e_AttackSet.AttackSetCount = 0;
                        PanelCreate = false;
                        E_AttackCnt = 0;
                    }
                }
            }
            else
            {
                E_AttackCnt = 0;
            }
        }

    }
}
