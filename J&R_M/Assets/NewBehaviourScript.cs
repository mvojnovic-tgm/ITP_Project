using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public float Speed = 1f;
    private float movex = 0f;
    private Rigidbody2D rgbdy;

    // Use this for initialization
    void Start () {
        rgbdy = GetComponent<Rigidbody2D>();
        //rgbdy.fixedAngle = true;
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(KeyCode.A))
        {
            movex = -1;
            print("links");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movex = 1;
            print("rechts");
        }
        else
        {
            movex = 0;
        }
        if (rgbdy.GetComponent<Rigidbody2D>().velocity.y==0)
        {

        }
        movex = Input.GetAxis("Horizontal");
        rgbdy.velocity = new Vector2(Speed*movex, GetComponent<Rigidbody2D>().velocity.y);
    }
}
