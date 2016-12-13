using UnityEngine;
using System.Collections;

public class move_it : MonoBehaviour {
    public GameObject god;
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
    
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x+0.92f, transform.position.y);
            
        }else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x-0.92f, transform.position.y);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.92f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y-0.92f);
        }else if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(god);
            GetComponent<move_it>().enabled = false;
        }else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Instantiate(god);
            Destroy(gameObject);
        }
    }
}
