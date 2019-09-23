using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour {

    public float speed;
    public Text counttext;
    public Text wintext;
    private Rigidbody2D rb2d;
    private int count;
    private int enemycount;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        wintext.text = "";
        setcounttext();
        enemycount = 0;
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setcounttext();
        }
        if (other.gameObject.CompareTag ("enemy"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            enemycount = enemycount + 1;
            setcounttext();
        }
    }
    void setcounttext ()
    {
        counttext.text = "Count: " + count.ToString();
        if (count == (12 - enemycount))
        {
            transform.position = new Vector3(65, 0, 0);
        }
        if (count >= (20 - enemycount))
        {
            wintext.text = "you win! Game created by Dylan Whiteman!";
        }
    }
}
