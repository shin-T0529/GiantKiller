using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void ConversationStart()
    {
        //シーン読込.
        SceneManager.LoadScene(1);
    }

    public void GameStart()
    {
        //シーン読込.
        SceneManager.LoadScene(2);
    }

    //クリア.
    public void MissionClear()
    {
        SceneManager.LoadScene(3);
    }

    //コンテニュー.
    public void MissionFailed()
    {
        SceneManager.LoadScene(4);
    }

    public void GameEnd()
    {
        //エディタ上でしか終了できない.
        Application.Quit();
    }

    public void Credit()
    {
        SceneManager.LoadScene(5);
    }
}
