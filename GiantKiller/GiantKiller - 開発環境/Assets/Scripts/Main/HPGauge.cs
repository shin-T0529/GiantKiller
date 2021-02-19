using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPGauge : MonoBehaviour
{
    //減らすゲージのテクスチャ.
    public Image image;
    //実際に減るダメージと減らすためのダメージ.
    private float Damage,currentDamage;
    //受ける最大のダメージ.
    private float MaxDamage;

    bool HitCheck,HitRangeCheck;

    //スキルポイント加算分.
    int GetHPSkillPoint;
    float SkillHP;

    //SE用.
    public AudioClip HitSound;

    AudioSource audioSource;

    FadeSystem fadeSystem;

    void Start()
    {
        Damage = 0.001f;
        HitCheck = false;
        HitRangeCheck = false;

        fadeSystem = gameObject.GetComponent<FadeSystem>();
        GetHPSkillPoint = ClickControll.GetHPSkill();

        audioSource = gameObject.GetComponent<AudioSource>();
    }


    /*
     ダメージ　int型で設定予定.
     HPゲージ増減　float型で設定予定.
     int 1 = float 0.01と同じように設定する.
     1.0f(int 1) * 0.01(float 0.01f) = ダメージで増減する分とする.
         */
    void Update()
    {
        SkillPointHP();
        if (HitCheck == true)
        {
            if(currentDamage < MaxDamage)
            {
                image.fillAmount -= Damage; //HPの計算.
                currentDamage += 0.001f;    //徐々に減らすため加算していく.    
            }
            else
            {
                currentDamage = 0.0f;
                MaxDamage = 0.0f;
                HitCheck = false;
            }
        }

        if (HitRangeCheck == true)
        {
            if (currentDamage < MaxDamage)
            {
                image.fillAmount -= Damage; //HPの計算.
                currentDamage += 0.001f;    //徐々に減らすため加算していく.    
            }
            else
            {
                currentDamage = 0.0f;
                MaxDamage = 0.0f;
                HitRangeCheck = false;
            }
        }

        if(image.fillAmount <= 0.0f)
        {
            FadeSystem.PDead = 1;
            FadeSystem.GameMode = 2;
        }
        //fadeSystem.Fade();

    }

    //HPゲージをダメージ量によって色変更.
    void FixedUpdate()
    {
        if (image.fillAmount > 0.5f)
        {
            image.color = Color.green;
        }
        else if (image.fillAmount > 0.2f)
        {
            image.color = new Color(1f, 127f / 255f, 39f / 255f);
        }
        else
        {
            image.color = Color.red;
        }
    }

    void SkillPointHP()
    {
        switch (GetHPSkillPoint)
        {
            case 0:
                SkillHP = 0.0f;
                break;
            case 1:
                SkillHP = 0.005f;
                break;
            case 2:
                SkillHP = 0.006f;
                break;
            case 3:
                SkillHP = 0.007f;
                break;
            case 4:
                SkillHP = 0.008f;
                break;
            case 5:
                SkillHP = 0.009f;
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        //頭上からの攻撃(ダメージ小).
        if (collider.CompareTag("E_Bullet"))
        {
            MaxDamage = 0.05f - SkillHP;
            HitCheck = true;
            audioSource.PlayOneShot(HitSound);
        }

        if (collider.CompareTag("E_RangeAttack"))
        {
            MaxDamage = 0.1f - SkillHP;
            HitCheck = true;
            audioSource.PlayOneShot(HitSound);
        }

    }
}