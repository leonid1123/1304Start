using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarriorController : MonoBehaviour
{
    public Rigidbody2D rb2d; //��� ������ � ��� �����
    private float speed = 600f; //��� ��������� ��������
    private bool toRight = true; //��� ������������ ���� ���
    bool onPlatform = false;
    public groundCheck groundCheck;

    void Start()
    {

    }
    void Update()
    {
        //������ ��������
        if (!onPlatform)
        {
            rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, rb2d.velocity.y);
        }


        if (toRight && rb2d.velocity.x < 0)//���� ���� �������, �� �������� �������������
        {
            toRight = false; //������� �� ����
            transform.Rotate(new Vector3(0f, 180f,0f));
            //gameObject.GetComponent<SpriteRenderer>().flipX = true; //����������� ������
        }
        if (!toRight && rb2d.velocity.x > 0)//���� ���� ������, �� �������� �������������
        {
            toRight = true; //������ �� ����
            transform.Rotate(new Vector3(0f, 180f, 0f));
            //gameObject.GetComponent<SpriteRenderer>().flipX = false; //�����������
        }
        if (Input.GetButton("Jump") && groundCheck.isGround())
        {
            rb2d.velocity = Vector2.up * 8f;
        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //����������� � ��������
    {
        if (collision.tag == "Key") //���� ��� ������� � ������� ����������� ��� KEY
        {
            InvokeRepeating("BlinkBlue", 0f, 0.2f);
            InvokeRepeating("BlinkWhite", 0.1f, 0.2f);
            Invoke("CancelInvoke", 1f);
            GameObject.Find("Canvas").GetComponent<KeyCount>().AddKey();
            Destroy(collision.gameObject); //���������� ��� ������
        }
        if (collision.name == "Restart")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "platform")
        {
            onPlatform = true;
            float plSpd = GameObject.Find("Platform").GetComponent<Rigidbody2D>().velocity.x;
            rb2d.velocity = new Vector2(plSpd, rb2d.velocity.y) + new Vector2(Input.GetAxisRaw("Horizontal") * speed/50 * Time.deltaTime, rb2d.velocity.y);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "platform")
        {
            onPlatform = false;
        }
    }
    public void BlinkBlue()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    public void BlinkWhite()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

}
