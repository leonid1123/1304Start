using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarriorController : MonoBehaviour {
    public Rigidbody2D rb2d;
    public Animator animator;
    private float speed = 200f;
    private bool toRight = true;
    bool onPlatform = false;
    public groundCheck groundCheck;
    public Transform atkPoint;


    AnimatorClipInfo[] m_AnimatorClipInfo;
    void Start() {

    }
    void Update() {

        m_AnimatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        AnimationClip clipName = m_AnimatorClipInfo[0].clip;
        if (!onPlatform) {
            rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, rb2d.velocity.y);
            animator.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));
        }
        if (clipName.name.ToString().Equals("atk1")) { //conditions to stop movement
            rb2d.velocity = new Vector2(0f, 0f);
            Collider2D[] overlapedObjects = Physics2D.OverlapCircleAll(new Vector2(atkPoint.position.x,atkPoint.position.y),0.2f);
            foreach(Collider2D coll in overlapedObjects) {
                if (coll.tag=="Vaza") {
                    coll.GetComponent<Vazzza>().Crash();
                }
            } 
        }
        if (toRight && rb2d.velocity.x < 0) {
            toRight = false;
            transform.Rotate(new Vector3(0f, 180f, 0f));
            //gameObject.GetComponent<SpriteRenderer>().flipX = true; 
        }
        if (!toRight && rb2d.velocity.x > 0) {
            toRight = true;
            transform.Rotate(new Vector3(0f, 180f, 0f));
            //gameObject.GetComponent<SpriteRenderer>().flipX = false; 
        }
        if (Input.GetButton("Jump") && groundCheck.isGround()) {
            animator.SetBool("isJump", true);
            rb2d.velocity = Vector2.up * 8f;
        }
        if (Input.GetButtonDown("Fire3")) {
            animator.SetTrigger("isAtk");

        }
        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene("SampleScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Key") {
            InvokeRepeating("BlinkBlue", 0f, 0.2f);
            InvokeRepeating("BlinkWhite", 0.1f, 0.2f);
            Invoke("CancelInvoke", 1f);
            GameObject.Find("Canvas").GetComponent<KeyCount>().AddKey();
            Destroy(collision.gameObject);
        }
        if (collision.tag=="Chest") {
            int keys = GameObject.Find("Canvas").GetComponent<KeyCount>().GetKeysCount();
            if (keys>0) {
                collision.GetComponent<ChestController>().OpenSelf();
                GameObject.Find("Canvas").GetComponent<KeyCount>().RemoveKey();
            }
        }
        if (collision.tag=="Coin") {
            GameObject.Find("Canvas").GetComponent<KeyCount>().AddCoin();
            Destroy(collision.gameObject);
        }
        if (collision.name == "Restart") {
            SceneManager.LoadScene("SampleScene");
        }
    }
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.name == "Lever" && Input.GetKeyDown(KeyCode.F)) {
            collision.GetComponent<LeverController>().LeverChange();
        }
        if (collision.tag == "platform") {
            onPlatform = true;
            float plSpd = GameObject.Find("Platform").GetComponent<Rigidbody2D>().velocity.x;

            rb2d.velocity = new Vector2(plSpd, rb2d.velocity.y) + new Vector2(Input.GetAxisRaw("Horizontal") * speed / 25 * Time.deltaTime, rb2d.velocity.y);
            animator.SetFloat("speed", 0f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "platform") {
            onPlatform = false;
        }
    }
    public void BlinkBlue() {
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
    }
    public void BlinkWhite() {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
