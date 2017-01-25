using UnityEngine;
using System.Collections;

using System.IO;
using System.Collections.Generic;
using System.Globalization;

public class GODMODE : MonoBehaviour {
    //GUI
    public Texture2D start;
    public Texture2D newWorld;
    public Texture2D loadWorld;
    public Texture2D saveWorld;
    public Texture2D options;
    public Texture2D close;

    //PREFABS
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
    private List<savingBlock> terrain;
    private string skin;
    private bool utd;

    //BUTTONS
    private bool startB;
    private bool newWorldB;
    private bool loadWorldB;
    private bool saveWorldB;
    private bool optionsB;
    private bool closeB;

    private string[] infoBox;
    private string aS, bS, cS;
    private GUIStyle gs;


	// Use this for initialization
	void Start () {
        aS = "";
        bS = "";
        cS = "";
        utd = true;
        status = "nothing";
        infoBox = new string[3];
        infoBox[0] = "";
        infoBox[1] = "";
        infoBox[2] = "";
        //print("to use blocks press x");
        
        terrain = new List<savingBlock>();

        //button = new List<bool>();
        gs = new GUIStyle();
        gs.fontSize = 28;
    }

    void OnGUI()
    {
        startB =  GUI.Button(new Rect(0, 0, start.width/2, start.height/2), start);
        newWorldB = GUI.Button(new Rect(0, 64, newWorld.width / 2, newWorld.height / 2), newWorld);
        loadWorldB = GUI.Button(new Rect(0, 128, loadWorld.width / 2, loadWorld.height / 2), loadWorld);
        saveWorldB = GUI.Button(new Rect(0, 192, saveWorld.width / 4, saveWorld.height / 4), saveWorld);
        optionsB = GUI.Button(new Rect(0, 256, options.width / 2, options.height / 2), options);
        closeB = GUI.Button(new Rect(0, 320, close.width / 2, close.height / 2), close);
        if (utd == true)
        {
            aS = infoBox[0];
            bS = infoBox[1];
            cS = infoBox[2];
            utd = false;
        }
        GUI.Label(new Rect(190, 0, 1000, 50), aS);
        GUI.Label(new Rect(190, 50, 1000, 50), bS);
        GUI.Label(new Rect(190, 100, 1000, 50), cS);
        GUI.Label(new Rect(500, 0, 1000, 200), "WELCOME TO THE JUMP AND RUN MAKER!!!11eleven!!", gs);
        //GUI.Label(new Rect(10, 40, 100, 100), pt);
    }



    // Update is called once per frame
    void Update () {
        //print(button[0]);
        if(startB == true)
        {
            if(ph != null)
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

                GetComponent<GODMODE>().enabled = false;
            }
        }
        if(newWorldB == true)
        {
            terrain.Clear();
            destroyAll();

            setInfoBox("DESTROYNG ALL");
            utd = true;


        }
        if(loadWorldB == true)
        {

            setInfoBox("loading...");
            utd = true;
            loadGameState(1);
            setInfoBox("done.");
            utd = true;


        }
        if(saveWorldB == true)
        {
            saveGameState(1);
        }
        if(closeB == true)
        {
            Application.Quit();
        }

        if (status.Equals("nothing"))
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                status = "select";
                //print("f1 = blackblock ; f2 = dirt ; f3 = sand ; f4 = brick ; f5 = ice ; f6 = grass ; f7 = water ; f8 = lava ; s = character ; p = start Game ; l = load Game");
                setInfoBox("f1 = blackblock ; f2 = dirt ; f3 = sand ; f4 = brick ; f5 = ice ; f6 = grass ; f7 = water ; f8 = lava ; s = character");
                utd = true;
            }
               
        }else if(status.Equals("select")){
            //checkMovement();

            if (Input.GetKeyDown(KeyCode.F1))
            {
                useBlock("blackblock");
                //print("to move sue arrow keys, to place use z");
                //setInfoBox("to move sue arrow keys, to place use z");
                status = "brick selected";
                setInfoBox("to move sue arrow keys, to place use z");
                utd = true;
            }
            else if (Input.GetKeyDown(KeyCode.F2))
            {
                useBlock("dirt");
                //print("to move sue arrow keys, to place use z");
                status = "brick selected";
                setInfoBox("to move sue arrow keys, to place use z");
                utd = true;
            }
            else if (Input.GetKeyDown(KeyCode.F3))
            {
                useBlock("sand");
                //print("to move sue arrow keys, to place use z");
                status = "brick selected";
                setInfoBox("to move sue arrow keys, to place use z");
                utd = true;
            }
            else if (Input.GetKeyDown(KeyCode.F4))
            {
                useBlock("brick");
                //print("to move sue arrow keys, to place use z");
                status = "brick selected";
                //print("fick mein leben bitte");
                setInfoBox("to move sue arrow keys, to place use z");
                utd = true;
            }
            else if (Input.GetKeyDown(KeyCode.F5))
            {
                useBlock("ice");
                //print("to move sue arrow keys, to place use z");
                status = "brick selected";
                setInfoBox("to move sue arrow keys, to place use z");
                utd = true;
            }
            else if (Input.GetKeyDown(KeyCode.F6))
            {
                useBlock("grass");
                //print("to move sue arrow keys, to place use z");
                status = "brick selected";
                setInfoBox("to move sue arrow keys, to place use z");
                utd = true;
            }
            else if (Input.GetKeyDown(KeyCode.F7))
            {
                useBlock("water");
                //print("to move sue arrow keys, to place use z");
                status = "brick selected";
                setInfoBox("to move sue arrow keys, to place use z");
                utd = true;
            }
            else if (Input.GetKeyDown(KeyCode.F8))
            {
                useBlock("lava");
               // print("to move sue arrow keys, to place use z");
                status = "brick selected";
                setInfoBox("to move sue arrow keys, to place use z");
                utd = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                useBlock("character");
                //print("to move sue arrow keys, to place use z");
                status = "ph selected";
                setInfoBox("to move sue arrow keys, to place use z; skin changes from f1 to f5");
                utd = true; 
            }
            //else if (Input.GetKey(KeyCode.P))
            //{

            //}
            //else if (Input.GetKey(KeyCode.L))
            //{
            //    print("f1 = Gamestate 1 ; f2 = Gamestate 2 ; f3 = Gamestate 3");
            //    status = "loading";
            //    loadGameState(1);
            //    //status = "nothing";
            //}
            //else if (Input.GetKeyDown(KeyCode.M))
            //{
            //    print("bout to save");
            //    saveGameState(1);
            //}
            


        }
        else if (status.Equals("brick selected"))
        {
            checkMovement();
        }
        else if(status.Equals("ph selected"))
        {
            checkPhMovement();
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
            setInfoBox("to use blocks press x");
            utd = true;
            savingBlock sb = new savingBlock();
            sb.go = b.name;
            sb.x = b.transform.position.x;
            sb.y = b.transform.position.y;
            terrain.Add(sb);
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
            setInfoBox("to use blocks press x");
            utd = true;
            savingBlock sb = new savingBlock();
            sb.go = "ph";
            sb.x = ph.transform.position.x;
            sb.y = ph.transform.position.y;
            terrain.Add(sb);
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

    public void saveGameState(int i)
    {
        int counter = terrain.Count;
        string[] help = new string[counter * 3];
        int helpCounter = 0;
        for(int i0 = 0; i0 < counter; i0++)
        {
            help[helpCounter] = terrain[i0].go;
            helpCounter++;
            help[helpCounter] = terrain[i0].x.ToString();
            helpCounter++;
            help[helpCounter] = terrain[i0].y.ToString();
            helpCounter++;
        }
        //print("bout to save");
        System.IO.File.WriteAllLines(@"savedFiles\fuckmeintheass.txt", help);
        //print("saved");
        setInfoBox("saved.");
        utd = true;

    }

    public void loadGameState(int i)
    {

        destroyAll();
        
        string[] help = System.IO.File.ReadAllLines(@"savedFiles\fuckmeintheass.txt");
        //print(help[0] + ""+ help[1]);
        terrain.Clear();
        int helpCounter = 0;
        for(int i0 = 0; i0 < help.Length/3; i0++)
        {
            
            savingBlock sb = new savingBlock();
            sb.go = help[helpCounter];
            helpCounter++;
            sb.x = float.Parse(help[helpCounter], CultureInfo.InvariantCulture.NumberFormat);
            helpCounter++;
            sb.y = float.Parse(help[helpCounter], CultureInfo.InvariantCulture.NumberFormat);
            helpCounter++;

            terrain.Add(sb);
            
        }
        //print("terrain count: "+terrain.Count);
        int i1 = 0;
        for (; i1 < terrain.Count; i1++)
        {
            //print("i0: "+i1);
            //print("terrain count: " + terrain.Count);
            //print("terrain.go : " + terrain[i1].go);

            if (terrain[i1].go.Equals("Dirt(Clone)"))
            {
                Instantiate(dirt,new Vector3(terrain[i1].x,terrain[i1].y,0f), new Quaternion());
            }
            else if (terrain[i1].go.Equals("Sand(Clone)"))
            {
                Instantiate(sand, new Vector3(terrain[i1].x, terrain[i1].y, 0f), new Quaternion());
            }
            else if (terrain[i1].go.Equals("Grass(Clone)"))
            {
                Instantiate(grass, new Vector3(terrain[i1].x, terrain[i1].y, 0f), new Quaternion());
            }
            else if (terrain[i1].go.Equals("BlackBlock(Clone)"))
            {
                Instantiate(blackblock, new Vector3(terrain[i1].x, terrain[i1].y, 0f), new Quaternion());
            }
            else if (terrain[i1].go.Equals("Brick(Clone)"))
            {
                Instantiate(brick, new Vector3(terrain[i1].x, terrain[i1].y, 0f), new Quaternion());
            }
            else if (terrain[i1].go.Equals("Ice(Clone)"))
            {
                Instantiate(ice, new Vector3(terrain[i1].x, terrain[i1].y, 0f), new Quaternion());
            }
            else if (terrain[i1].go.Equals("Lava(Clone)"))
            {
                Instantiate(lava, new Vector3(terrain[i1].x, terrain[i1].y, 0f), new Quaternion());
            }
            else if (terrain[i1].go.Equals("ph(Clone)"))
            {
                Instantiate(ph, new Vector3(terrain[i1].x, terrain[i1].y, 0f), new Quaternion());
            }
            else if (terrain[i1].go.Equals("Water(Clone)"))
            {
                Instantiate(water, new Vector3(terrain[i1].x, terrain[i1].y, 0f), new Quaternion());
            }
            else if (terrain[i1].go.Equals("ph"))
            {
                
                //print("elele");
                ph = Instantiate(phFab, new Vector3(terrain[i1].x, terrain[i1].y, 0f), new Quaternion()) as GameObject;
                status = "ph selected";
            }
            
            //print("i0: " + i0); 
        }
        //status = "nothing";

    }

    public void destroyAll()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            if (o.name != "GOD" && o.name != "Main Camera")
                Destroy(o);
        }
    }

    public void setInfoBox(string text)
    {
        infoBox[2] = infoBox[1];
        infoBox[1] = infoBox[0];
        infoBox[0] = text;
    }

}


public class savingBlock
{
    public string go { get; set; }
    public float x { get; set; }
    public float y { get; set; }

}