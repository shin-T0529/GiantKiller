using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAnimations : MonoBehaviour
{
    public Animator LArmAnim,RArmAnim;
    int AnimPlayCnt;
    void Start()
    {
        AnimPlayCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(FadeSystem.ArmMove == 1 && AnimPlayCnt == 0)
        {
            LArmAnim.enabled = true;
            RArmAnim.enabled = true;

            AnimPlayCnt = 1;
        }
    }
}
