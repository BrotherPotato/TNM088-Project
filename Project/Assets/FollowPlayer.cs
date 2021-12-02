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

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.Rotate(0, 0, -90);
        sprite = GetComponent<SpriteRenderer>();

        GameObject player = GameObject.Find("Player");
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
        posX = posX/Mathf.Abs(posX);

        if(posX < 0)
        sprite.flipY = true;
        
        if(posX > 0)
        sprite.flipY = false;

        //posX = playerController.moveBy;
        offset = new Vector3(posX * 1f, 0, 0);
        transform.position = Vector3.Lerp(transform.position, objectToFollow.position + offset, Time.deltaTime);

    }
}
