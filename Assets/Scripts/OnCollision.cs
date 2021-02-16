using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{

    Rigidbody2D body;
    private bool key;
    private bool mail;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        key = false;
        mail = false;
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
            mail = true;
        }
        if (collision.gameObject.tag == "Cave")
        {
            Destroy(collision.gameObject);
            body.transform.position = new Vector2(2, 18);
        }

        if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            body.transform.position = new Vector2(-1, 0);
            key = true;
        }

        if (collision.gameObject.tag == "Lock" && key)
        {
            Destroy(collision.gameObject);
            // Do stuff here
        }

        if (collision.gameObject.tag == "Mailbox" && mail)
        {
            Destroy(collision.gameObject);
            GameManager.Instance.GameOver();
            
        }
    }
}
