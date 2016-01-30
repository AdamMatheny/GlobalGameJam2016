using UnityEngine;
using System.Collections;

public class GoodTomatoCode : MonoBehaviour {

    public float move;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //transform.Translate(transform.forward);

        transform.Translate(0f, Time.deltaTime * move, 0f);
    }
}
