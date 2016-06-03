using UnityEngine;
using System.Collections;

public class Light_Flicker : MonoBehaviour {

    private Light l;
	// Use this for initialization
	void Start () {
        l = GetComponent<Light>();
        StartCoroutine(Flicker());
	}
	
	// Update is called once per frame
	IEnumerator Flicker() {
        float minFlickerIntensity = 1.7f;
        float maxFlickerIntensity = 2.25f;
        float flickerSpeed = 0.035f;


         int  randomizer = 0;
  
          while (true)
          {
             if (randomizer == 0) {
               l.intensity = (Random.Range (minFlickerIntensity, maxFlickerIntensity));
 
             }
             else l.intensity = (Random.Range (minFlickerIntensity, maxFlickerIntensity));
 
             randomizer = Random.Range(0, 1);
             yield return new WaitForSeconds(flickerSpeed);
         }
    }
}
