using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour
{
    public Rigidbody2D rb2d; //для работы с физ телом
    private float speed = 500f; //для изменения скорости
    private bool toRight = true; //для отслеживания куда идём
    void Start()
    {

    }

    void Update()
    {
        //меняем скорость
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, rb2d.velocity.y);
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
    }

    private void OnTriggerEnter2D(Collider2D collision) //пересечение с объектом
    {
        if (collision.name == "Key") //если имя объекта с которым пересеклись это KEY
        {
            Destroy(collision.gameObject); //уничтожить ТОТ объект
        }
    }

}
