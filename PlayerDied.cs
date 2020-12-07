using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerDied : MonoBehaviour
{

    //public Animator childAnimtor;

    private Animator anim;
    public GameObject endmenu;
    public GameObject ingamedisplay;
    public GameObject buttonup;
    public GameObject buttondown;
    public AudioClip died;
    public GameObject particle;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        //tag
        if (col.gameObject.tag == "Lazer")
        {


            // anim.SetTrigger("died");

            //  GetComponent<Rigidbody2D>().isKinematic = true;
            //   GetComponent<Collider2D>().enabled = false;

            //  endmenu.SetActive(true);
            // ingamedisplay.SetActive(false);
            //  buttonup.SetActive(false);
            // buttondown.SetActive(false);

         //   GetComponent<AudioSource>().PlayOneShot(died, 3.0F);
           // Instantiate(particle, col.transform.position, col.transform.rotation);
        }
    }
}
