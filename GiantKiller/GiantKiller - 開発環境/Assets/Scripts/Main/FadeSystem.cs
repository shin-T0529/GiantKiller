using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeSystem : MonoBehaviour
{
    public Image FadeScreen;
    public Image MissionStart;

    public GameObject PUIObjects, BUIObjects;

    private float fadeSpeed;
    private float Red,Green,Blue,Alpha;
    public static int ArmMove;
    public static int GameMode;
    public static int PDead, BDead;
    public int ShakeCount;
    bool UpDownChange;
    int PauzeCount,AmountNo;

    ChangeScenes changeScenes;

    void Start()
    {
        fadeSpeed = 0.002f;
        Red = Green = Blue = 0.0f;
        Alpha = 1.0f;
        UpDownChange = false;
        PauzeCount = AmountNo = 0;
        changeScenes = gameObject.GetComponent<ChangeScenes>();
        GameMode = 0;
        ArmMove = 0;
        PDead = 0;
        BDead = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Fade();
    }

    public void Fade()
    {
        switch(GameMode)
        {
            case 0: //開始前.
                FadeScreen.color = new Color(Red, Green, Blue, Alpha);

                if (Alpha <= 0.0f)
                {
                    Alpha = 0.0f;
                    StartTex();
                }
                Alpha -= fadeSpeed;
                break;
            case 1: //対戦中.
                FadeScreen.color = new Color(Red, Green, Blue, Alpha);
                Alpha = 0.0f;
                AmountNo = 3;
                break;
            case 2: //終了後.
                if (PDead == 1)
                {   //明幕.
                    PDead = 1;
                    Red = Green = Blue = 0.0f;
                    FadeScreen.color = new Color(Red, Green, Blue, Alpha);
                    fadeSpeed = 0.02f;
                    Alpha += fadeSpeed;
                    if (1.1f < Alpha && PDead == 1)
                    { GameMode = 3; }

                }
                else if (BDead == 1)
                {   //暗幕.
                    BDead = 1;
                    Red = Green = Blue = 1.0f;
                    FadeScreen.color = new Color(Red, Green, Blue, Alpha);
                    if (Alpha < 1.0f) //ShakeCount < 200 && )
                    {
                        //ShakeCount++;
                        fadeSpeed = 0.02f;
                        Alpha += fadeSpeed;
                    }
                    else { GameMode = 3; }
                }
                break;
            case 3: //どちらかの死亡＆シーン移行.
                if (1.0f < Alpha && PDead == 1)
                {
                    changeScenes.MissionFailed();
                }
                else if (1.0f < Alpha && BDead == 1)
                {
                    changeScenes.MissionClear();
                }
                break;
            case 4:
                break;
        }
    }

    void StartTex()
    {
        switch(AmountNo)
        {
            case 0:
                MissionStart.fillAmount += 0.002f;
                if(1.0f <= MissionStart.fillAmount)
                { AmountNo = 1; }
                break;
            case 1:
                MissionStart.fillAmount = 1.0f;
                if(PauzeCount < 150)
                { PauzeCount++; }
                else
                { AmountNo = 2; }
                break;
            case 2:
                MissionStart.fillAmount -= 0.002f;
                if (MissionStart.fillAmount <= 0.0f)
                { AmountNo = 3; }
                break;
            case 3:
                MissionStart.fillAmount = 0.0f;
                PauzeCount = 0;
                ArmMove = 1;
                PUIObjects.SetActive(true);
                BUIObjects.SetActive(true);

                GameMode = 1;
                break;
        }
    }
}
