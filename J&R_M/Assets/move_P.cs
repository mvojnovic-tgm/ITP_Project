using UnityEngine;
using System.Collections;

public class move_P : MonoBehaviour
{
    public GameObject god;


    // Use this for initialization
    void Start()
    {
        print("f1-f5 chages the character");
        //gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("psd/Characters/character3", typeof(Sprite)) as Sprite;
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("psd/Characters/character1", typeof(Sprite)) as Sprite;
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("psd/Characters/character2", typeof(Sprite)) as Sprite;
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("psd/Characters/character3", typeof(Sprite)) as Sprite;
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("psd/Characters/character4", typeof(Sprite)) as Sprite;
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("psd/Characters/character5", typeof(Sprite)) as Sprite;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + 0.92f, transform.position.y);

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - 0.92f, transform.position.y);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.92f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.92f);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(god);
            GetComponent<move_P>().enabled = false;
        }
        else if (Input.GetKey(KeyCode.P))
        {
            GetComponent<move_P>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<PlayerMovement>().enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Instantiate(god);
            Destroy(gameObject);
        }
    }
}
