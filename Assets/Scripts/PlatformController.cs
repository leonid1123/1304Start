using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private float dir = 1f;
    private void Start()
    {
        InvokeRepeating("changeDir",0f,2.4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right*0.005f*dir,Space.World);
    }
    private void changeDir()
    {
        dir *= -1f;
    }
}
