using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class convBelt : MonoBehaviour
{
    [SerializeField]
    private float beltSpeed;

    private Rigidbody2D rb;
    private bool inContact = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rb != null && inContact)
        {
            rb.AddForce(Vector3.left * beltSpeed);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("yes");
        inContact = true;
        rb = col.gameObject.GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(-1000f, rb.velocity.y); 
    }
    void OnCollisionExit2D(Collision2D col){
        Debug.Log("yes");
        inContact = false;
        rb = col.gameObject.GetComponent<Rigidbody2D>();
    }
}
