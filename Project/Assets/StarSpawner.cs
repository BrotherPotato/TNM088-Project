using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;

    [SerializeField]
    public float spawnTimer;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fallingStars());
    }
    private void spawnStar(){
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        GameObject s = Instantiate(starPrefab) as GameObject;
        s.transform.position = new Vector2((Camera.main.transform.position.x + Random.Range(2 * -screenBounds.x, 2 * screenBounds.x)), screenBounds.y);
    }



IEnumerator fallingStars(){
    while(true)
    {
    yield return new WaitForSeconds(spawnTimer);
    spawnStar();
    }
}

}
