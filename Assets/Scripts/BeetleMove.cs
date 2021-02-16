using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleMove : MonoBehaviour
{
    public List<GameObject> locs;

    private Queue<GameObject> qlocs;

    public float duration = 5f;

    private AudioSource audioSource;

    Rigidbody2D body;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody2D>();
        qlocs = new Queue<GameObject>();
        foreach (GameObject go in locs)
        {
            qlocs.Enqueue(go);

        }
        NextUp();
    }


    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(0, speed);
    }


    void NextUp()
    {
        GameObject pong = qlocs.Dequeue();

        StartCoroutine(LerpPosition(pong.transform.position));

        qlocs.Enqueue(pong);
    }


    IEnumerator LerpPosition(Vector3 targetPosition)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        NextUp();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
        }
   }


}
