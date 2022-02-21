using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    private bool ground = false;
    public bool isGround()
    {
        return ground;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            ground = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag=="ground" )
        {
            ground=false;
        }
    }
}
