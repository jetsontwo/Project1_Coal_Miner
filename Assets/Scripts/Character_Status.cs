using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character_Status : MonoBehaviour {

    public int cold, hunger, sickness;
    public Text cold_text, hunger_text;
    public Material hunger_skin, cold_skin, cold_hungry_skin, default_skin;
    public Store_Script s;


	// Use this for initialization
	void Start ()
    {
        if (!PlayerPrefs.HasKey("cold_Kid"))
        {
            PlayerPrefs.SetInt("cold_" + gameObject.name, cold);
            PlayerPrefs.SetInt("hunger_" + gameObject.name, hunger);
            PlayerPrefs.SetInt("sickness_" + gameObject.name, sickness);
        }
        else
        {
            cold = PlayerPrefs.GetInt("cold_" + gameObject.name);
            hunger = PlayerPrefs.GetInt("hunger_" + gameObject.name);
            sickness = PlayerPrefs.GetInt("sickness_" + gameObject.name);
        }
        
        
	}
	
	// Update is called once per frame
	void Update () {
        cold_text.text = "Cold: " + cold;
        hunger_text.text = "Hunger: " + hunger;
        if (cold > 50 && hunger > 50)
        {
            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = cold_hungry_skin;
        }
        else if(hunger > 50)
        {
            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = hunger_skin;
        }
        else if (cold > 50)
        {
            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = cold_skin;
        }
        else
        {
            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = default_skin;
        }
	}

    public void feed()
    {
        s.Buy_Food(this);

    }
}
