using UnityEngine;
using System.Collections;

public class ChangeSkyColor : MonoBehaviour {

    public float time;
    public float timer;

    public bool goBlack = true;

	// Use this for initialization
	void Start () {

        timer = time;
	}
	
	// Update is called once per frame
	void Update () {

        if (timer > 0)
        {

            timer -= Time.timeScale;
        }
        else
        {

            goBlack = !goBlack;
            timer = time;
        }

        

        if (goBlack)
        {

            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.black, 0.003f);
        }
        else
        { 
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.white, 0.003f);

        }

    }
}
