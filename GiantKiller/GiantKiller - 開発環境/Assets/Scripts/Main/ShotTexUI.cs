using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotTexUI : MonoBehaviour
{
    //減らすゲージのテクスチャ.
    public Image image;
    public Image REimage;
    ShotForce shotForce;
    ReloadProc reloadProc;

    //残弾数格納変数.
    private float Reammo, Keepammo;
    private int Reportammo;

    void Start()
    {
        shotForce = gameObject.GetComponent<ShotForce>();
        reloadProc = gameObject.GetComponent<ReloadProc>();

        Reammo = 0.0f;
        Reportammo = 1;
        Keepammo = 1.1f;
    }

    void Update()
    {
        //表示の減少処理.
        Reammo = Reammo * 0.1f;
        if (Reportammo != shotForce.ShotCount)
        {
            image.fillAmount -= Reammo; //HPの計算.
            Reportammo = shotForce.ShotCount;
            Reammo = 0.0f;
            Keepammo -= 0.1f;
        }
        else
        {
            image.fillAmount = Keepammo;
        }

        //リロード指示UIの表示.
        if(0.0f == image.fillAmount)
        { REimage.enabled = true; }
        else
        { REimage.enabled = false; }
    }

    //HPゲージをダメージ量によって色変更.
    void FixedUpdate()
    {
        Reammo = (float)shotForce.ShotCount;
    }

    public void ShotUIReload()
    {
        Reammo = 0.0f;
        Reportammo = 1;
        Keepammo = 1.1f;
    }

}
