using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxSpawner : MonoBehaviour
{
    public GameObject boxPrefab;

    [SerializeField]
    public float spawnTimer;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawningBoxes());
    }
    private void spawnBox(){
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        GameObject s = Instantiate(boxPrefab) as GameObject;
        s.transform.position = new Vector2(transform.position.x, (transform.position.y + 1f));
    }



IEnumerator spawningBoxes(){
    while(true)
    {
    yield return new WaitForSeconds(spawnTimer);
    spawnBox();
    }
}
}
