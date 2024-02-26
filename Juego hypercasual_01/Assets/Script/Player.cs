using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpSpeed = 10;
    [SerializeField] private bool grounded;
    [SerializeField] private float tiempo;

    private int score;
    public TextMeshPro texto;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (grounded)
        {
            Jump();
            tiempo += Time.deltaTime;
            if (tiempo >= 1)
            {
                grounded = false;
                tiempo = 0;
            }

        }

      


    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector3(-speed, transform.position.y, 0);
            
            
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector3(speed, transform.position.y, 0);

        }

    }

    

    private void Jump()
    {
        rb2d.AddForce(Vector2.up * jumpSpeed);

       
        Debug.Log("Salto");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

       
        
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground");
            grounded = true;
        
            
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            score++;

            Debug.Log(score);
            texto.text = "score: "
                + score;

        }
    }
}
