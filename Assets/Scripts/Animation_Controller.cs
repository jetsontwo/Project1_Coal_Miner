using UnityEngine;
using System.Collections;

public class Animation_Controller : MonoBehaviour {
    public Animator animator;
    public Player_Movement pm;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (pm.jumping && pm.isGrounded()){;
            animator.Play("Jump_GROUND_blocking", -1, 0f);
        }
        else if (pm.jumping)
        {
            animator.Play("Jump_InAir_blocking", -1, 0f);
        }
        else if (pm.isGrounded())
        {
            animator.Play("Jump_Landing_blocking_", -1, 0f);
        }
	}
}
