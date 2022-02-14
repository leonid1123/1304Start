using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour
{
    public Rigidbody2D rb2d; //��� ������ � ��� �����
    private float speed = 500f; //��� ��������� ��������
    private bool toRight = true; //��� ������������ ���� ���
    void Start()
    {

    }

    void Update()
    {
        //������ ��������
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, rb2d.velocity.y);
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
    }

    private void OnTriggerEnter2D(Collider2D collision) //����������� � ��������
    {
        if (collision.name == "Key") //���� ��� ������� � ������� ����������� ��� KEY
        {
            Destroy(collision.gameObject); //���������� ��� ������
        }
    }

}
