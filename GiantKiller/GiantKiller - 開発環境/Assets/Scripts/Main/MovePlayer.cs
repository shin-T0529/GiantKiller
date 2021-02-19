using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    int SetPos;
    public GameObject LeftW, RightW, TopW, DownW;
    Vector3 LeftWPos, RightWPos;//, TopWPos, DownWPos;

    void Start()
    {
        //移動制限用.
        LeftWPos  = LeftW.transform.position;
        RightWPos = RightW.transform.position;
        SetPos = 0;
    }

    void Update()
    {
        //移動制限：X軸の制限をかける.
        this.transform.position = (
            new Vector3(Mathf.Clamp(this.transform.position.x, LeftWPos.x + 5.0f, RightWPos.x - 5.0f),
                        this.transform.position.y, this.transform.position.z));
    }

    //持続的に呼ばれ続ける.
    void FixedUpdate()
    {
        Transform myTransform = this.transform;

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(
                transform.position.x + 0.5f, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(
                transform.position.x - 0.5f, transform.position.y, transform.position.z);
        }
    }
}
