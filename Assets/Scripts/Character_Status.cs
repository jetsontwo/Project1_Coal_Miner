using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character_Status : MonoBehaviour {

    public int cold, hunger, sickness;
    public Button heal_button;
<<<<<<< HEAD
    public Store_Script s;
=======
>>>>>>> origin/master

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
<<<<<<< HEAD
        s.Buy_Food(this);
=======
        print("feediong");
        print(gameObject);
>>>>>>> origin/master
    }
}
