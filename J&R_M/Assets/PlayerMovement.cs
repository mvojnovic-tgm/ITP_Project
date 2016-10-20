using UnityEngine;
using System.Collections;

public class PlayerMovement: MonoBehaviour {

    private float Speed = 8f;
    private float movex = 0f;
    private float movey = 0f;
    private Rigidbody2D rgbdy;
    private bool pause;
    private string mode;

    // Use this for initialization
    void Start() {
        rgbdy = GetComponent<Rigidbody2D>();
        rgbdy.fixedAngle = true;
        pause = false;
        mode = "player";
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("psd/Characters/character3", typeof(Sprite)) as Sprite;
    }



    //HOW TO SET THE SPRITE
    void setSprite(string text)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("dirt", typeof(Sprite)) as Sprite;
    }

    // Update is called once per frame
    void Update() {

        //PAUSE BUTTON


        if (Input.GetKey(KeyCode.Escape))
        {
            if (pause == true)
            {
                mode = "player";
                pause = false;
            }
            else
            {
                mode = "god";
                pause = true;
            }
        }
        if (pause == false)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }


        if (mode == "player")
        {
            //MOVEMENT LEFT RIGHT
            if (Input.GetKey(KeyCode.A))
            {
                movex = movex - 1;
                print("links");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                movex = movex + 1;
                print("rechts");
            }
            else
            {
                if (movex < 0)
                {
                    movex = movex + 1;
                }
                else
                {
                    movex = movex - 1;
                }
            }

            //MOVEMENT JUMP
            if (Input.GetKey(KeyCode.Space) && rgbdy.velocity.y == 0)
            {
                rgbdy.AddForce(new Vector2(0, 0.0006f), ForceMode2D.Impulse);
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

    }
    public string getMode()
    {
        return mode;
    }
}
