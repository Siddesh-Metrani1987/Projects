using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    public Text tv;
    public void PauseGameBtn()
    {

if(tv.text=="Pause")
        {
            Time.timeScale = 0;
            tv.text = "Resume";
        }
        else
        {
            Time.timeScale = 1;
            tv.text = "Pause";
        }
      
  
        // pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    }
  
}
