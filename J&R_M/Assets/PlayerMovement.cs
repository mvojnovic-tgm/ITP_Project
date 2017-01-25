using UnityEngine;
using System.Collections;

public class PlayerMovement: MonoBehaviour {

    public string skin;

    private float Speed = 8f;
    private float movex = 0f;
    private float movey = 0f;
    private Rigidbody2D rgbdy;
    private bool pause;
    private string mode;
    public Camera pc;
    private string skinNow;

    // Use this for initialization
    void Start() {
        Camera c = (Camera)Instantiate(pc, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), gameObject.transform.rotation);
        c.transform.parent = gameObject.transform;
        rgbdy = GetComponent<Rigidbody2D>();
        rgbdy.fixedAngle = true;
        pause = false;
        mode = "player";
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(skin, typeof(Sprite)) as Sprite;
        skinNow = skin;
    }



    //HOW TO SET THE SPRITE
    //void setSprite(string text)
    //{
        //gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("dirt", typeof(Sprite)) as Sprite;
    //}

    // Update is called once per frame
    void Update() {

        //PAUSE BUTTON


        if (Input.GetKey(KeyCode.Escape))
        {
            foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
            {
                if (o.name == "GOD")
                {
                    o.GetComponent<GODMODE>().enabled = true;
                    Destroy(gameObject);
                }
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
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                skinNow = skin + "left";
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(skinNow, typeof(Sprite)) as Sprite;
                movex = movex - 1;
                print("links");
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                skinNow = skin + "right";
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(skinNow, typeof(Sprite)) as Sprite;
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
