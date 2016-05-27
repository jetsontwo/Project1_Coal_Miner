using UnityEngine;
using System.Collections;

public class Wall_Push : MonoBehaviour {

    public GameObject player;
    private Player_Movement pm;
    private Rigidbody rb;
    public Dir direction;


    public enum Dir
    {
        Left_Faces_In, Right_Faces_In
    }

    // Use this for initialization
    void Start () {
        rb = player.GetComponent<Rigidbody>();
        pm = player.GetComponent<Player_Movement>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionStay(Collision c)
    {
        if (!pm.isGrounded()){
            rb.velocity = new Vector3(0f, -4f, 0f);
        }
    }
}
