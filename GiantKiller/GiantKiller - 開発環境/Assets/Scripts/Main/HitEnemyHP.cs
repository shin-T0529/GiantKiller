using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HitEnemyHP : MonoBehaviour
{
    //減らすゲージのテクスチャ.
    public Image image;
    public Image imageBack;

    /// 標的のオブジェクト
    [SerializeField, Tooltip("左側の標的オブジェクト")]
    private GameObject TargetLObject;

    [SerializeField, Tooltip("中央の標的オブジェクト")]
    private GameObject TargetCeObject;

    [SerializeField, Tooltip("右側の標的オブジェクト")]
    private GameObject TargetRObject;

    [SerializeField, Tooltip("振動システムオブジェクト")]
    private GameObject ShakeSystemObject;
    
    //SE用.
    public AudioClip HitSound;

    AudioSource audioSource;


    //実際に減るダメージと減らすためのダメージ.
    private float Damage, currentDamage;
    //各部位(共通)で受けるダメージ.
    private float PartDamage; //1.0f=100 , 0.01f = 0.01. 
    //体力の数値記録.
    private float SaveDamage;
    //スキルポイント加算分.
    int  GetAtkSkillPoint;
    float SkillDamage;
    bool HitCheck;
    //オブジェクトの破棄とは別の用途で使う.
    public GameObject P_Bullet;

    FadeSystem fadeSystem;
    /*
    static ClickControll clickControll;
    clickControll = GetComponent<ClickControll>();
    GetAtkSkillPoint = clickControll.GetAtkSkill();

    はエラーがでる.
    */
    void Start()
    {

        Damage = 0.001f;
        SaveDamage = 1.0f;
        SkillDamage = 0.0f;
        HitCheck = false;
        PartDamage = 0.02f;     //1.0f=100 , 0.01f = 0.01. 
        image.enabled = true;
        imageBack.enabled = true;

        fadeSystem = gameObject.GetComponent<FadeSystem>();
        GetAtkSkillPoint = ClickControll.GetAtkSkill();

        audioSource = gameObject.GetComponent<AudioSource>();
    }


    void Update()
    {
        HPCheckProc();
        SkillPointAtk();
    }

    void HPCheckProc()
    {
        if (HitCheck == true)
        {
            if (currentDamage < PartDamage)
            {
                image.fillAmount -= Damage; //HPの計算.
                currentDamage += 0.001f;    //徐々に減らすため加算していく.    
            }
            else
            {
                SaveDamage = image.fillAmount;
                currentDamage = 0.0f;
                PartDamage = 0.0f;
                HitCheck = false;
            }
        }

        //ほぼ死亡.
        if(SaveDamage <= 0.0f)
        {
            FadeSystem.BDead = 1;
            FadeSystem.GameMode = 2;
            ShakeSystemObject.SetActive(true);
        }

    }

    void SkillPointAtk()
    {
        switch (GetAtkSkillPoint)
        {
            case 0:
                SkillDamage = 0.0f;
                break;
            case 1:
                SkillDamage = 0.01f;
                break;
            case 2:
                SkillDamage = 0.02f;
                break;
            case 3:
                SkillDamage = 0.03f;
                break;
            case 4:
                SkillDamage = 0.04f;
                break;
            case 5:
                SkillDamage = 0.05f;
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Bullet"))
        {
            HitCheck = true;
            PartDamage = 0.015f + SkillDamage;
            audioSource.PlayOneShot(HitSound);
        }
    }
}
