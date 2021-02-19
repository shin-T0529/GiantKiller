using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditNotation : MonoBehaviour
{
    public GameObject CreditUI;
    public Image Credit1;
    public Image Credit2;
    public Button Left;
    public Button Right;

    static int UINo;
    void Start()
    {
        UINo = 0;
        Credit1.enabled = true;
        Credit2.enabled = false;
    }

    void Update()
    {
        CreditTexCont();
    }

    void CreditTexCont()
    {
        switch (UINo)
        {
            case 0:
                Credit1.enabled = true;
                Credit2.enabled = false;
                Left.enabled = false;
                Right.enabled = true;

                break;
            case 1:
                Credit1.enabled = false;
                Credit2.enabled = true;
                Left.enabled = true;
                Right.enabled = false;

                break;
            default:
                break;
        }
    }

    public void ClickCredit()
    {
        CreditUI.SetActive(true);
        Credit1.enabled = true;
        Credit2.enabled = false;
    }

    public void ClickCreditExit()
    {
        UINo = 0;
        CreditUI.SetActive(false);
    }

    public void ClickUp()
    {
        UINo = 1;
    }

    public void ClickDown()
    {
        UINo = 0;
    }

}
