using UnityEngine;
using System.Collections;

public class Death_Plane : MonoBehaviour {

    public Scene_Switcher s;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            s.Change_Scene();
            
        }
    }
}
