using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

    public float spd, jump_height;
    public Camera c;
    private float move_Horiz, move_Vert, speed_mult;
    private bool grounded;
    private Rigidbody rb;
    private Transform c_loc;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        grounded = false;
        c_loc = c.transform;
	}
	
	// Update is called once per frame
	void Update () {
        move_Horiz = -Input.GetAxis("Horizontal");
        move_Vert = -Input.GetAxis("Vertical");
        print(move_Horiz);
        print(move_Horiz * Time.deltaTime);
        if (rb.velocity.magnitude < 10)
        {
            rb.AddForce(new Vector3(move_Horiz * spd, 0, move_Vert * spd));
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector3(0f, jump_height, 0f));
        }
    }

    public bool isGrounded()
    {
        return grounded;
    }

    void OnCollisionStay(Collision c)
    {
        if (c.gameObject.tag == "Ground"){
            grounded = true;
        }
    }
    void OnCollisionExit(Collision c)
    {
        grounded = false;
    }
}
