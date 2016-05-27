using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour {

    public float spd, jump_height;
    public float turn_speed;
    public Camera c;
    private float move_Horiz, move_Vert, speed_mult;
    private Vector3 mod;
    private bool grounded, tracking;
    private Rigidbody rb;
    private Transform c_loc;
    public int coal_count;
    private Vector3 mouse_past, mouse_current;
    public bool jumping, walking;
    public Text coal_counter;
    public Animator anim;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        grounded = false;
        c_loc = c.transform;
        coal_count = 0;
        mouse_past = Input.mousePosition;
        mouse_current = Input.mousePosition;
        Cursor.lockState = CursorLockMode.Locked;
        tracking = true;
	}
	
	// Update is called once per frame
	void Update () {
        mouse_current = Input.mousePosition;
        move_Horiz = Input.GetAxis("Horizontal");
        move_Vert = Input.GetAxis("Vertical");
        anim.SetFloat("walk_forward", move_Vert);
        if (rb.velocity.magnitude < 30)
        {
            rb.AddForce(transform.forward * move_Vert * spd);
            rb.AddForce(transform.right * move_Horiz * spd);
        }

        if (rb.velocity.magnitude > 0 && grounded)
        {
            walking = true;
        }
        else
        {
            walking = false;
        }


        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector3(0f, jump_height, 0f));
            jumping = true;
        }
        else if (grounded)
        {
            jumping = false;
        }

        if (tracking)
        {
            if (Input.GetAxis("Mouse X") > 0)
                transform.Rotate(Vector3.up * turn_speed);
            if (Input.GetAxis("Mouse X") < 0)
                transform.Rotate(Vector3.up * -turn_speed);
        }
        

        if (Input.GetKeyUp(KeyCode.P))
        {
            if (Cursor.lockState.Equals(CursorLockMode.Locked))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                tracking = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                tracking = true;
            }
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

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Coal")
        {
            c.gameObject.SetActive(false);
            //Play pickup sound
            coal_count += 5;
            coal_counter.text =  "Money: $" + coal_count;
        }

    }
}
