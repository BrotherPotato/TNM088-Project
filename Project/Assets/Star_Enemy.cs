using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Enemy : MonoBehaviour
{

    public GameObject player;
    [SerializeField]
    private float speed;
    private Vector3 playerPos;
    private Vector3 movementVector = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerPos = player.transform.position;
        movementVector = (playerPos - transform.position).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, playerPos, Time.deltaTime * Random.Range(speed, 2 * speed));
        transform.position += movementVector * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
    }

}
