using UnityEngine;
using System.Collections;

public class ArenaPlayer : MonoBehaviour {

    public bool dead;

    public int health;

    public int tomatoCount;

    public float direction;

    public GameObject tomato;

    public float curTrigger;
    public float oldTrigger;

	// Use this for initialization
	void Start () {
	
	}

    public void TakeDamage(bool kill)
    {

        if (kill)
        {

            health = 0;
        }
        else
        {

            health--;
        }

        if (health <= 0)
        {

            Die();
        }
    }

    void Die()
    {

        GetComponent<SpriteRenderer>().color = Color.magenta;
        dead = true;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent<ArenaOpponent>() != null)
        {
            // Debug.Log("Hit the player!");

            tomatoCount += coll.gameObject.GetComponent<ArenaOpponent>().mAmmoRemaining;
            coll.gameObject.GetComponent<ArenaOpponent>().mAmmoRemaining = 0;
        }
       // Destroy(this.gameObject);

    }

    // Update is called once per frame
    void Update () {

        if (!dead)
        {

            if (Input.GetAxis("AnalogRightBumper") > .3f)
            {

                curTrigger = 1;
            }
            else
            {
                curTrigger = 0;
            }

            if (curTrigger == 1 && oldTrigger == 0 && tomatoCount > 0)
            {

                Instantiate(tomato, transform.position, transform.rotation);
                tomatoCount--;
            }

            //   direction = new Vector3(Input.GetAxis("AnalogRightHorizontal"), 0, Input.GetAxis("AnalogRightVertical"));

            //transform.up = direction;

            direction = Mathf.Atan2(Input.GetAxis("AnalogRightVertical"), Input.GetAxis("AnalogRightHorizontal")) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(direction, Vector3.forward);
            transform.Rotate(new Vector3(0, 0, -90));
            //   transform.rotation = new Vector3(0, 0, transform.rotation.z - 90);

            //var rotation = Quaternion.LookRotation(direction, Vector3.up);
            // transform.rotation = rotation;

            transform.position += new Vector3(Input.GetAxis("AnalogLeftHorizontal") / 10, Input.GetAxis("AnalogLeftVertical") / 10);

            oldTrigger = curTrigger;
        }

        
	}
}
