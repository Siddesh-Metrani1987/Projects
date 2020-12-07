using UnityEngine;
using System.Collections;

public class menuaudio : MonoBehaviour {

	public AudioClip menupopup;

	
	public void Menupopup () {
		GetComponent<AudioSource>().PlayOneShot(menupopup, 1.5F);
	}
	
}
