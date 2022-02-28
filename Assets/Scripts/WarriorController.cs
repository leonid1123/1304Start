using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarriorController : MonoBehaviour
{
    public Rigidbody2D rb2d; //для работы с физ телом
    private float speed = 600f; //для изменения скорости
    private bool toRight = true; //для отслеживания куда идём
    bool onPlatform = false;
    public groundCheck groundCheck;

    void Start()
    {

    }
    void Update()
    {
        //меняем скорость
        if (!onPlatform)
        {
            rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, rb2d.velocity.y);
        }


        if (toRight && rb2d.velocity.x < 0)//если идем направо, но скорость отрицательная
        {
            toRight = false; //направо не идем
            transform.Rotate(new Vector3(0f, 180f,0f));
            //gameObject.GetComponent<SpriteRenderer>().flipX = true; //повернуться налево
        }
        if (!toRight && rb2d.velocity.x > 0)//если идем налево, но скорость положительная
        {
            toRight = true; //налево не идем
            transform.Rotate(new Vector3(0f, 180f, 0f));
            //gameObject.GetComponent<SpriteRenderer>().flipX = false; //повернуться
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

    private void OnTriggerEnter2D(Collider2D collision) //пересечение с объектом
    {
        if (collision.tag == "Key") //если имя объекта с которым пересеклись это KEY
        {
            InvokeRepeating("BlinkBlue", 0f, 0.2f);
            InvokeRepeating("BlinkWhite", 0.1f, 0.2f);
            Invoke("CancelInvoke", 1f);
            GameObject.Find("Canvas").GetComponent<KeyCount>().AddKey();
            Destroy(collision.gameObject); //уничтожить ТОТ объект
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
