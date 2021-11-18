using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody2D playerRb;
    
    float horizontal;
    float vertical;

    public float runSpeed = 1f;
    public float jumpForce = 1f;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate(){
        playerRb.velocity= new Vector2(horizontal*runSpeed, vertical * jumpForce);
    }
}
