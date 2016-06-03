using UnityEngine;
using System.Collections;

public class Animation_Controller : MonoBehaviour {
    public Animator animator;
    private string cur_anim;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        cur_anim = "idle";
	}

    // Update is called once per frame
    void Update() {

        if (animator.GetBool("jumped") == true && animator.GetBool("landed"))
        {
            animator.Play("Jump_GROUND_blocking");
            cur_anim = "jump";

        }
        else if (animator.GetFloat("walking") != 0 && animator.GetBool("landed") == true)

        {
            animator.Play("Walk_blocking_clean");
            cur_anim = "walk";
        }
        
        



    }
}
