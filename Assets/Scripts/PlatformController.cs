using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private float dir = 1f;
    public Rigidbody2D rb2d;

    void Update()
    {
        rb2d.velocity = Vector2.right*dir;
    }
    private void changeDir()
    {
        dir *= -1f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "platformWall")
        {
            changeDir();
        }
    }
}
