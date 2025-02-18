using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3[] pos;

    private int index = 0;

    public bool rotatePingPong = true;

    SpriteRenderer sprite;

    void Start(){
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pos[index], Time.deltaTime * speed);
        if(transform.position.x - pos[index].x < 0)
        sprite.flipX = true;
        else
        sprite.flipX = false;
        if(rotatePingPong)
        {
            transform.Rotate(Vector3.forward * -180 * Time.deltaTime);
        }
        

        if(transform.position == pos[index])
        {

            if(index == pos.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }

    }

}
