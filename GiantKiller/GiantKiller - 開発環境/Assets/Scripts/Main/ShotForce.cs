using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotForce : MonoBehaviour
{
    /// 射出するオブジェクトz
    [SerializeField, Tooltip("射出するオブジェクト")]
    private GameObject ThrowingObject;

    /// 標的のオブジェクト
    [SerializeField, Tooltip("左側の標的オブジェクト")]
    private GameObject TargetLObject;

    [SerializeField, Tooltip("中央の標的オブジェクト")]
    private GameObject TargetCeObject;

    [SerializeField, Tooltip("右側の標的オブジェクト")]
    private GameObject TargetRObject;

    [SerializeField, Tooltip("ボス本体の標的オブジェクト")]
    private GameObject BossTargetObject;

    /// 射出角度
    [SerializeField, Range(0F, 90F), Tooltip("射出する角度")]
    private float ThrowingAngle;

    //発射位置.
    [SerializeField, Tooltip("発射位置ののオブジェクト")]
    private GameObject Player;

    //標的自動変更用.
    [SerializeField, Tooltip("左側狙うオブジェクト")]
    private GameObject LeftLock;

    [SerializeField, Tooltip("中央狙うオブジェクト")]
    private GameObject CenterLock;

    [SerializeField, Tooltip("右側狙うオブジェクト")]
    private GameObject RightLock;

    [SerializeField, Tooltip("左ロック")]
    private Image LeftLockImage;
    [SerializeField, Tooltip("右ロック")]
    private Image RightLockImage;
    [SerializeField, Tooltip("中央ロック")]
    private Image CenterLockImage;

    [SerializeField, Tooltip("ボスの体力参照用")]
    private Image BossHPGauge;
    private float BossSaveHP;

    //位置変更用(初期位置は中央).
    public bool LeftSide;
    public bool CenterSide;
    public bool RightSide;
    public bool BossBody;
    //部位破壊後の位置調整用.
    private bool CCheck, LCheck, RCheck;
    //public bool CCheck;
    //標的座標設定用.
    Vector3 targetPosition;

    //射撃弾数設定用.
    public int ShotMax, ShotCount,ShotDelay;

    //SE用.
    public AudioClip ShotSound;

    AudioSource audioSource;
    FadeSystem fadeSystem;

    ReloadProc reloadProc;
    HitEnemyHP hitEnemyHP;
    E_PartsProc e_PartsProc;

    int Reset;
    private void Start()
    {
        ShotMax = 10;
        ShotCount = 0;
        ShotDelay = 60;
        Reset = 0;
        BossSaveHP = 0.0f;

        LeftSide = RightSide = false;
        CenterSide = true;
        LCheck = CCheck = RCheck = false;
        BossBody = false;
        LeftLock.SetActive(true);
        RightLock.SetActive(true);
        LeftLockImage.enabled = RightLockImage.enabled = false;
        CenterLockImage.enabled = true;

        fadeSystem = gameObject.GetComponent<FadeSystem>();

        reloadProc = gameObject.GetComponent<ReloadProc>();
        hitEnemyHP = gameObject.GetComponent<HitEnemyHP>();
        e_PartsProc = gameObject.GetComponent<E_PartsProc>();

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Update()
    {
        BossSaveHP = BossHPGauge.fillAmount;
        EnemyPartsBreak();
        //部位破壊をしたあとの数値設定.
        if (BossBody == true)
        {
            ThrowingAngle = 18.0F;

            LeftSide = false;
            CenterSide = false;
            RightSide = false;
            //部位破壊可能箇所非アクティブ.
            TargetLObject.SetActive(false);
            TargetCeObject.SetActive(false);
            TargetRObject.SetActive(false);
            //ロックマーカーも非アクティブ.
            LeftLockImage.enabled = false;
            CenterLockImage.enabled = false;
            RightLockImage.enabled = false;
            //ボスの核を出してラストスパート.
            BossTargetObject.SetActive(true);
        }

        if (FadeSystem.GameMode == 1)
        {
            //いつでも右クリックでリロード.
            if (Input.GetMouseButtonDown(1))
            { reloadProc.BulletReload(); }

            //部位破壊されてなくてかつ指定された場所の
            //いずれかにいるとき.
            //オブジェクト名.activeSelf.

            if (CenterLock.activeSelf && CenterSide == true)
            { ShotProc(); }
            else if (LeftLock.activeSelf && LeftSide == true)
            { ShotProc(); }
            else if (RightLock.activeSelf && RightSide == true)
            { ShotProc(); }
            else if (BossBody == true)
            { ShotProc(); }
        }

    }

    public void EnemyPartsBreak()
    {
        //各部位の破壊処理.
        //Center:1 Left:2 Right:3
        if (e_PartsProc.FlagNo == 1)
        { CCheck = true; }
        else if (e_PartsProc.FlagNo == 2)
        { LCheck = true; }
        else if (e_PartsProc.FlagNo == 3)
        { RCheck = true; }
        else
        {
            CCheck = false;
            LCheck = false;
            RCheck = false;
        }

        //各部位が破壊される時.
        if (LCheck == true && LeftSide == true)
        {
            LeftLockImage.enabled = false;
            LeftLock.SetActive(false);
            LeftSide = false;
            LCheck = false;
        }
        if (RCheck == true && RightSide == true)
        {
            RightLockImage.enabled = false;
            RightLock.SetActive(false);
            RightSide = false;
            RCheck = false;
        }
        if (CCheck == true && CenterSide == true)
        {
            CenterLockImage.enabled = false;
            CenterLock.SetActive(false);
            CenterSide = false;
            CCheck = false;
        }

        if(e_PartsProc.FlagNo == 4)
        {
            //書き換えられないように固定.
            e_PartsProc.FlagNo = 4;     
            BossBody = true;
        }

    }

    private void ShotProc()
    {
        if (ShotCount < ShotMax)
        {
            //左クリックで発射.
            if (Input.GetMouseButtonDown(0) && reloadProc.Reload == false)
            {
                ThrowingBall();
                audioSource.PlayOneShot(ShotSound);
                ShotCount += 1;
            }
            //右クリックで残弾数関係なくリロード.
            if (Input.GetMouseButtonDown(1))
            {
                reloadProc.BulletReload();
            }
        }
    }


    //ボールを射出する.
    //※引用元有.
    private void ThrowingBall()
    {
        if (ThrowingObject != null && TargetCeObject != null
          && TargetLObject != null && TargetRObject != null && BossTargetObject != null)
        {
            // Ballオブジェクトの生成(生成場所はプレイヤー座標のちょっと前から).
            GameObject ball = Instantiate(ThrowingObject, new Vector3(
                Player.transform.position.x, Player.transform.position.y + 2.0f, Player.transform.position.z + 20.0f), Quaternion.identity);


            // 標的の座標のセット.
            if(BossBody == true)
            {
                //ボスのHPが半分を切ったあとに狙う箇所.
                targetPosition = BossTargetObject.transform.position;
            }
            else
            {
                //ボスのHPが半分以上の時に狙う箇所.
                if (LeftSide == true)
                { targetPosition = TargetLObject.transform.position; }
                else if (RightSide == true)
                { targetPosition = TargetRObject.transform.position; }
                else if (CenterSide == true)
                { targetPosition = TargetCeObject.transform.position; }
            }

            // 射出角度
            float angle = ThrowingAngle;

            // 射出速度を算出
            Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);

            // 射出
            Rigidbody rid = ball.GetComponent<Rigidbody>();
            rid.AddForce(velocity * rid.mass, ForceMode.Impulse);
        }
        else
        {
            throw new System.Exception("射出するオブジェクトまたは標的のオブジェクトが未設定です。");
        }
    }

    //標的に命中する射出速度の計算
    //同上.
    //<param name="pointA">射出開始座標</param>
    //<param name="pointB">標的の座標</param>
    //<returns>射出速度</returns>
    private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle)
    {
        // 射出角をラジアンに変換
        float rad = angle * Mathf.PI / 180;

        // 水平方向の距離x
        float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));

        // 垂直方向の距離y
        float y = pointA.y - pointB.y;

        // 斜方投射の公式を初速度について解く
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(speed))
        {
            // 条件を満たす初速を算出できなければVector3.zeroを返す
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
        }
    }

    private void OnTriggerStay(Collider collision)
    {

        //左側にいった時.
        if (collision.CompareTag("LeftPos"))
        {
            LeftLockImage.enabled = true;
            CenterLockImage.enabled = false;
            RightLockImage.enabled = false;
            LeftSide = true;
            CenterSide = false;
            RightSide = false;
            ThrowingAngle = 24.5F;
        }
        //中央に行ったとき.
        else if (collision.CompareTag("CenterPos"))
        {
            if (CCheck == false)
            {
                CenterLockImage.enabled = true;
                LeftLockImage.enabled = false;
                RightLockImage.enabled = false;
                LeftSide = false;
                CenterSide = true;
                RightSide = false;
                ThrowingAngle = 19.5F;
            }
        }
        //右側にいった時.
        else if (collision.CompareTag("RightPos"))
        {
            RightLockImage.enabled = true;
            LeftLockImage.enabled = false;
            CenterLockImage.enabled = false;
            LeftSide = false;
            CenterSide = false;
            RightSide = true;
            ThrowingAngle = 24.5F;
        }

    }

}