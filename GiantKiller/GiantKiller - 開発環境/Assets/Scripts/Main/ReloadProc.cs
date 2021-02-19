using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadProc : MonoBehaviour
{
    public bool Reload;
    public bool ReloadEnd;

    //リロードゲージ制御用.
    public Image image;
    public Image imageBack;
    public Image Bullet;
    private int R_GaugeChage,R_GaugeCount;
    float ReloadSpeed;
    ShotForce shotForce;
    ShotTexUI shotTexUI;
    void Start()
    {
        Reload = false;
        ReloadEnd = false;
        R_GaugeChage = 0;
        R_GaugeCount = 0;
        ReloadSpeed = 0.0f;
        shotForce = gameObject.GetComponent<ShotForce>();
        shotTexUI = gameObject.GetComponent<ShotTexUI>();
    }

    void Update()
    {
        ReloadGauge();      //リロードゲージの動機開始.

        if(Reload == true)
        {
            shotForce.ShotDelay--;
        }
        if (shotForce.ShotDelay < 0)
        {
            shotForce.ShotDelay = 100;
            shotForce.ShotCount = 0;
            shotTexUI.ShotUIReload();
            Reload = false;
        }

    }

    public void BulletReload()
    {
        Reload = true;
        ReloadEnd = false;
        //残弾数に応じてリロード時間を短縮する.
        if (7 < shotForce.ShotCount && shotForce.ShotCount < 9)
        {
            shotForce.ShotDelay = R_GaugeChage = 50;
            ReloadSpeed = 0.03f;
        }
        else if (3 < shotForce.ShotCount && shotForce.ShotCount < 6)
        {
            shotForce.ShotDelay = R_GaugeChage = 70;
            ReloadSpeed = 0.02f;
        }
        else
        {
            shotForce.ShotDelay = R_GaugeChage = 90;
            ReloadSpeed = 0.01f;
        }
    }

    private void ReloadGauge()
    {
        //ひとまずリロード時間を略.
        if (Reload == true)
        {
            image.enabled = true;
            imageBack.enabled = true;
            Bullet.enabled = false;
            if (R_GaugeCount < R_GaugeChage)
            {
                R_GaugeCount++;
                image.fillAmount += ReloadSpeed;
            }
            else
            {
                R_GaugeCount = 0;
                ReloadSpeed = 0.0f;
                image.fillAmount = 0.0f;
                image.enabled = false;
                imageBack.enabled = false;
                Bullet.enabled = true;
            }

        }

    }
}
