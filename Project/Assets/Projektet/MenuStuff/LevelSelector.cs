using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public void Select(string levelName)
    {
        Debug.Log(levelName);
        fader.FadeTo(levelName);
        //SceneManager.LoadScene(levelName);
    }
    public void Quit()
    {
        Debug.Log("Helo");
        Application.Quit();
    }
}
