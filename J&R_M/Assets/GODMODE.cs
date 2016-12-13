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
    private string status;
    private move_P mp;

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
                    print("f1 = blackblock ; f2 = dirt ; f3 = sand ; f4 = brick ; f5 = ice ; f6 = character");
                }
               
            }else if(status.Equals("select")){
                if (Input.GetKey(KeyCode.F1))
                {
                    useBlock("blackblock");
                    print("to move sue arrow keys, to place use z");   
                }
                else if (Input.GetKey(KeyCode.F2))
                {
                    useBlock("dirt");
                    print("to move sue arrow keys, to place use z");
                }
                else if(Input.GetKey(KeyCode.F3))
                {
                    useBlock("sand");
                    print("to move sue arrow keys, to place use z");
                }
                else if (Input.GetKey(KeyCode.F4))
                {
                    useBlock("brick");
                    print("to move sue arrow keys, to place use z");
                }
                else if (Input.GetKey(KeyCode.F5))
                {
                    useBlock("ice");
                    print("to move sue arrow keys, to place use z");
                }
                else if (Input.GetKey(KeyCode.F6))
                {
                    useBlock("grass");
                    print("to move sue arrow keys, to place use z");
                }
                else if (Input.GetKey(KeyCode.F7))
                {
                    useBlock("water");
                    print("to move sue arrow keys, to place use z");
                }
                else if (Input.GetKey(KeyCode.F8))
                {
                    useBlock("lava");
                    print("to move sue arrow keys, to place use z");
                }
            else if (Input.GetKey(KeyCode.S))
                {
                    useBlock("character");
                    print("to move sue arrow keys, to place use z");
                }

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
                Instantiate(blackblock);
                Destroy(gameObject);
                break;
            case "dirt":
                Instantiate(dirt);
                Destroy(gameObject);
                break;
            case "sand":
                Instantiate(sand);
                Destroy(gameObject);
                break;
            case "brick":
                Instantiate(brick);
                Destroy(gameObject);
                break;
            case "ice":
                Instantiate(ice);
                Destroy(gameObject);
                break;
            case "grass":
                Instantiate(grass);
                Destroy(gameObject);
                break;
            case "water":
                Instantiate(water);
                Destroy(gameObject);
                break;
            case "lava":
                Instantiate(lava);
                Destroy(gameObject);
                break;
            case "character":
                Instantiate(character);
                Destroy(gameObject);
                break;

        }
    }
}
