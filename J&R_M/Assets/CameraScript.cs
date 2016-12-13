using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    private Rigidbody2D rgbdy;
    private Rigidbody2D player;

    // Use this for initialization
    void Start () {
        //rgbdy.fixedAngle =  true;
        //player = NewBehaviourScript.getRgbdy();
	}
	
	// Update is called once per frame
	void Update () {

        rgbdy.freezeRotation = true;
    }
    
}
