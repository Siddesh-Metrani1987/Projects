
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//This script destroys an object when the player picks it.(collides with it).
public class Pickup : MonoBehaviour
{

    public Text scoretext;
    public Text gameover;
    // The amount of cans we wil pick up
    private int score = 0;
    public Text scoretextfinal;
    public GameObject particle;
    public AudioClip CollectSound;
    public Text game_over;
    private Animator anim;
    public GameObject endmenu;
    public GameObject ingamedisplay;
    public GameObject buttonup;
    public GameObject buttondown;
    public AudioClip died;
    //This method is called when an object (with RigidBody2D and Collider2D) collides with this
    void OnTriggerEnter2D(Collider2D col)
    {

        // If the player collided with a fuel can
        if (col.gameObject.tag == "Can")
        {
            //Destroy the object(the one with this script attached) from the scene.	
            //Destroy (col.gameObject);
            col.gameObject.SetActive(false);
            // give a score
            score++;

            // 
            scoretext.text = "" + score;
            scoretextfinal.text = "" + score;
            gameover.text = "ok";
            //  Debug.Log("Hero's health is can " + livesCount);
            GetComponent<AudioSource>().PlayOneShot(CollectSound);
            Instantiate(particle, col.transform.position, col.transform.rotation);

        }
        if (col.gameObject.tag == "Lazer")
        {
            //Destroy the object(the one with this script attached) from the scene.	
            //Destroy (col.gameObject);
            //   col.gameObject.SetActive(false);
            // give a score

            // 
            score--;

            // 
            scoretext.text = "" + score;
            scoretextfinal.text = "" + score;



        }
        if (score == 0)
        {
            anim.SetTrigger("died");

            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Collider2D>().enabled = false;

            endmenu.SetActive(true);

            ingamedisplay.SetActive(false);
            buttonup.SetActive(false);
            buttondown.SetActive(false);

            GetComponent<AudioSource>().PlayOneShot(died, 3.0F);
            Instantiate(particle, col.transform.position, col.transform.rotation);

        }

    }
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
     

        //    canvas = GetComponent<Canvas>();
        //    Debug.Log(canvas.enabled);
    }

}