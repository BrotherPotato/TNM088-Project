using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisions : MonoBehaviour
{
    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start() {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag=="ground"){
            Debug.Log("hej");
            playerRb.gravityScale = 0;
            playerRb.velocity = new Vector3(0f, 0, 0);
        }
    }
    void OnTriggerExit2D(Collider2D col){
        playerRb.gravityScale = 1;
    }
}
