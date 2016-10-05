using UnityEngine;
using System.Collections;

public class PlayerTesting : MonoBehaviour {

    public float Speed = 1f;
    private float movex = 0f;
    private float movey = 0f;
    private Rigidbody2D rgbdy;
    private SpriteRenderer sr;

    // Use this for initialization
    void Start() {
        rgbdy = GetComponent<Rigidbody2D>();
        rgbdy.fixedAngle = true;
        //sr = GetComponent<SpriteRenderer>();
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("dirt", typeof(Sprite)) as Sprite;
        //gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("random_thing", typeof(Sprite));
    }

    void setSprite(string text)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("random_thing.psd", typeof(Sprite)) as Sprite;
    }

    // Update is called once per frame
    void Update() {


        //setSprite("");
        //MOVEMENT LEFT RIGHT
        if (Input.GetKey(KeyCode.A))
        {
            movex = movex-1;
            print("links");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movex = movex+1;
            print("rechts");
        }
        else
        {
            if (movex < 0)
            {
                movex = movex + 1;
            }else
            {
                movex = movex - 1;
            }
        }

        //MOVEMENT JUMP
        if (Input.GetKey(KeyCode.Space) && rgbdy.velocity.y == 0)
        {
            rgbdy.AddForce(new Vector2(0, 0.00055f), ForceMode2D.Impulse);
        }
        movex = Input.GetAxis("Horizontal");
        rgbdy.velocity = new Vector2(Speed * movex, rgbdy.velocity.y);

        //REALISTIC FALL
        if (rgbdy.velocity.y < 0)
        {
           rgbdy.velocity = new Vector2(Speed * movex, rgbdy.velocity.y * 1.05f);
        }
        print(rgbdy.velocity.y + "  " + rgbdy.velocity.x);



    }
    public Rigidbody2D getRgbdy()
    {
        return rgbdy;
    }
}
