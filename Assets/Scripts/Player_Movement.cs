using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

    public float spd, jump_height;
    private float move_Horiz, move_Vert, speed_mult;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0f, jump_height, 0f));
        }
        transform.rotation.Set(0f, 0f, 0f, 0f);
    }
}
