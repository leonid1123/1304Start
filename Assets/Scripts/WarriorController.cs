using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour
{
    public Rigidbody2D rb2d; //для работы с физ телом
    private float speed = 600f; //для изменения скорости
    private bool toRight = true; //для отслеживания куда идём

    public groundCheck groundCheck;

    void Start()
    {

    }
    void Update()
    {
        //меняем скорость
        rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, rb2d.velocity.y);
        if(toRight && rb2d.velocity.x<0)//если идем направо, но скорость отрицательная
        {
            toRight = false; //направо не идем
            gameObject.GetComponent<SpriteRenderer>().flipX = true; //повернуться налево
        }
        if(!toRight && rb2d.velocity.x>0)//если идем налево, но скорость положительная
        {
            toRight = true; //налево не идем
            gameObject.GetComponent<SpriteRenderer>().flipX = false; //повернуться
        }
        if (Input.GetButton("Jump") && groundCheck.isGround())
        {
            rb2d.velocity = Vector2.up*8f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //пересечение с объектом
    {
        if (collision.tag == "Key") //если имя объекта с которым пересеклись это KEY
        {
            InvokeRepeating("BlinkBlue",0f,0.2f);
            InvokeRepeating("BlinkWhite", 0.1f, 0.2f);
            Invoke("CancelInvoke", 1f);
            GameObject.Find("Canvas").GetComponent<KeyCount>().AddKey();
            Destroy(collision.gameObject); //уничтожить ТОТ объект
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
