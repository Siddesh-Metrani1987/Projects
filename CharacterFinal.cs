using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
//This scrits makes the character move when the screen is pressed and handles the jump
public class CharacterFinal : MonoBehaviour
{
    public GameObject canvasObject;
    public GameObject chracter;
    public GameObject gunLight;
    public GameObject lazerz;
    public GameObject lazery;
    public Text scoretext;
    public Image img;
    // The amount of cans we wil pick up
    private int score = 5;
    public Text scoretextfinal;
    public GameObject particle;
    public AudioClip CollectSound;
    public Text game_over;

    public GameObject endmenu;
    public GameObject ingamedisplay;
    public GameObject buttonup;
    public GameObject buttondown;
    public AudioClip died;


    // float maxSpeed = 100f;
    public Rigidbody2D rb;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public bool jump = false;				// Condition for whether the player should jump.	
	public float jumpForce = 10.0f;			// Amount of force added when the player jumps.
	private bool grounded = false;			// Whether or not the player is grounded.
	public int movementSpeed = 10;			// The vertical speed of the movement
	private Animator anim;                  // The animator that controls the characters animations


    private Transform trans;
    void Start()
    {
        // rb.velocity = transform.right * maxSpeed;
        trans = GetComponent<Transform>();
        rb.freezeRotation = true;
        //rb.AddForce(Vector2.right * 100);
    }
	void Awake()
	{
		anim = GetComponent<Animator>();
	}
	void Update()
    {
        if (Input.GetKeyDown("up"))
        {

            Jump();

        }

        if (Input.GetKeyDown("down"))
        {

            Slide();

        }

        //if (Input.GetKeyDown("right"))
        //{
        // //   anim.SetTrigger("Run");
        //    //rb.velocity = trans.right * movementSpeed;
        //    //Vector2 currentPosition = trans.position;    //hero's current position
        //    //currentPosition.x = currentPosition.x + 2f;
        //    //trans.position = currentPosition;
        //    //Debug.Log("right " + "hhg");
        //    GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        //    if (jump == true)
        //    {
        //        // Add a vertical force to the player.
        //        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        //        // We set the variable to false again to avoid adding force constantly
        //        jump = false;
        //    }
        //}


        float distance = Vector2.Distance(chracter.transform.position, gunLight.transform.position);
       // Debug.Log("dis " + distance);
        if (distance<10.2f && distance>10f)
        {
            

            StartCoroutine(LateCallforBullet());

        }

      


        //bullet = GetComponent<Rigidbody2D>();
        //bullet.gravityScale = 0.8f;
        //transform.Translate(new Vector3(1, 1, 0) * 10 * Time.deltaTime, Space.Self);


        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody2D;
        //    bulletInstance.AddForce(transform.forward * maxSpeed);

        //    Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //}

        //if (Input.GetKey("right"))
        //{
        //    anim.SetInteger("Transition", 2);
        //    Vector2 currentPosition = trans.position;    //hero's current position
        //    currentPosition.x = currentPosition.x + 0.2f;
        //    trans.position = currentPosition;  //modify hero position
        //}

        //if (Input.GetKey("left"))
        //{
        //    anim.SetInteger("Transition", 2);
        //    Vector2 currentPosition = trans.position;    //hero's current position
        //    currentPosition.x = currentPosition.x - 0.2f;
        //    trans.position = currentPosition;
        //}
    }

    //This method is called when the character collides with a collider (could be a platform).
    void OnCollisionEnter2D(Collision2D hit)
	{
		grounded = true;

	}

	//The update method is called many times per seconds
	public void Jump()
	{
			
			// If the jump button is pressed and the player is grounded and the character is running forward then the player should jump.
			if(grounded == true)						
			{
				jump = true;
				grounded = false;
				//We trigger the Jump animation state
				anim.SetTrigger("Jump");
			}
		


	}

	public void Slide()
	{
		if(grounded == true)						
		{
			//slide = true;
			//We trigger the Jump animation state
			anim.SetTrigger("slide");
		}

	} 




	//Since we are using physics for movement, we use the FixedUpdate method
	void FixedUpdate ()
	{

		//if died that 
		GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y );
		//else
		//moving
	
		
		// If jump is set to true we add a quick force impulse for the jump
		if(jump == true)
		{
			// Add a vertical force to the player.
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
			
			// We set the variable to false again to avoid adding force constantly
			jump = false;
		}
	}

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "bul")
        {
            //Destroy the object(the one with this script attached) from the scene.	
            //Destroy (col.gameObject);
            col.gameObject.SetActive(false);
            score--;
            anim.SetTrigger("burn");
            // 
            scoretext.text = "" + score;
            scoretextfinal.text = "" + score;
            // give a score
            GetComponent<AudioSource>().PlayOneShot(died, 3.0F);

        }





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
            //game_over.enabled = true;

            //game_over.text = "ok";
            //  Debug.Log("Hero's health is can " + livesCount);
            GetComponent<AudioSource>().PlayOneShot(CollectSound);
            //Instantiate(particle, col.transform.position, col.transform.rotation);

        }


        if (col.gameObject.tag == "coin_c")
        {
            //Destroy the object(the one with this script attached) from the scene.	
            //Destroy (col.gameObject);
            col.gameObject.SetActive(false);
            // give a score
            score++;

            // 
            scoretext.text = "" + score;
            scoretextfinal.text = "" + score;
            //game_over.enabled = true;

            //game_over.text = "ok";
            //  Debug.Log("Hero's health is can " + livesCount);
            GetComponent<AudioSource>().PlayOneShot(CollectSound);
            //Instantiate(particle, col.transform.position, col.transform.rotation);

        }
        if (col.gameObject.tag == "Lazer")
        {
            //Destroy the object(the one with this script attached) from the scene.	
            //Destroy (col.gameObject);
            //   col.gameObject.SetActive(false);
            // give a score

            // 
            anim.SetTrigger("burn");
            score--;
            score--;
            // 
            scoretext.text = "" + score;
            scoretextfinal.text = "" + score;
            GetComponent<AudioSource>().PlayOneShot(died, 3.0F);
           

        }
        if (col.gameObject.tag == "key_s")
        {
            col.gameObject.SetActive(false);
            lazerz.SetActive(false);
            lazery.SetActive(false);
            // Destroy(GameObject.FindGameObjectWithTag("Lazer"));
            //GameObject.FindGameObjectWithTag("Lazer").SetActive(false);
            //GameObject.Find("Lazer").SetActive(false);
            GetComponent<AudioSource>().PlayOneShot(CollectSound);
            StartCoroutine(LateCall());
        }

        if (score == 0 || score<0)
        {
      
            anim.SetTrigger("died");

            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Collider2D>().enabled = false;


            ingamedisplay.SetActive(false);
            buttonup.SetActive(false);
            buttondown.SetActive(false);

            canvasObject.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(died, 3.0F);
            //Instantiate(particle, col.transform.position, col.transform.rotation);

        }

    }

    IEnumerator LateCall()
    {

       yield return new WaitForSeconds(15);

       lazery.SetActive(true);

        lazerz.SetActive(true);
        //Do Function here...
    }

    IEnumerator LateCallforBullet()
    {

        yield return new WaitForSeconds(1);

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Do Function here...
    }

}
