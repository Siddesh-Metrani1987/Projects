using UnityEngine;
using System.Collections;

public class pooling : MonoBehaviour
{


    public GameObject otherpref;
    public GameObject fuelcan;
    public GameObject lazer;
    public GameObject coin;
    void OnTriggerEnter2D(Collider2D other)
    {

        //			
        int spawncan = Random.Range(0, 2);
        if (spawncan == 0)
        {
            fuelcan.SetActive(false);
           // lazer.SetActive(true);
            coin.SetActive(true);
        }

        if (spawncan == 1)
        {
            fuelcan.SetActive(true);
          //  lazer.SetActive(false);
            coin.SetActive(false);
        }

  

        // prefabToMove.transform.position = new Vector2(prefabToMove.transform.position.x + incrementX, prefabToMove.transform.position.y);
        // GameObject[] temp = GameObject.FindGameObjectsWithTag("prefab1");


        otherpref.transform.position= new Vector2(otherpref.transform.position.x + (72), 0);





        //  otherpref.transform.position.x = otherpref.transform.position.x + (72);
        //  otherpref.transform.position.y = 0;

    }



}