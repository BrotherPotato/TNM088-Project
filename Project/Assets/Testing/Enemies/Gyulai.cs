using UnityEngine;

public class Gyulai : MonoBehaviour
{
    [SerializeField] private GameObject _gyulaiParticlePrefab;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        /*
        bool didHitBird = collision.collider.GetComponent<Circle>() != null;
        if(didHitBird)
        {
            Destroy(gameObject);
        }
        */
        oldBird circle = collision.collider.GetComponent<oldBird>();
        if(circle != null)
        {
            Instantiate(_gyulaiParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
            return;
        } 
        Gyulai enemy = collision.collider.GetComponent<Gyulai>();
        if(enemy != null) 
        {
            return;
        }
        if(collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_gyulaiParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
        
    }
}
