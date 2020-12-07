using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class distance : MonoBehaviour {


	public Text miles;
	public Text milesfinal;
    public Text finalmiles;
    public GameObject canvasObject;

    // Update is called once per frame
    void Update () {

        if (!canvasObject.activeSelf)
        {
            miles.text = ((int)transform.position.x).ToString();
            finalmiles.text = "You ran" + " " + ((int)transform.position.x).ToString() + " " + "miles";
        }
        }
}
