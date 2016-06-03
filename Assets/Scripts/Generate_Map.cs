using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Generate_Map : MonoBehaviour {

    public int width, length;
    public int height_between_low, height_between_high, dist_between_z, dist_between_x;
    public GameObject platform_object, coal_object, lantern_object;
    public Scene_Switcher scene_switcher;
    public Player_Movement pm;
    private float start_time;
    private int hardness_modifier;
    public Text timer; 

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("Has_Played"))
        {
            PlayerPrefs.SetString("Has_Played", "asdf");
            PlayerPrefs.SetInt("money", 0);
            PlayerPrefs.SetInt("coal_price", 5);
            PlayerPrefs.SetInt("coal_freq", 3);
            PlayerPrefs.SetInt("Night_Count", 0);
            PlayerPrefs.SetInt("time_in_mine", 60);
        }

        hardness_modifier = PlayerPrefs.GetInt("coal_freq");
        start_time = Time.time;

        plat_data[] platform_loc = new plat_data[length];
        for (int i = 0; i < length; i++)
        {
            int choice = Random.Range(0,3);
            int coal_choice = Random.Range(0, hardness_modifier);

            platform_loc[i] = new plat_data(true, choice, Random.Range(-3, 5));

            int ychoice = platform_loc[i].height;

            if (i > 0)
            {
                ychoice = platform_loc[i-1].height + Random.Range(height_between_low, height_between_high);
            }

            GameObject temp_obj = (GameObject) Instantiate(platform_object, new Vector3(choice * dist_between_x + Random.Range(-5,5), ychoice, i * dist_between_z + Random.Range(-5,5)), Quaternion.LookRotation(Vector3.up, Vector3.forward));
            temp_obj.transform.parent = platform_object.transform.parent;

            if (coal_choice == 1)
            {
                GameObject coal_obj = (GameObject) Instantiate(coal_object, new Vector3(temp_obj.transform.position.x, temp_obj.transform.position.y + 4, temp_obj.transform.position.z), Quaternion.identity);
                coal_obj.transform.parent = coal_object.transform.parent;
            }
            else if (coal_choice == 2)
            {
                GameObject lantern_obj = (GameObject)Instantiate(lantern_object, new Vector3(temp_obj.transform.position.x, temp_obj.transform.position.y + 5, temp_obj.transform.position.z), Quaternion.LookRotation(Vector3.up, Vector3.forward));
                lantern_obj.transform.parent = lantern_object.transform.parent;
            }
        }

	}

    void Update()
    {
        timer.text = "End of Shift: " + (int) (PlayerPrefs.GetInt("time_in_mine") - (Time.time - start_time));
        if (Time.time - start_time >= PlayerPrefs.GetInt("time_in_mine"))
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
