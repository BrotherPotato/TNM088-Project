using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class oldBird : MonoBehaviour
{
    /*
    // Start is called before the first frame update
    void Start()
    {
        Hello
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
    private void Update()
    {
        //GetComponent<LineRenderer>().SetPosition(0, _initialPosition);
        //GetComponent<LineRenderer>().SetPosition(1, transform.position);
        if(_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }
        if((transform.position.y > 10) || (transform.position.y < -10) || 
        (transform.position.x > 10) || (transform.position.x < -10) ||
        (_timeSittingAround > 3))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private Vector3 _initialPosition;
    private bool _birdWasLaunched;
    private float _timeSittingAround;
    [SerializeField] private float _launchPower = 500;
   

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        //GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;

        //GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);

    }
}
