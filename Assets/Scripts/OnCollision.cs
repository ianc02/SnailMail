using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{

    Rigidbody2D body;
    private bool key;
    private bool mail;

    public AudioSource crunch;
    public AudioSource success;
    public AudioSource climb;
    public AudioSource completion;
    public AudioSource victory;
    public AudioSource music;
    ParticleSystem particles;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        particles = gameObject.GetComponentsInChildren<ParticleSystem>()[0];
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
            completion.Play();
            Destroy(collision.gameObject);
            mail = true;
        }

        if (collision.gameObject.tag == "Cave")
        {
            climb.Play();
            body.transform.position = new Vector2(2, 18);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Key")
        {
            climb.Play();
            completion.Play();
            body.transform.position = new Vector2(11, 9);
            key = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Lock" && key)
        {
            success.Play();
            Destroy(collision.gameObject);
            // Do stuff here
        }

        if (collision.gameObject.tag == "Mailbox" && mail)
        {
            victory.Play();
            GameManager.Instance.GameOver();
        }

        if (collision.gameObject.tag == "Beetle")
        {
            crunch.Play();
            particles.Play();
            wait(5);
            GameManager.Instance.GameOver();
            Destroy(collision.gameObject);
        }
    }

    IEnumerator wait(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
