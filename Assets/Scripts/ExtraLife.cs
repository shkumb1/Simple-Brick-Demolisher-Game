using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    public float speed;

    private void Start()
    {
    }

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);

        if (transform.position.y < -6.2f)
        {
            Destroy(gameObject);
        }
    }

}
