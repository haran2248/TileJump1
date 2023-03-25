using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaMove : MonoBehaviour
{
    // Start is called before the first frame update
    /* public GameObject ob;
     public Rigidbody2D rb;
     private int time = 0;
     private float dirY=0f;
     public bool flag = true;
     void Start()
     {
         rb = GetComponent<Rigidbody2D>();
     }
     // Update is called once per frame
     void Update()
     {
         dirY = Input.GetAxis("Vertical");
         Debug.Log("flag:" + flag);
         Debug.Log("time:" + time);
         if(time<=25&&flag)
         {
             rb.velocity = new Vector2(rb.velocity.x,7f);
             time++;
         }
         else if(time>=0)
         {
             rb.velocity = new Vector2(rb.velocity.x,-7f);
             flag = false;
             time--;
         }
         else if(time<0)
         {
             flag = true;
             time++;

         }
         */
    public float amplitude = 10f;  // The amplitude of the oscillation
    public float frequency = 4f;    // The frequency of the oscillation

    private Vector2 startPos;       // The starting position of the object

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float y = startPos.y + amplitude * Mathf.Sin(frequency * Time.time);
        transform.position = new Vector2(transform.position.x,y);
    }

}

