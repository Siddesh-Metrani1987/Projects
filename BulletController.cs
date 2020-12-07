using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
       // transform.position += Vector3.left * Time.deltaTime;
        rb.velocity = Vector2.left * speed;

    }
    //void OnTriggerEnter2D(Collider2D col)
    //{

    //    // If the player collided with a fuel can
    //    if (col.gameObject.tag == "bul")
    //    {
    //        //Destroy the object(the one with this script attached) from the scene.	
    //        //Destroy (col.gameObject);
    //        col.gameObject.SetActive(false);
    //        // give a score


    //    }


    //}
}
