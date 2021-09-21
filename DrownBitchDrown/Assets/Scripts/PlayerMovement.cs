using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 velocity;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
        speed = speed / 10;
    }

    // Update is called once per frame
    void Update()
    {
        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = Input.GetAxis("Vertical");
        gameObject.transform.position += velocity * speed;
    }
}
