using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Collider2D col2d;
    void Start()
    {
        rb2d.AddForce(Vector2.up*5,ForceMode2D.Impulse);
        col2d.enabled=false;
        Invoke("CoinStop",1f);
    }
    void CoinStop() {
        col2d.enabled=true;
        rb2d.isKinematic=true;
        rb2d.velocity=Vector2.zero;
    }
}
