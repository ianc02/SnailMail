using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Letter")
        {
            Destroy(collision.gameObject);
            // Do stuff here
        }
        if (collision.gameObject.tag == "Cave")
        {
            Destroy(collision.gameObject);
            // Do stuff here
        }

        if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            // Do stuff here
        }
    }
}
