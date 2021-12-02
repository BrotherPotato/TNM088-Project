using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ananas : MonoBehaviour
{
    public Transform ananasTransform;
    public Vector3 ananasPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3[] pos;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3[2];
        ananasTransform = GetComponent<Transform>();
        ananasPos = transform.position;
        pos[0] = new Vector3(transform.position.x, transform.position.y + 1f, 0f);
        pos[1] = new Vector3(transform.position.x, transform.position.y - 1f, 0f);
        //print(pos[0]);
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
