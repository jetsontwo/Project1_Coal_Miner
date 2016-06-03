using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene_Switcher : MonoBehaviour {

    bool game_over;
	// Use this for initialization
	public void Change_Scene () {
        game_over = false;
        if (SceneManager.GetSceneByName("Platform") == SceneManager.GetActiveScene())
        {
            
            SceneManager.LoadScene(2);

        }
        else
        {
            PlayerPrefs.SetInt("Night_Count", 1 + PlayerPrefs.GetInt("Night_Count"));
            Check_Family();
            if (!game_over)
            {
                Try_Random_Event();
            }
        }

	}

    public void Check_Family()
    {
        //Lowers the family's stats and checks to make sure they dont get >= 100, otherwise game over  
        //if their hunger or cold are greater than 50 then their sickness raises by 10
        PlayerPrefs.SetInt("cold_Kid", PlayerPrefs.GetInt("cold_Kid") + 20);
        PlayerPrefs.SetInt("hunger_Kid", PlayerPrefs.GetInt("hunger_Kid") + 20);
        PlayerPrefs.SetInt("cold_Wife", PlayerPrefs.GetInt("cold_Wife") + 20);
        PlayerPrefs.SetInt("hunger_Wife", PlayerPrefs.GetInt("hunger_Wife") + 20);



        if (PlayerPrefs.GetInt("cold_Kid") >= 100 || PlayerPrefs.GetInt("hunger_Kid") >= 100 || PlayerPrefs.GetInt("cold_Wife") >= 100 || PlayerPrefs.GetInt("hunger_Kid") >= 100)
        {
            SceneManager.LoadScene(3);
            game_over = true;
        }
    }

    public void Try_Random_Event()
    {
        int rand = 0;
        PlayerPrefs.SetString("Event", "None");
        //says on transition if any event happens or says nothing happened
        if (PlayerPrefs.GetInt("Night_Count") >= 2)
        {
            rand = Random.Range(0, 100);
            print(rand);
        }

        if (rand > 60 && rand < 100)
        {
            print("dsfadas");
            if (PlayerPrefs.GetInt("coal_price") > 2)
            {
                print("sdfasdadfas");
                PlayerPrefs.SetInt("coal_price", PlayerPrefs.GetInt("coal_price") - 1);
                PlayerPrefs.SetString("Event", "coal_price_drop");
            }
        }
        else if (rand > 10 && rand < 20)
        {
            //Food Price Increases
        }
        else if(rand > 20 && rand < 30)
        {
            PlayerPrefs.SetInt("coal_freq", (PlayerPrefs.GetInt("coal_freq") + 1));
            PlayerPrefs.SetString("Event", "coal_freq_drop");

        }
        else if(rand > 30 && rand < 50)
        {
            if(PlayerPrefs.GetInt("time_in_mine") > 30)
            {
                print("dasfads");
                PlayerPrefs.SetInt("time_in_mine", PlayerPrefs.GetInt("time_in_mine") - 5);
                PlayerPrefs.SetString("Event", "time_in_mine_drop");
            }
        }
        else if(rand > 50 && rand < 60)
        {
            PlayerPrefs.SetInt("coal_price", PlayerPrefs.GetInt("coal_price") + 1);
            PlayerPrefs.SetString("Event", "coal_price_inc");


        }
        else
        {
            //Say everything stays the same
        }
        SceneManager.LoadScene(4);
    }
}
