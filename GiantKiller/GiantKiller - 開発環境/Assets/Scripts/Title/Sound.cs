using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sound : MonoBehaviour, IPointerEnterHandler
{
    //SE用.
    public AudioClip AddSound;
    public AudioClip OnSound;
    public GameObject SpecealScreen;
    public Image FadeScreen;
    public GameObject BGMObject;
    bool Play,Credit,GameStart,Retry,GameOver;
    int SoundCount;
    float Alpha, fadeSpeed;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        SoundCount = 0;
        Alpha = 0.0f;
        fadeSpeed = 0.01f;
        Play = Credit = GameStart = Retry = GameOver = false;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Title - Convertion
        PlaySoundtoChangeScene(1, Play, 0.0f, 0.0f, 0.0f);

        //Title - Convertion
        PlaySoundtoChangeScene(5, Credit, 0.0f, 0.0f, 0.0f);

        //Convertion - Main
        PlaySoundtoChangeScene(2, GameStart, 0.0f, 0.0f, 0.0f);

        //Failed - Main(Retry)
        PlaySoundtoChangeScene(2, Retry, 1.0f, 1.0f, 1.0f);

        //Failed - Title(GameOver)
        PlaySoundtoChangeScene(0, GameOver, 0.0f, 0.0f, 0.0f);

    }

    //飛ぶ先のシーンナンバー　対応したフラグ　フェードの色.
    void PlaySoundtoChangeScene(int SceneNo,bool PlaySound,float Red,float Bule,float Green)
    {
        if (PlaySound == true)
        {
            BGMObject.SetActive(false);
            SoundCount++;
            FadeScreen.color = new Color(Red, Bule, Green, Alpha);
            Alpha += fadeSpeed;
            if (200 < SoundCount && 1.0f <= Alpha)
            {
                SceneManager.LoadScene(SceneNo);
            }
        }
    }

    public void AddSoundPlay()
    {
        audioSource.PlayOneShot(AddSound);
        Play = true;
        FadeScreen.enabled = true;
    }

    public void AddSoundGameStart()
    {
        audioSource.PlayOneShot(AddSound);
        GameStart = true;
        FadeScreen.enabled = true;
        SpecealScreen.SetActive(true);
    }

    public void AddSoundRetry()
    {
        audioSource.PlayOneShot(AddSound);
        Retry = true;
        FadeScreen.enabled = true;
    }

    public void AddSoundGameOver()
    {
        audioSource.PlayOneShot(AddSound);
        GameOver = true;
        FadeScreen.enabled = true;
    }

    public void AddSoundCredit()
    {
        audioSource.PlayOneShot(AddSound);
        Credit = true;
        FadeScreen.enabled = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(OnSound);
    }
}
