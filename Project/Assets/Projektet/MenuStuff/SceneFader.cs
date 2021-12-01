using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    //public string scene1 = "Main";

    private float fadeLength = 2f;

    void Start ()
    {
        StartCoroutine(FadeIn());
    }
    // Använd följande för att använda fadeto funktionen, lägg till SceneFader prefab till alla scripts som ska använda funktionerna
    // public SceneFader sceneFader;
    // sceneFader.FadeTo(levelToLoad);
    // sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    public void FadeTo (string scene)
    {
        StartCoroutine(FadeOut(scene));
    }
    IEnumerator FadeIn ()
    {
        float t = fadeLength;

        while (t > 0f) 
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color (0f, 0f, 0f, a);
            yield return 0;
        }


    }
    IEnumerator FadeOut (string scene)
    {
        float t = 0f;

        while (t < fadeLength) 
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color (0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
        //SceneManager.LoadScene(scene);
    }

}
