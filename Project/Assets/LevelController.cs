using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    private Gyulai[] _enemies;
    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Gyulai>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Gyulai enemy in _enemies)
        {
            if(enemy != null)
            {
                return;
            }
        }
        Debug.Log("You killed all enemies");

        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene("Main");
    }
}
