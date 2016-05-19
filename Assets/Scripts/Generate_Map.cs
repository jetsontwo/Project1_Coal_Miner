using UnityEngine;
using System.Collections;

public class Generate_Map : MonoBehaviour {

    public int width, length;

	// Use this for initialization
	void Start () {
        bool[,] platform_loc = new bool[length, width];
        for (int i = 0; i < length; i++)
        {
            int choice = Random.Range(0,2);
            platform_loc[i, choice] = true;

            if (i > 0)
            {
                int ychoice = platform_loc[i-1, choice]
            }
        }

        for (int i = 0; i< length; i++)
        {
            if (i > 0)
            {
                int ychoice = platform_loc[i-1]
            }
        }
        print(platform_loc.ToString());
	}
}
