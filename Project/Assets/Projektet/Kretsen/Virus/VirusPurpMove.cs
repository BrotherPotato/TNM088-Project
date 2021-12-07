using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusPurpMove : MonoBehaviour
{
    public Transform virusTransform;
    public Vector3 virusPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3[] pos;

    private int index = 0;

    public float bounce;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3[2];
        virusTransform = GetComponent<Transform>();
        virusPos = transform.position;
        pos[0] = new Vector3(transform.position.x, transform.position.y + bounce, 0f);
        pos[1] = new Vector3(transform.position.x, transform.position.y - bounce, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pos[index], Time.deltaTime * speed);

        //transform.Rotate(Vector3.forward * -180 * Time.deltaTime);

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
