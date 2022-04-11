using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour {
    public Rigidbody2D rb2d;
    public SpriteRenderer spr;
    public Animator anim;
    public int slimeHp = 10;
    int dir = 1;
    private void Start() {
        RunState(dir);
    }
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "mobWall") {
            StartCoroutine(IdleState());
        }
    }
    private IEnumerator IdleState() {
        anim.SetBool("isIdle", true);
        rb2d.velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        dir *= -1;
        spr.flipX = !spr.flipX;
        RunState(dir);
    }
    private void RunState(int _dir) {
        anim.SetBool("isIdle", false);
        rb2d.velocity = Vector2.left * _dir;
    }
}
