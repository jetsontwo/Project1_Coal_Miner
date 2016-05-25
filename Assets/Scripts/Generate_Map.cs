using UnityEngine;
using System.Collections;

public class Generate_Map : MonoBehaviour {

    public int width, length;
    public int height_between_low, height_between_high, dist_between_z, dist_between_x;
    private GameObject platform_object;
    public Scene_Switcher scene_switcher;
    public Player_Movement pm;

	// Use this for initialization
	void Start () {
        platform_object = GameObject.FindWithTag("Ground");
        plat_data[] platform_loc = new plat_data[length];
        for (int i = 0; i < length; i++)
        {
            int choice = Random.Range(0,3);
            print(choice);
            platform_loc[i] = new plat_data(true, choice, Random.Range(-3, 5));

            int ychoice = platform_loc[i].height;

            if (i > 0)
            {
                ychoice = platform_loc[i-1].height + Random.Range(height_between_low, height_between_high);
            }

            GameObject temp_obj = (GameObject) Instantiate(platform_object, new Vector3(choice * dist_between_x + Random.Range(-5,5), ychoice, i * dist_between_z + Random.Range(-5,5)), Quaternion.identity);
            temp_obj.transform.parent = platform_object.transform.parent;
        }

	}

    void Update()
    {
        if (Time.time >= 30)
        {
            scene_switcher.Change_Scene();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }



    public class plat_data
    {
        public bool is_plat;
        public int height;
        public int col_val;

        public plat_data(bool is_plat, int col_val, int height)
        {
            this.is_plat = is_plat;
            this.height = height;
            this.col_val = col_val;
        }
    }
}
