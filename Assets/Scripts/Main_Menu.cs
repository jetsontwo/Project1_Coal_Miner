using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {

	public void Start_Game()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }

    public void End_Game()
    {
        Application.Quit();
    }
}
