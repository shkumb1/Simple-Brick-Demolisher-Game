using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;
    public GameManager gm;
    public Transform extralife;
    public AudioSource audio;
    public AudioSource audio1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audio = audioSources[0];
        audio1 = audioSources[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        if (!inPlay)
        {
            transform.position = paddle.position;
        }

        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Bottom"))
        {
            Debug.Log("Ball hit the bottom");
            audio1.Play();
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("brick"))
        {
            BricksController bricksController = other.gameObject.GetComponent<BricksController>();
            if (bricksController.hitsToBreak > 1)
            {
                bricksController.BreakBrick();
            }
            else
            {

                int randomDrop = Random.Range(1, 101);
                if (randomDrop < 50)
                {
                    Instantiate(extralife, other.transform.position, other.transform.rotation);
                }
                Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
                Destroy(newExplosion.gameObject, 2.5f);

                gm.UpdateScore(bricksController.points);
                gm.UpdateNumberOfBricks();
                Destroy(other.gameObject);
            }
            audio.Play();

        }

    }
}
