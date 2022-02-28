using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour
{
    public Rigidbody2D rb2d; //��� ������ � ��� �����
    private float speed = 600f; //��� ��������� ��������
    private bool toRight = true; //��� ������������ ���� ���

    public groundCheck groundCheck;

    void Start()
    {

    }
    void Update()
    {
        //������ ��������
        rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, rb2d.velocity.y);
        if(toRight && rb2d.velocity.x<0)//���� ���� �������, �� �������� �������������
        {
            toRight = false; //������� �� ����
            gameObject.GetComponent<SpriteRenderer>().flipX = true; //����������� ������
        }
        if(!toRight && rb2d.velocity.x>0)//���� ���� ������, �� �������� �������������
        {
            toRight = true; //������ �� ����
            gameObject.GetComponent<SpriteRenderer>().flipX = false; //�����������
        }
        if (Input.GetButton("Jump") && groundCheck.isGround())
        {
            rb2d.velocity = Vector2.up*8f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //����������� � ��������
    {
        if (collision.tag == "Key") //���� ��� ������� � ������� ����������� ��� KEY
        {
            InvokeRepeating("BlinkBlue",0f,0.2f);
            InvokeRepeating("BlinkWhite", 0.1f, 0.2f);
            Invoke("CancelInvoke", 1f);
            GameObject.Find("Canvas").GetComponent<KeyCount>().AddKey();
            Destroy(collision.gameObject); //���������� ��� ������
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
