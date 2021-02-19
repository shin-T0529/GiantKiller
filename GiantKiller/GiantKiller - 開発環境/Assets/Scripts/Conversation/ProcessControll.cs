using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessControll : MonoBehaviour
{
    public int CommCount;

    public Image AttackSetsume;
    public Image Fade;

    public GameObject canvas;
    public GameObject Ability;

    bool CanvasFlag;

    float Alpha;

    ChangeScenes changeScenes;

    void Start()
    {
        changeScenes = gameObject.GetComponent<ChangeScenes>();
        Fade.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        Alpha = 0.0f;
        CanvasFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CommCount++;
        }

        if (CommCount == 5)
        {
            canvas.SetActive(false);
            CanvasFlag = true;
        }

        if (CanvasFlag)
        {
            Fade.color = new Color(0.0f, 0.0f, 0.0f, Alpha);
            if (Alpha < 0.70f)
            { Alpha += 0.01f; }
            else
            {
                Ability.SetActive(true);
                Alpha = 0.70f;
            }
        }
    }

    public void ClicktoGameStart()
    {
        changeScenes.GameStart();
    }
}
