using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextRender : MonoBehaviour
{
    public Text SkillPoint, AttackPoint, HPPoint;
    ClickControll clickControll;
    void Start()
    {
        clickControll = gameObject.GetComponent<ClickControll>();
    }

    // Update is called once per frame
    void Update()
    {
        SkillPoint.text = "残りポイント：" + clickControll.Max_in;
        HPPoint.text = "HP： + " + clickControll.HP_in;
        AttackPoint.text = "Attack： + " + clickControll.Attack_in;
    }
}
