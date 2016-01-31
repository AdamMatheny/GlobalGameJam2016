using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class ArenaPlayer : MonoBehaviour
{

    public Sprite deadSprite;

    public bool notWon = true;

    public bool gameStarted;
    public GameObject ammoKeeper;

    public GameObject mainCamera;

    public GameObject crosshair;

    //public Vector2 mousePos;
    public Vector3 screenPos;

    public GameObject UIText;
    public GameObject UIText2;
    public GameObject UIImage;

    public bool dead;

    public int health;

    public int tomatoCount;

    public float direction;

    public GameObject tomato;

    public float curTrigger;
    public float oldTrigger;


	public ArenaPlayerGraphics mPlayerGraphics;

    // Use this for initialization
    void Start()
    {
        ammoKeeper = GameObject.FindGameObjectWithTag("Ammo");
        tomatoCount = ammoKeeper.GetComponent<Ammo>().ammo;
        //mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    IEnumerator Win()
    {

        yield return new WaitForSeconds(2f);
		
        Application.LoadLevel(1);
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

        mainCamera.GetComponentInChildren<CameraShake>().ShakeCamera();
        mainCamera.GetComponentInChildren<CameraShake>().mShakeStrength = .35f;
        mainCamera.GetComponentInChildren<CameraShake>().mShakeDuration = .3f;
    }

    IEnumerator KillOffPlayer()
    {

        yield return new WaitForSeconds(2f);

        Debug.Log("GO TO NEXT SCENE!");
    }

    void Die() //Kill the Player
    {

        //GetComponent<SpriteRenderer>().color = Color.magenta;

        if (!dead)
        {

            UIImage.gameObject.SetActive(true);

            dead = true;
            PlayerPrefs.SetInt("ArenaRound", -1);

            StartCoroutine(KillOffPlayer());
        }

        
        GetComponent<SpriteRenderer>().color = Color.magenta;
        dead = true;
		PlayerPrefs.SetInt("ArenaRound",-1);
		Application.LoadLevel(4);
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

        ArenaOpponent[] enemies = GameObject.FindObjectsOfType<ArenaOpponent>();

        notWon = false;

        foreach (ArenaOpponent enemy in enemies)
        {

            if(enemy.dead == false)
            {


                notWon = true;
            }
        }

        if (notWon == false)
        {
            if (dead == false && gameStarted)
            { Debug.Log("VICTORY!"); StartCoroutine(Win()); }
        }



        //UIText.GetComponent<Text>().text = ("Lives: " + health + "\nAmmo: " + tomatoCount+"\nScore: "+PlayerPrefs.GetInt("RoundScore")); //Display Health and Ammo
        UIText.GetComponent<Text>().text = ("   x " + tomatoCount);
        UIText2.GetComponent<Text>().text = ("Score: " + PlayerPrefs.GetInt("RoundScore"));

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
				mPlayerGraphics.mPlayThrowAnim();
                Instantiate(tomato, transform.position, transform.rotation);
                tomatoCount--;

                mainCamera.GetComponentInChildren<CameraShake>().ShakeCamera();
                mainCamera.GetComponentInChildren<CameraShake>().mShakeStrength = .25f;
                mainCamera.GetComponentInChildren<CameraShake>().mShakeDuration = .3f;
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
