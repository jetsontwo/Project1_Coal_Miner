using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store_Script : MonoBehaviour {

    public int money;
    public Text money_button;
    public Character_Status k, w;

    void Start() 
    {
        money = PlayerPrefs.GetInt("money");
    } 

    void Update()
    {
        money_button.text = "Money: $ " + money;
        PlayerPrefs.SetInt("money", money);
    }
    
    public void Buy_Food(Character_Status g)
    {
        if (money >= 10 && g.hunger >= 30)
        {
            g.hunger -= 30;
            money -= 10;
        }
        else if (money >= 10 && g.hunger > 0)
        {
            g.hunger = 0;
            money -= 10;
        }
    }

    public void Buy_Heat()
    {
        if(money >= 30 && w.cold >0 && k.cold > 0)
        {
            k.cold = 0;
            w.cold = 0;
            money -= 30;
        }
    }

    public void Buy_Medicine(Character_Status g)
    {
        if (money >= 30 && g.sickness >= 25)
        {
            g.sickness -= 25;
            money -= 30;
        }
        else if (money >= 30 && g.sickness > 0)
        {
            g.sickness = 0;
            money -= 30;
        }
    }


    public void update_family(GameObject g)
    {
        PlayerPrefs.SetInt("cold_" + g.name, g.GetComponent<Character_Status>().cold);
        PlayerPrefs.SetInt("hunger_" + g.name, g.GetComponent<Character_Status>().hunger);
        PlayerPrefs.SetInt("sickness_" + g.name, g.GetComponent<Character_Status>().sickness);
    }
}
