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

    void OnTriggerEnter2D(Collider2D coll)
    {
        

        if (coll.gameObject.GetComponent<ArenaPlayer>() == null)
        {
            //Debug.Log("Hit the Enemy!");

            if (coll.gameObject.GetComponent<ArenaOpponent>() == null)
            {

                Destroy(this.gameObject);
            }
            else
            {

                if (coll.gameObject.GetComponent<ArenaOpponent>().dead)
                {


                }
                else
                {

                    Destroy(this.gameObject);
                }
            }

           
        }

        if (coll.gameObject.GetComponent<ArenaOpponent>() != null)
        {
            Debug.Log("Hit the Enemy!");

            ////if (GetComponent<ArenaOpponent>() != null)
            // {

            coll.gameObject.GetComponent<ArenaOpponent>().GetHitByPlayer();
            //}

        }
        //Destroy(this.gameObject);

    }
}
