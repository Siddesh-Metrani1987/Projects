using UnityEngine;
using System.Collections;

public class characteraudio : MonoBehaviour {

	public AudioClip footstep;
	public AudioClip jump;
	public AudioClip jumpdown;
	
	public void Footset () {
		GetComponent<AudioSource>().PlayOneShot(footstep, 10.0F);
	}



	public void Jump () {
		GetComponent<AudioSource>().PlayOneShot(jump, 1.0F);
	}

	public void JumpDown () {
		GetComponent<AudioSource>().PlayOneShot(jumpdown, 2.0F);
	}
}
