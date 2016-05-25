using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character_Status : MonoBehaviour {

    public int cold, hunger, sickness;
    public Button heal_button;

	// Use this for initialization
	void Start ()
    {
        heal_button.enabled = false;
        
	}
	
	// Update is called once per frame
	void Update () {
	    if (sickness > 50)
        {
            heal_button.enabled = true;
        }
        
	}

    public void feed()
    {
        print("feediong");
        print(gameObject);
    }
}
