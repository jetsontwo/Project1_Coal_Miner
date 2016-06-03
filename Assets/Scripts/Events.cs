using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour {

    public Text event_text;
	// Use this for initialization
	void Start () {
	    if(PlayerPrefs.GetString("Event") == "coal_price_drop")
        {
            event_text.text = "Over the night the market for coal crashes, each coal block is now worth less.";
        }
        else if (PlayerPrefs.GetString("Event") == "coal_price_inc")
        {
            event_text.text = "Over the night the price for coal sky-rockets, each coal block is now worth more.";
        }
        else if(PlayerPrefs.GetString("Event") == "coal_freq_drop")
        {
            event_text.text = "Late last night some miners accidently caused a cave in at part of the mine, now there are less coal blocks to find";
        }
        else if(PlayerPrefs.GetString("Event") == "time_in_mine_drop")
        {
            event_text.text = "Due to the decreasing economy, the company has cut your hours in the mines to save money, you now have less time to get coal";
        }
        else
        {
            event_text.text = "You go to bed, weary and tired, but everything stays the same";
        }
	}

    public void switch_scene()
    {
        SceneManager.LoadScene(1);
    }
	
}
