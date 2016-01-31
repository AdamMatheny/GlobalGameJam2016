using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public ArenaPlayer player;

    public GameObject[] healths = new GameObject[0];

	// Use this for initialization
	void Start () {

        player = GameObject.FindObjectOfType<ArenaPlayer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (player.health == 4)
        {
            foreach (GameObject bar in healths)
            {

                bar.SetActive(false);
            }
        }
        if (player.health == 3)
        {
            healths[3].SetActive(true);
        }
        if (player.health == 2)
        {
            healths[2].SetActive(true);
        }
        if (player.health == 1)
        {
            healths[1].SetActive(true);
        }
        if (player.health == 0)
        {
            healths[0].SetActive(true);
        }
    }
}
