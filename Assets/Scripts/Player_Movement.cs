using UnityEngine;
using System.Collections;

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
        move_Horiz = -Input.GetAxis("Horizontal");
        move_Vert = Input.GetAxis("Vertical");
        if (rb.velocity.magnitude < 10 && grounded)
        {
            rb.AddForce(transform.up * move_Vert * spd);
            rb.AddForce(transform.right * move_Horiz * spd);
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector3(0f, jump_height, 0f));
        }

        if (tracking)
        {
            if (Input.GetAxis("Mouse X") > 0)
                transform.Rotate(Vector3.forward * turn_speed);
            if (Input.GetAxis("Mouse X") < 0)
                transform.Rotate(Vector3.forward * -turn_speed);
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
            coal_count += 1;
            print(coal_count);
        }

    }
}
