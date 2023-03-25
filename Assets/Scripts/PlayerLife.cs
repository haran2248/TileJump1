using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private Rigidbody2D rb;
    public TMP_Text lifeText;
    public RawImage i1, i2, i3, i4, i5;
    int life = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        lifeText.text="Life:"+life;
        if(life==0)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Spike"))
        {
            life--;
            if (life == 5)
            {
                Destroy(i5);
            }
            if (life==4)
            {
                Destroy(i1);
            }
            if(life==3)
            {
                Destroy(i2);
            }
            if(life==2)
            {
                Destroy(i3);
            }
            if (life==1)
            {
                Destroy(i4);
            }
            Destroy(i1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Spike"))
        {
            life--;
            //Destroy(i2);
        }
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }
    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
