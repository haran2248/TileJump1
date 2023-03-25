using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itemcollector : MonoBehaviour
{
    // Start is called before the first frame update
    private int cherries = 0;
    private Rigidbody2D rb;

    [SerializeField] private Text cherriesText;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherries++;
            Debug.Log("Cherries:" + cherries);
            cherriesText.text = "Cherries:" + cherries;

        }
        if(collision.gameObject.CompareTag("Classroom"))
        {
            Destroy(collision.gameObject);
            cherries += 5;
            Debug.Log("Cherries:" + cherries);
            cherriesText.text = "Cherries:" + cherries;
        }
        if (collision.gameObject.CompareTag("Questt"))
        {
            Debug.Log("Collided with Questt");
            rb.velocity = new Vector2(rb.velocity.x, 15f);
        }


    }
}
