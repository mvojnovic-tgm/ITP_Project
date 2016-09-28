using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public float Speed = 1f;
    private float movex = 0f;
    private float movey = 0f;
    private Rigidbody2D rgbdy;

    // Use this for initialization
    void Start() {
        rgbdy = GetComponent<Rigidbody2D>();
        rgbdy.fixedAngle = true;
    }

    // Update is called once per frame
    void Update() {

        //MOVEMENT LEFT RIGHT
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

        //MOVEMENT JUMP
        if (Input.GetKey(KeyCode.Space) && rgbdy.velocity.y == 0)
        {
            movey = 6 ;
            rgbdy.velocity = new Vector2(Speed * movex, movey);
        }else if(rgbdy.velocity.y > 0)
        {
            movey = movey-0.25f;
            rgbdy.velocity = new Vector2(Speed * movex, movey);
        }
        if (rgbdy.GetComponent<Rigidbody2D>().velocity.y == 0)
        {

        }

        movex = Input.GetAxis("Horizontal");
        rgbdy.velocity = new Vector2(Speed * movex, rgbdy.velocity.y);

        //REALISTIC FALL
        if (rgbdy.velocity.y < 0)
        {
           rgbdy.velocity = new Vector2(Speed * movex, rgbdy.velocity.y * 1.05f);
        }

    }
    public Rigidbody2D getRgbdy()
    {
        return rgbdy;
    }
}
