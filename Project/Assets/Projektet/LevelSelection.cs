using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
    private static int _nextLevelIndex = 1;

    private void OnMouseUp()
    {
        
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene("Main");
    }
}