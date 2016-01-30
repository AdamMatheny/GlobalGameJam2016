using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

    public float x;
    public float y;

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        transform.localPosition = new Vector3((x * 4), (y * 4), transform.localPosition.z);
    }
}
