using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene_Switcher : MonoBehaviour {

	// Use this for initialization
	public void Change_Scene () {
        if (SceneManager.GetSceneByName("Platform") == SceneManager.GetActiveScene())
        {
            SceneManager.LoadScene(1);

        }
        else
        {
            SceneManager.LoadScene(0);
        }

	}
}
