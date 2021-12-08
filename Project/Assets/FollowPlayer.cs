using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;
    playerController _playerC;

    public SpriteRenderer sprite;
    public float posX;

    public float rotSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.transform.Rotate(0, 0, -90);
        sprite = GetComponent<SpriteRenderer>();

        GameObject player = GameObject.Find("Player");
        objectToFollow = player.GetComponent<Transform>();
        //playerController playerController = player.GetComponent<playerController>();
        //posX = GameObject.Find("Player").GetComponent<playerController>().moveBy;

        _playerC = FindObjectOfType<playerController>();
        posX = _playerC.moveBy;
        //posX = playerController.moveBy;
        offset = new Vector3(posX, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
       //transform.position = objectToFollow.position + offset;

        posX = _playerC.moveBy;
        
        if(posX != 0)
        {
            posX = posX/Mathf.Abs(posX);
        }
        
        
        if(posX < 0)
        {
            sprite.flipX = true;
        }
        
        
        if(posX > 0)
        {
            sprite.flipX = false;
        }
        

        //posX = playerController.moveBy;
        offset = new Vector3(posX * 1f, 0, 0);
        transform.position = Vector3.Lerp(transform.position, objectToFollow.position + offset, Time.deltaTime);


        Vector2 direction = objectToFollow.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);
        //this.gameObject.transform.Rotate(0, 0, -90);
    }
}
