using UnityEngine;
using System.Collections;

public class Mouse_Over : MonoBehaviour {
	
    void OnMouseOver()
    {
        if (gameObject.name == "Kid")
        {
            print("Hey its the kid");
        }
        else if (gameObject.name == "Wife")
        {
            print("Hey its the wife");
        }
    }
}
