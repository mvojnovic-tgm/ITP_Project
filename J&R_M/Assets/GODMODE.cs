using UnityEngine;
using System.Collections;

public class GODMODE : MonoBehaviour {
    public GameObject blackblock;
    public GameObject dirt;
    public GameObject brick;
    public GameObject ice;
    public GameObject sand;
    public GameObject grass;
    public GameObject water;
    public GameObject lava;
    public GameObject character;
    public GameObject phFab;
    private GameObject ph;
    private GameObject b;
    private string status;
    private move_P mp;
    private GameObject[] terrain;
    private string skin;

	// Use this for initialization
	void Start () {
        status = "nothing";
        print("to use blocks press x");
        
	}
	
	// Update is called once per frame
	void Update () {
        

        if (status.Equals("nothing"))
        {
            if (Input.GetKey(KeyCode.X))
            {
                status = "select";
                print("f1 = blackblock ; f2 = dirt ; f3 = sand ; f4 = brick ; f5 = ice ; f6 = grass ; f7 = water ; f8 = lava ; s = character ; p = start Game ; l = load Game");
            }
               
        }else if(status.Equals("select")){
            //checkMovement();

            if (Input.GetKey(KeyCode.F1))
            {
                useBlock("blackblock");
                print("to move sue arrow keys, to place use z");
                status = "brick selected";
            }
            else if (Input.GetKey(KeyCode.F2))
            {
                useBlock("dirt");
                print("to move sue arrow keys, to place use z");
                status = "brick selected";
            }
            else if(Input.GetKey(KeyCode.F3))
            {
                useBlock("sand");
                print("to move sue arrow keys, to place use z");
                status = "brick selected";
            }
            else if (Input.GetKey(KeyCode.F4))
            {
                useBlock("brick");
                print("to move sue arrow keys, to place use z");
                status = "brick selected";
                print("fick mein leben bitte");
            }
            else if (Input.GetKey(KeyCode.F5))
            {
                useBlock("ice");
                print("to move sue arrow keys, to place use z");
                status = "brick selected";
            }
            else if (Input.GetKey(KeyCode.F6))
            {
                useBlock("grass");
                print("to move sue arrow keys, to place use z");
                status = "brick selected";
            }
            else if (Input.GetKey(KeyCode.F7))
            {
                useBlock("water");
                print("to move sue arrow keys, to place use z");
                status = "brick selected";
            }
            else if (Input.GetKey(KeyCode.F8))
            {
                useBlock("lava");
                print("to move sue arrow keys, to place use z");
                status = "brick selected";
            }
            else if (Input.GetKey(KeyCode.S))
            {
                useBlock("character");
                print("to move sue arrow keys, to place use z");
                status = "ph selected";
            }
            else if (Input.GetKey(KeyCode.P))
            {
                float posX = ph.transform.position.x;
                float posY = ph.transform.position.y;
                float posZ = ph.transform.position.z;

                Quaternion idk = ph.transform.rotation;

                //character.skin = skin;
                GameObject g = Instantiate(character, new Vector3(posX, posY, posZ), idk) as GameObject;

                PlayerMovement comp = g.GetComponent<PlayerMovement>();
                comp.skin = skin;
                Destroy(ph);
                
                Destroy(gameObject);
            }
            else if(Input.GetKey(KeyCode.L))
            {
                print("f1 = Gamestate 1 ; f2 = Gamestate 2 ; f3 = Gamestate 3");
                status = "loading";
            }
            

        }
        else if (status.Equals("brick selected"))
        {
            print("wieso nicht");
            checkMovement();
        }
        else if(status.Equals("ph selected"))
        {
            checkPhMovement();
        }
        else if (status.Equals("loading"))
        {
            loadGameState(1);
        }
	}
    
    void setCharacterSprite(string character)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(character, typeof(Sprite)) as Sprite;
    }

    void useBlock(string bName)
    {
        switch (bName)
        {
            case "blackblock":
                b = Instantiate(blackblock) as GameObject;
                //Destroy(gameObject);
                break;
            case "dirt":
                b = Instantiate(dirt) as GameObject;
                //Destroy(gameObject);
                break;
            case "sand":
                b = Instantiate(sand) as GameObject;
                //Destroy(gameObject);
                break;
            case "brick":
                b = Instantiate(brick) as GameObject;
                //Destroy(gameObject);
                break;
            case "ice":
                b = Instantiate(ice) as GameObject;
                //Destroy(gameObject);
                break;
            case "grass":
                b = Instantiate(grass) as GameObject;
                //Destroy(gameObject);
                break;
            case "water":
                b = Instantiate(water) as GameObject;
                //Destroy(gameObject);
                break;
            case "lava":
                b = Instantiate(lava) as GameObject;
                //Destroy(gameObject);
                break;
            case "character":
                if (ph != null)
                    Destroy(ph);
                ph = Instantiate(phFab) as GameObject;
                //Destroy(gameObject);
                break;

        }
    }

    public void checkMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            b.transform.position = new Vector2(b.transform.position.x, b.transform.position.y + 0.92f);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            b.transform.position = new Vector2(b.transform.position.x, b.transform.position.y - 0.92f);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            b.transform.position = new Vector2(b.transform.position.x - 0.92f, b.transform.position.y);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            b.transform.position = new Vector2(b.transform.position.x + 0.92f, b.transform.position.y);
        else if (Input.GetKey(KeyCode.Z))
        {
            //b = null;
            status = "nothing";
        }

        //print("x: " + b.transform.position.x+"       y: "+b.transform.position.y);
    }

    public void checkPhMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ph.transform.position = new Vector2(ph.transform.position.x, ph.transform.position.y + 0.92f);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            ph.transform.position = new Vector2(ph.transform.position.x, ph.transform.position.y - 0.92f);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            ph.transform.position = new Vector2(ph.transform.position.x - 0.92f, ph.transform.position.y);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            ph.transform.position = new Vector2(ph.transform.position.x + 0.92f, ph.transform.position.y);
        else if (Input.GetKey(KeyCode.Z))
        {
            //b = null;
            status = "nothing";
        }


        if (Input.GetKeyDown(KeyCode.F1))
        {
            skin = "psd/Characters/char1";
            ph.GetComponent<SpriteRenderer>().sprite = Resources.Load("psd/Characters/char1", typeof(Sprite)) as Sprite;
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            skin = "psd/Characters/char2";
            ph.GetComponent<SpriteRenderer>().sprite = Resources.Load("psd/Characters/char2", typeof(Sprite)) as Sprite;
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            skin = "psd/Characters/char3";
            ph.GetComponent<SpriteRenderer>().sprite = Resources.Load("psd/Characters/char3", typeof(Sprite)) as Sprite;
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            skin = "psd/Characters/char4";
            ph.GetComponent<SpriteRenderer>().sprite = Resources.Load("psd/Characters/char4", typeof(Sprite)) as Sprite;
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            skin = "psd/Characters/char5";
            ph.GetComponent<SpriteRenderer>().sprite = Resources.Load("psd/Characters/char5", typeof(Sprite)) as Sprite;
        }
    }

    public void loadGameState(int i)
    {
       
    }
}
