using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    Transform myTransform;

    Vector3 worldAngle;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myTransform = this.transform;
        worldAngle = myTransform.eulerAngles;

        this.transform.position = new Vector3(18.668f, 121.7f, -135.5f);
        // ワールド座標を基準に、回転を取得
        worldAngle.x = 5.677f;
        worldAngle.y = worldAngle.z = 0.0f;
        myTransform.eulerAngles = worldAngle;

        //if (fazeChange.F_Change == true)
        //{
        //    this.transform.position = new Vector3(
        //        20.11f, 148.29f, -115.28f);
        //    // ワールド座標を基準に、回転を取得.
        //    worldAngle.x = 50.198f;
        //    worldAngle.y = worldAngle.z = 0.0f;
        //    // 回転角度の反映.
        //    myTransform.eulerAngles = worldAngle;

        //}
        ////攻撃フェーズのカメラ.
        //else
        //{

        //}


        // transformを取得

    }

    private void CameraPosSet()
    {
    }

}
