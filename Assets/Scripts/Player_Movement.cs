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
    public bool jumping, walking;
    public Text coal_counter, day_counter;
    public Animator anim;
    private AudioSource AS;
    private int coal_price;


	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("Has_Played"))
        {
            coal_count = PlayerPrefs.GetInt("money");
            coal_price = PlayerPrefs.GetInt("coal_price");
        }
        else
        {
            coal_count = 0;
            PlayerPrefs.SetInt("money", 0);
            PlayerPrefs.SetInt("coal_price", 5);
        }
        day_counter.text = "Day: " + PlayerPrefs.GetInt("Night_Count");
        rb = GetComponent<Rigidbody>();
        grounded = false;
        c_loc = c.transform;

        Cursor.lockState = CursorLockMode.Locked;
        tracking = true;
        AS = GetComponent<AudioSource>();
        coal_counter.text = "Money: $" + coal_count;
	}
	
	// Update is called once per frame
	void Update () {
        move_Horiz = Input.GetAxis("Horizontal");
        move_Vert = Input.GetAxis("Vertical");
        anim.SetFloat("walking", move_Vert);
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
            anim.SetBool("jumped", true);
        }
        else if (grounded)
        {
            anim.SetBool("jumped", false);
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
        PlayerPrefs.SetInt("money", coal_count);


    }

    public bool isGrounded()
    {
        return grounded;
    }

    void OnCollisionStay(Collision c)
    {
        if (c.gameObject.tag == "Ground"){
            grounded = true;
            anim.SetBool("landed", true);
        }
    }
    void OnCollisionExit(Collision c)
    {
        grounded = false;
        anim.SetBool("landed", false);
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Coal")
        {
            c.gameObject.SetActive(false);
            AS.Play();
            coal_count += coal_price;
            coal_counter.text =  "Money: $" + coal_count;

        }

    }
}
