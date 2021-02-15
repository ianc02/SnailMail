using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleMove : MonoBehaviour
{

    Rigidbody2D body;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(0, speed);
    }
}
