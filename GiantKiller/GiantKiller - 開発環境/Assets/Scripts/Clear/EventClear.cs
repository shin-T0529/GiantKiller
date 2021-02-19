using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventClear : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip OnSound;
    public Image FadeScreen;

    float Alpha, fadeSpeed;
    bool Return;
    AudioSource audioSource;

    void Start()
    {
        Return = false;
        Alpha = 0.0f;
        fadeSpeed = 0.01f;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Return == true)
        {
            FadeScreen.color = new Color(1.0f, 1.0f, 1.0f, Alpha);
            Alpha += fadeSpeed;
            if (1.0f <= Alpha)
            {
                SceneManager.LoadScene(0);
            }
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(OnSound);
    }
    public void ClickAlpha()
    {
        Return = true;
        FadeScreen.enabled = true;
    }
}
