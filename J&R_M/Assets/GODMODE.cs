using UnityEngine;
using System.Collections;

public class GODMODE : MonoBehaviour {
    public GameObject blackblock;
    public GameObject dirt;
    public GameObject brick;
    public GameObject ice;
    public GameObject sand;
    private GameObject inUse;
    private GameObject character;
    private string status;

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
