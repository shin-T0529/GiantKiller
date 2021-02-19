using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShakeObjects : MonoBehaviour
{
    [SerializeField] GameObject[] shakeObjects;
    [SerializeField] float shakeAmount;
    [SerializeField] float shakeDuration;


    void Start()
    {
    }
    private void Update()
    {
        Shake(shakeObjects);
    }

    private void Shake(GameObject[] shakeObjects)
    {
        foreach (var shakeObject in shakeObjects)
        {
            // iTweenでオブジェクトをゆらす
            iTween.ShakePosition(shakeObject, Vector3.one * shakeAmount, shakeDuration);

            //ShakeCount++;
            // iTween は Hash というものを使い、各種パラメーターを指定できる
            // 参考資料　https://hutonggames.fogbugz.com/default.asp?W618
            /*
            iTween.ShakePosition ( shakeObject, iTween.Hash (
                "x", 2f,
                "y", 1f,
                "delay", 1f,
                "time", 1f ) );
            */
        }
    }
}
