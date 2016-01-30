using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArenaPlayer : MonoBehaviour
{

    public GameObject mainCamera;

    public GameObject crosshair;

    //public Vector2 mousePos;
    public Vector3 screenPos;

    public GameObject UIText;

    public bool dead;

    public int health;

    public int tomatoCount;

    public float direction;

    public GameObject tomato;

    public float curTrigger;
    public float oldTrigger;

    // Use this for initialization
    void Start()
    {

        //mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void TakeDamage(bool kill) //Take Damage and Die if necessary
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

    void Die() //Kill the Player
    {

        GetComponent<SpriteRenderer>().color = Color.magenta;
        dead = true;
    }

    void OnCollisionEnter2D(Collision2D coll) //Take Ammo
    {
        if (coll.gameObject.GetComponent<ArenaOpponent>() != null)
        {
            // Debug.Log("Hit the player!");

            if (coll.gameObject.GetComponent<ArenaOpponent>().dead)
            {

                tomatoCount += coll.gameObject.GetComponent<ArenaOpponent>().mAmmoRemaining;
                coll.gameObject.GetComponent<ArenaOpponent>().mAmmoRemaining = 0;
            }

        }
        // Destroy(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {

        UIText.GetComponent<Text>().text = ("Lives: " + health + "\n" + "Ammo: " + tomatoCount); //Display Health and Ammo

        if (health < 0)
        {

            health = 0;
        }

        if (!dead)
        {


            if (Input.GetAxis("AnalogRightBumper") > .3f) //Shoot
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

            screenPos = crosshair.transform.position;

            float zz = Mathf.Atan2((screenPos.y - transform.position.y), (screenPos.x - transform.position.x)) * Mathf.Rad2Deg;

            transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, zz); //Rotate

            transform.Rotate(new Vector3(0, 0, -90)); //Adust due to the image

            transform.position += new Vector3(Input.GetAxis("AnalogLeftHorizontal") / 10, Input.GetAxis("AnalogLeftVertical") / 10); //Move

            oldTrigger = curTrigger; //Used to see if trigger is pressed
        }

        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);


    }
}
