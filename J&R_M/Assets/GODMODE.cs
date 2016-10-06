using UnityEngine;
using System.Collections;

public class GODMODE : MonoBehaviour {
    public GameObject blackblock;
    public GameObject dirt;
    public GameObject brick;
    public GameObject ice;
    public GameObject sand;
    public GameObject inUse;
    public string status;

	// Use this for initialization
	void Start () {
        status = "nothing";
	}
	
	// Update is called once per frame
	void Update () {
            if (status.Equals("nothing"))
            {
                if (Input.GetKey(KeyCode.X))
                {
                    status = "selected";
                    useBlock("Blackblock");
                }
                if (Input.GetKey(KeyCode.Y))
                {
                    status = "nothing";
                }
                if (status.Equals("selected"))
                {
                    if (Input.GetKey(KeyCode.RightArrow)){
                        moveBlock(92, 0);
                    }
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        moveBlock(-92, 0);
                    }
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        moveBlock(0, 92);
                    }
                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        moveBlock(0, -92);
                    }
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
            case "Blackblock": Instantiate(blackblock);
                inUse = blackblock;
                break;
            case "dirt": Instantiate(dirt);
                break;
            default:
                break;
        }
    }

    void moveBlock(int x, int y)
    {
        inUse.transform.position = new Vector3(x, y, transform.position.z);

    }
}
