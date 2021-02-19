using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreOneAttackProc : MonoBehaviour
{
    //攻撃場所の設定後、攻撃動作を設定する.
    [SerializeField, Tooltip("範囲攻撃用の大きいオブジェクト")]
    private GameObject ThisOpePanel;

    public int AttackPosNo;
    bool CreateAttack;
    [SerializeField, Tooltip("範囲攻撃用座標の設定先オブジェクト")]
    public GameObject ThisOpePanel11;
    public GameObject ThisOpePanel12;
    public GameObject ThisOpePanel13;

    //発射用のローカル宣言.
    GameObject AttackBlock;
    Rigidbody rid;
    float MinusY = -10.0f;
    PreOpeProc preOpeProc;

    void Start()
    {
        CreateAttack = false;
        preOpeProc = gameObject.GetComponent<PreOpeProc>();
    }

    // Update is called once per frame
    void Update()
    {

        if (preOpeProc.AttackStart == true)
        {
            AttackPosNo = preOpeProc.SetAttackPlaneNo;
            preOpeProc.AttackStart = false;
            CreateAttack = true;
        }
        SwitchAttakSetPos();
    }

    void SwitchAttakSetPos()
    {
        //攻撃座標の設定、生成、動作.
        switch (AttackPosNo)
        {
            case 0:
                CreateAttack = false;
                break;
            case 1:
                if(CreateAttack == true)
                {
                    AttackBlock = Instantiate(ThisOpePanel, new Vector3(
                        ThisOpePanel11.transform.position.x,
                        ThisOpePanel11.transform.position.y - MinusY,
                        ThisOpePanel11.transform.position.z),
                        Quaternion.Euler(90.0f, 0.0f, 0.0f));
                    rid = AttackBlock.GetComponent<Rigidbody>();
                    rid.AddForce(0, 2000, 0);
                    AttackPosNo = 0;
                }
                break;
            case 2:
                if (CreateAttack == true)
                {
                    AttackBlock = Instantiate(ThisOpePanel, new Vector3(
                        ThisOpePanel12.transform.position.x,
                        ThisOpePanel12.transform.position.y - MinusY,
                        ThisOpePanel12.transform.position.z),
                    Quaternion.Euler(90.0f, 0.0f, 0.0f));
                    rid = AttackBlock.GetComponent<Rigidbody>();
                    rid.AddForce(0, 2000, 0);
                    AttackPosNo = 0;
                }
                break;
            case 3:
                if (CreateAttack == true)
                {
                    AttackBlock = Instantiate(ThisOpePanel, new Vector3(
                        ThisOpePanel13.transform.position.x,
                        ThisOpePanel13.transform.position.y - MinusY,
                        ThisOpePanel13.transform.position.z),
                    Quaternion.Euler(90.0f, 0.0f, 0.0f));
                    rid = AttackBlock.GetComponent<Rigidbody>();
                    rid.AddForce(0, 2000, 0);
                    AttackPosNo = 0;
                }
                break;

            default:
                break;
        }

    }
}
