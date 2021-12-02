using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.ParticleSystem;

public class OnCollisionDestroy : MonoBehaviour
{
    [SerializeField] private GameObject _BrownParticlePrefab;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject s = col.gameObject;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if(this.gameObject.tag == "boom")
        {
            if((Mathf.Abs(rb.velocity.x) > 10f || Mathf.Abs(rb.velocity.y) > 10f) && s.gameObject.tag != "boomIg")
            {
                
                //ParticleSystem.Clear();
                GameObject particles = (GameObject)Instantiate(_BrownParticlePrefab, transform.position, Quaternion.identity);
                
                Destroy(this.gameObject);
            } 
        } else 
        {
            Destroy(s);
            Destroy(this.gameObject);
        }
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
       GameObject s = col.gameObject;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if(this.gameObject.tag == "boom")
        {
            if((Mathf.Abs(rb.velocity.x) > 10f || Mathf.Abs(rb.velocity.y) > 10f) && s.gameObject.tag != "boomIg")
            {
                Instantiate(_BrownParticlePrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            } 
        } else 
        {
            Destroy(s);
            Destroy(this.gameObject);
        }
    }
}
